using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMoves : MonoBehaviour {


	PlayerState playerState;
	PlayerPositions positions; 
	Animator animator;  // Animator param: int stateAnim; 0:normal, 1:speeding, 2:jumping 

	[SerializeField]
	Track track; //a velocidade do jogador é definido em track, pois é ele que está se movendo na verdade
	[SerializeField]
	Sounds sounds;


	[SerializeField]
	float speedChangingLane = 5, jumpStrenght = 350; 

	bool changingLane = false;
	bool speedNotNormal = false;

	private float timeLeftToChangeLane;


	bool speedingFast = false;
	bool speedingSlow = false;

	public bool pressedDownJump = false; // não permitir que pule várias vezes só por segurar o botão de pulo





	// Use this for initialization
	void Start () {

		playerState = GetComponent <PlayerState> ();
		positions = GetComponent <PlayerPositions> ();
		animator = GetComponent <Animator> ();

	}



	public void goUpOneLane ()
	{

		if (!playerState.ableMoveUpOneLane () || changingLane)
			return;

		playerState.goUpOneLane ();

		StartCoroutine(goUpOneLaneRoutine ());

	}


	IEnumerator goUpOneLaneRoutine ()
	{
		Lane destLane = playerState.Lane;  //já mudou de lane em playerState
		Vector3 destPosition = positions.positionPlayerLane(destLane);
		changingLane = true;

		while (transform.position != destPosition) {
			yield return new WaitForEndOfFrame ();
			transform.position = Vector3.MoveTowards (transform.position, destPosition, speedChangingLane * Time.deltaTime);
		}

		changingLane = false;
	}



	public void goDownOneLane ()
	{

		if (!playerState.ableMoveDownOneLane () || changingLane)
			return;

		playerState.goDownOneLane ();

		StartCoroutine(goDownOneLaneRoutine ());

	}


	IEnumerator goDownOneLaneRoutine ()
	{
		Lane destLane = playerState.Lane;  //já mudou de lane em playerState
		Vector3 destPosition = positions.positionPlayerLane(destLane);
		changingLane = true;

		while (transform.position != destPosition) {
			yield return new WaitForEndOfFrame ();
			transform.position = Vector3.MoveTowards (transform.position, destPosition, speedChangingLane * Time.deltaTime);
		}

		changingLane = false;
	}


	public void jump ()
	{
		if (playerState.Grounded) {
			Rigidbody2D RBplayer = GetComponent<Rigidbody2D> ();
			RBplayer.AddForce (new Vector2 (0, jumpStrenght));

			animator.SetInteger("stateAnim", 2);
			playerState.Grounded = false; //vamos adiantar para outras checagens, saída de colisão também seta isso
			print("Colocou como 2");


		}
	}

	private void setPlayerSpeedNormal ()
	{
		track.CurrentSpeedType = speedType.normal;
		if (playerState.Grounded) {
			animator.SetInteger ("stateAnim", 0);  //0:normal, 1:speeding, 2:jumping 
//			print("Colocou como 0");
		}
	}

	private void setPlayerSpeedSlow ()
	{
		track.CurrentSpeedType = speedType.slow;
		if (playerState.Grounded) {
			animator.SetInteger ("stateAnim", 0);  //0:normal, 1:speeding, 2:jumping 
		}
		speedNotNormal = true;
	}


	private void setPlayerSpeedFast ()
	{
		track.CurrentSpeedType = speedType.fast;
		if (playerState.Grounded) {
			animator.SetInteger ("stateAnim", 1);
//				print("Colocou como 1");
		}
		speedNotNormal = true;

	}



	public void startSpeedFast ()
	{
		speedingFast = true;
		sounds.playAcelerateSfx ();
	}

	public void stopSpeedFast ()
	{
		speedingFast = false;
	}

	public void startSpeedSlow ()
	{
		speedingSlow = true;
		sounds.playBrakeSfx ();
	}

	public void stopSpeedSlow ()
	{
		speedingSlow = false;
	}

	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			goUpOneLane ();
		}

		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			goDownOneLane ();
		}


//		if (Input.GetKeyDown (KeyCode.RightArrow)) {
//			setPlayerSpeedFast ();
//
//		} 

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			startSpeedFast ();
		} 

		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			stopSpeedFast ();
		} 



//		if (Input.GetKey (KeyCode.LeftArrow)) {
//			setPlayerSpeedSlow ();
//		} 

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			startSpeedSlow ();
		} 

		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			stopSpeedSlow ();
		} 


		if (speedingFast) {
			setPlayerSpeedFast ();
		}

		if (speedingSlow) {
			setPlayerSpeedSlow ();
		}

		if (Input.GetKeyDown (KeyCode.Space)) {  //precisa ser getkeydown para não pular múltiplas vezes
			jump ();
		}

	}


	void LateUpdate () {


		if (playerState.Grounded) {

			if (!speedNotNormal) //não apertou para nenhum lado, a velocidade deve ser normal
				setPlayerSpeedNormal ();
			else
				speedNotNormal = false; //é que deve ser atualizado frame a frame
		}


//		print("stateAnim = " + animator.GetInteger ("stateAnim"));

	}
}

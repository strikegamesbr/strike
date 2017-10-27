using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtfulScnObj : SceneObjects { //SceneObjects herda de MonoBehaviour


	bool lockDamage = false;
	NumMovableObjsManager numMovObjMan;
	ScoreByTimeManager scoreByTimeMan;


	// Use this for initialization
	void Start () {
		toStart ();
		numMovObjMan = FindObjectOfType<NumMovableObjsManager> ();
		scoreByTimeMan = playerState.gameObject.GetComponent<ScoreByTimeManager> ();
	}

	void OnTriggerStay2D (Collider2D col) 
	{
		checkAndDamagePlayer (col);
//		OnTriggerEnter2D (col);
	}


	void OnTriggerEnter2D (Collider2D col)
	{

		checkAndDamagePlayer (col);

//		if (col.name == "Player" && col.GetComponent<PlayerState> ().Lane == this.Lane) {
//			damagePlayer ();
//		}

//		if (col.name == "destroyer") {
//			this.gameObject.SetActive(false);;
//		}

	}


	private void checkAndDamagePlayer (Collider2D col)
	{
		if (col.name == "Player" && col.GetComponent<PlayerState> ().Lane == this.Lane) {
			
			damagePlayer ();		
		}
	}


	private void damagePlayer ()
	{

		if (!lockDamage) {
			lockDamage = true; //não precisa voltar a ser falso pois será destruído
//			playerState.gameObject.GetComponent<ScoreByTimeManager>().HaltGainingPoints = true;
			scoreByTimeMan.HaltGainingPoints = true;

			debug.debugLog (8);//"Recebeu dano " + Kind + " (008)");
			int damageToTake = 0;

			if (gameObject.name.Contains ("skatista"))
				damageToTake = scnObjManager.danoSkatista;
			else if (gameObject.name.Contains ("patinadora"))
				damageToTake = scnObjManager.danoPatinadora;
			else if (gameObject.name.Contains ("cone"))
				damageToTake = scnObjManager.danoBeachBall;

			playerState.takeDamage (damageToTake);

			StartCoroutine (damagePlayerRoutine ());
		}

	}



	//somente as animações associadas, não o dano em si (nem a retirada de um mario/vida na UI, nem o Game Over)
	IEnumerator damagePlayerRoutine ()
	{

		//mudar material de player e dele mesmo

		//vamos colocar valores necessários em variáveis locais
		Material hurtMat = scnObjManager.HurtMaterial;
		Material normalMat = scnObjManager.NormalMaterial;
		GameObject player = scnObjManager.Player;
		float timeToWait = scnObjManager.TimeDamage;

		SpriteRenderer srHurtObj = GetComponent<SpriteRenderer> ();
		SpriteRenderer srPlayer = player.GetComponent<SpriteRenderer> ();


		//as instruções pra valer começam agora
		//tanto a corotina abaixo quanto a espera devem durar o mesmo tempo
		//a rotina abaixo pára a estrada

		StartCoroutine (track.stopTrackForSeconds(timeToWait));

		sounds.playCollideSfx ();
		srHurtObj.material = hurtMat;
		srPlayer.material = hurtMat;
		yield return new WaitForSeconds (timeToWait/3);
		srHurtObj.material = normalMat;
		srPlayer.material = normalMat;
		yield return new WaitForSeconds (timeToWait/3);
		srHurtObj.material = hurtMat;
		srPlayer.material = hurtMat;
		yield return new WaitForSeconds (timeToWait/3);
		srHurtObj.material = normalMat;
		srPlayer.material = normalMat;

		if (!playerState.GameOver)
			playerState.gameObject.GetComponent<ScoreByTimeManager>().HaltGainingPoints = false;

//		scnObjManager.simulActivInactivObj (this.gameObject, false);
		gameObject.SetActive(false);

	}



	//vai checar se este é um objeto que se move (tem speed>0) e que se tornou visível agora
	//daí vai ser adicionado ao ScnObjManager como um novo visível
	//e ele vai decidir se deixa na tela ou se já tem skatistas e patinadores demais e por isso vai destruí-lo
	void OnBecameVisible ()
	{

		//se for a câmera do editor do Unity não interessa
		#if UNITY_EDITOR
		if (Camera.current.name == "SceneCamera") 
			return;
		#endif
		// put your code here

		IsVisible = true;
		lockDamage = false;

		if (Speed != 0) {
			numMovObjMan.OneMovableObjectBecameVisible (this.gameObject);
		}
	}


	void OnBecameInvisible ()
	{
		//se for a câmera do editor do Unity não interessa
//		#if UNITY_EDITOR
//		try {
//		if (Camera.current.name == "SceneCamera") 
//			return;
//		} catch {}
//		#endif
		// put your code here

		IsVisible = false;
		Taken = false; //se ficou invisível pode ficar disponível para outros blocos

		//usamos o try pois um dos motivos dele se tornar invisível pode ser sua destruição
		try {

			if (Speed != 0) {
				numMovObjMan.oneMovableObjectBecameInvisible ();
			}

		} catch {
		}


	}

	void OnDestroy ()
	{
//		print ("destruído? " + this.gameObject.name);

	}
	
	// Update is called once per frame
	void Update () {
		toUpdate ();
	}
}

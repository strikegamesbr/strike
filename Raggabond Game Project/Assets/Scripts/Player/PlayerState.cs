using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//todo quando chegar a zero


public class PlayerState : MonoBehaviour {


	[SerializeField]
	private int lives = 5;

	[SerializeField]
	private ulong score = 0;

	[SerializeField]
	private GameObject GameOverScreen, ScoreTextHUDObject;



	[SerializeField]
	private Lane lane;  //define se o player está neste lane ou se está descendo ou subindo para ele
	[SerializeField]
	bool grounded = true; //enquanto começar no chão, começará true

	private bool gameOver = false;


	[SerializeField]
	string aviso;


	// Use this for initialization
	void Start () {

		GameOverScreen.SetActive (false);
		aviso = "Não mude o lane no Unity! É para consulta somente!";

	}


	public  Lane  Lane {
		get {
			return lane;
		}

		set {
			lane = value;

			switch (lane) {

			case Lane.lower:
				GetComponent<SpriteRenderer> ().sortingOrder = 2;
				break;
			case Lane.middle:
				GetComponent<SpriteRenderer> ().sortingOrder = 1;
				break;
			case Lane.upper:
				GetComponent<SpriteRenderer> ().sortingOrder = 0;
				break;
			}

		}

	}


	public int Lives {

		get {
			return lives;
		}

		set {
			if (value >= 0 && value <= 5)
				lives = value;

		}
	}


	public ulong Score {

		get {
			return score;
		}

		set {

			score = value;
//			print("Quem mudou o score?");
		}

	}



	public  bool  Grounded {
		get {
			return grounded;
		}

		set {
			grounded = value;
		}

	}


	public bool GameOver {
		get {
			return gameOver;
		}
	}


	private bool playerIsAbleToMove ()
	{
		return true;
	}

	public bool ableMoveUpOneLane ()
	{
		if (!playerIsAbleToMove ())
			return false;

		if (Lane != Lane.upper)
			return true;
		else
			return false;

	}

	public bool ableMoveDownOneLane ()
	{
		if (!playerIsAbleToMove ())
			return false;

		if (Lane != Lane.lower)
			return true;
		else
			return false;

	}


	public void goUpOneLane ()
	{
		switch (Lane) {
		case Lane.lower:
			Lane = Lane.middle;
			break;
		default:
			Lane = Lane.upper;
			break;
		}

	}


	public void goDownOneLane ()
	{

		switch (Lane) {
		case Lane.upper:
			Lane = Lane.middle;
			break;
		default:
			Lane = Lane.lower;
			break;
		}

	}


	public void takeDamage (int howMuch)
	{
		Lives = Lives - howMuch;

		if (Lives <= 0) {//quando chegar a zero

			StartCoroutine (GameOverRoutine ());

		}

	}


	IEnumerator GameOverRoutine () { 

		gameOver = true;

		float timeStoppedByDamage = FindObjectOfType<ScnObjManager> ().TimeDamage;

		GetComponent<ScoreByTimeManager> ().HaltGainingPoints = true;
		//dá o tempo para ele parar com o dano
		yield return new WaitForSeconds (timeStoppedByDamage);

		GetComponent<SpriteRenderer> ().enabled = false; //faz ele sumir sem destruir o objeto, o que pararia esta rotina

		FindObjectOfType<Track> ().stopTrackAndLock ();


		//		ScoreTextHUDObject.SetActive (false);
		GameOverScreen.GetComponentInChildren<Text> ().text = score.ToString ();
		GameOverScreen.SetActive (true);



		yield return new WaitForSeconds (FindObjectOfType<MainController>().TimeGameOverToMainMenu);
		SceneManager.LoadScene ("MainMenu");




	}




	public void gainScoreLives (ulong scoreToGain, int livesToGain)
	{
		Score = Score + scoreToGain;
		Lives = Lives + livesToGain;
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}

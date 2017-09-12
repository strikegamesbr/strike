using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//todo quando chegar a zero


public class PlayerState : MonoBehaviour {


	[SerializeField]
	private int lives = 5;

	[SerializeField]
	private ulong score = 0;


	[SerializeField]
	private Lane lane;  //define se o player está neste lane ou se está descendo ou subindo para ele
	[SerializeField]
	bool grounded = true; //enquanto começar no chão, começará true



	[SerializeField]
	string aviso;


	// Use this for initialization
	void Start () {
		
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
				GetComponent<SpriteRenderer> ().sortingOrder = 0;
				break;
			case Lane.middle:
				GetComponent<SpriteRenderer> ().sortingOrder = 1;
				break;
			case Lane.upper:
				GetComponent<SpriteRenderer> ().sortingOrder = 2;
				break;
			}

		}

	}


	public int Lives {

		get {
			return lives;
		}

		set {
			if (value >= 0)
				lives = value;

		}
	}


	public ulong Score {

		get {
			return score;
		}

		set {

			score = value;
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

			//todo quando chegar a zero

		}

	}



	public void gainScore (ulong howMuch)
	{
		Score = Score + howMuch;
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}

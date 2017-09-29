using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositions : MonoBehaviour {


	private PlayerState playerState;

	[SerializeField]
	private float posXPlayerLowerLane = -5, posYPlayerLowerLane = -2.8f;
	[SerializeField]
	private float posXPlayerMiddleLane = -5, posYPlayerMiddleLane = -2.2f; 
	[SerializeField]
	private float posXPlayerUpperLane = -5, posYPlayerUpperLane = -1.6f; 



	public float PosYPlayerLowerLane {
		get {
			return posYPlayerLowerLane;
		}
	}

	public float PosYPlayerMiddleLane {
		get {
			return posYPlayerMiddleLane;
		}
	}

	public float PosYPlayerUpperLane {
		get {
			return posYPlayerUpperLane;
		}
	}

	public float PosXPlayerLowerLane {
		get {
			return posXPlayerLowerLane;
		}
	}

	public float PosXPlayerMiddleLane {
		get {
			return posXPlayerMiddleLane;
		}
	}

	public float PosXPlayerUpperLane {
		get {
			return posXPlayerUpperLane;
		}
	}




	public Vector2 positionPlayerLowerLane {
		get	{
			return new Vector2 (posXPlayerLowerLane, posYPlayerLowerLane);
		}
	}

	public Vector2 positionPlayerMiddleLane {
		get {
			return new Vector2 (posXPlayerMiddleLane, posYPlayerMiddleLane);
		}
	}

	public Vector2 positionPlayerUpperLane {
		get {
			return new Vector2 (posXPlayerUpperLane, posYPlayerUpperLane);
		}
	}


	void Awake ()
	{
//		posXPlayerLowerLane = -5; posYPlayerLowerLane = -2.85f;
//
//		posXPlayerMiddleLane = -5; posYPlayerMiddleLane = -2.3f; 
//
//		posXPlayerUpperLane = -5; posYPlayerUpperLane = -1.6f;
	}


	// Use this for initialization
	void Start () {


		playerState = GetComponent <PlayerState> ();

		//todo só deixe fazer isso se ele estiver no chão e puder mudar de lane, quando implementar pulo e outrass coisas não deixe
		switch (playerState.Lane) {

		case Lane.lower:
			transform.position = positionPlayerLowerLane;
			break;
		default:
		case Lane.middle:
			transform.position = positionPlayerMiddleLane;
			break;
		case Lane.upper:
			transform.position = positionPlayerUpperLane;
			break;
		}






	}



	public Vector2 positionPlayerLane (Lane lane) 
	{

		switch (lane) {
		case Lane.lower:
			return positionPlayerLowerLane;
		default:
		case Lane.middle:
			return positionPlayerMiddleLane;
		case Lane.upper:
			return positionPlayerUpperLane;

		}

	}

		
	// Update is called once per frame
	void Update () {


	}
}

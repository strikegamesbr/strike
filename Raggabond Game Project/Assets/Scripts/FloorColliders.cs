using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColliders : MonoBehaviour {


	[SerializeField]
	private PlayerState playerState;
	[SerializeField]
	private PlayerPositions playerPositions;

	[SerializeField]
	private Transform lowerFloorCollider, middleFloorCollider, upperFloorCollider;


	// Use this for initialization
	void Start () {

		float Ylower = playerPositions.PosYPlayerLowerLane - 3.076f; //esta fórmula é específica para a montagem atual da cena 
		float Ymiddle = playerPositions.PosYPlayerMiddleLane - 3.076f; //esta fórmula é específica para a montagem atual da cena 
		float Yupper = playerPositions.PosYPlayerUpperLane - 3.076f; //esta fórmula é específica para a montagem atual da cena 


		float Xlower = playerPositions.PosXPlayerLowerLane; //esta fórmula é específica para a montagem atual da cena 
		float Xmiddle = playerPositions.PosXPlayerMiddleLane; //esta fórmula é específica para a montagem atual da cena 
		float Xupper = playerPositions.PosXPlayerUpperLane; //esta fórmula é específica para a montagem atual da cena 




		lowerFloorCollider.position = new Vector3 (Xlower, Ylower, 0); //estes valores são específicos para a montagem atual da cena 
		middleFloorCollider.position = new Vector3 (Xmiddle, Ymiddle, 0); //estes valores são específicos para a montagem atual da cena 
		upperFloorCollider.position = new Vector3 (Xupper, Yupper, 0); //estes valores são específicos para a montagem atual da cena 
				
	}


	private void laneIslower ()
	{

		lowerFloorCollider.gameObject.SetActive (true);
		middleFloorCollider.gameObject.SetActive (false);
		upperFloorCollider.gameObject.SetActive (false);

	}

	private void laneIsMiddle ()
	{

		lowerFloorCollider.gameObject.SetActive (false);
		middleFloorCollider.gameObject.SetActive (true);
		upperFloorCollider.gameObject.SetActive (false);

	}

	private void laneIsUpper ()
	{

		lowerFloorCollider.gameObject.SetActive (false);
		middleFloorCollider.gameObject.SetActive (false);
		upperFloorCollider.gameObject.SetActive (true);

	}



	// Update is called once per frame
	void Update () {

		switch (playerState.Lane) {

		case Lane.lower:
			laneIslower ();
			break;
		case Lane.middle:
			laneIsMiddle ();
			break;
		case Lane.upper:
			laneIsUpper ();
			break;

		}



		
	}
}

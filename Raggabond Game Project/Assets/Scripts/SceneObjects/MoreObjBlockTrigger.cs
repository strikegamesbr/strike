using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreObjBlockTrigger : MonoBehaviour {

	BlockOfObjects blockOfObjects;
	DebuggingRag debugRag;


	// Use this for initialization
	void Start () {
		
		blockOfObjects = FindObjectOfType<BlockOfObjects> ();
		debugRag = FindObjectOfType<DebuggingRag> ();
	}



	void OnTriggerEnter2D (Collider2D col)
	{
//		Debug.Log ("Houve colisão");

		if (col.name == "Player") {			
			debugRag.debugLog (7);
//			Debug.Log ("Vamos colocar os obstáculos na cena - (007)");
			blockOfObjects.placeObstaclesOnScene ();
		}

	}

	void OnTriggerExit2D (Collider2D col)
	{
	}


	void OnTriggerStay2D (Collider2D col)
	{
	}




	// Update is called once per frame
	void Update () {

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreObjBlockTrigger : MonoBehaviour {

	BlockOfObjects blockOfObjects;
	DebuggingRag debug;


	// Use this for initialization
	void Start () {
		
		blockOfObjects = FindObjectOfType<BlockOfObjects> ();
		debug = FindObjectOfType<DebuggingRag> ();
	}



	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.name == "Player") {
			debug.debugLog (7);
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

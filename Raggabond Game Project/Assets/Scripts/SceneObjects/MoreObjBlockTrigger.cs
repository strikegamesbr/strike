using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreObjBlockTrigger : MonoBehaviour {

//	PlacerObjectsBlocks plObjBlocks;
	BlockOfObjects blockOfObjects;


	// Use this for initialization
	void Start () {

//		plObjBlocks = transform.parent.GetComponent<PlacerObjectsBlocks> ();

//		plObjBlocks = FindObjectOfType<PlacerObjectsBlocks> ();
		blockOfObjects = FindObjectOfType<BlockOfObjects> ();

	}



	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.name == "Player") {
			Debug.Log ("Vamos colocar os obstáculos na cena - (007)");
			blockOfObjects.placeObstaclesOnScene ();
//			plObjBlocks.putObjectsBlock ();
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

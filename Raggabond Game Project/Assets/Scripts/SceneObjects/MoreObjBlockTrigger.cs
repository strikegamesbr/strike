using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreObjBlockTrigger : MonoBehaviour {

	PlacerObjectsBlocks plObjBlocks;


	// Use this for initialization
	void Start () {

//		plObjBlocks = transform.parent.GetComponent<PlacerObjectsBlocks> ();

		plObjBlocks = FindObjectOfType<PlacerObjectsBlocks> ();

	}



	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.name == "Player") {
			plObjBlocks.putObjectsBlock ();
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

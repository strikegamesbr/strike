using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreFloorCollisions : MonoBehaviour {


	InfiniteTrack infiniteTrack;


	// Use this for initialization
	void Start () {

		infiniteTrack = transform.parent.parent.GetComponent<InfiniteTrack> ();
		
	}



	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.gameObject.name == "Player") {
			infiniteTrack.createFloor ();
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

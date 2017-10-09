using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreBackGroundCollisions : MonoBehaviour {

	InfiniteBackGround infiniteBackGround;


	// Use this for initialization
	void Start () {

		infiniteBackGround = transform.parent.parent.GetComponent<InfiniteBackGround> ();

	}



	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.gameObject.name == "Player") {
			infiniteBackGround.createBG ();
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
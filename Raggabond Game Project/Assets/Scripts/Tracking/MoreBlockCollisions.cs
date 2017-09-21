using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreBlockCollisions : MonoBehaviour {


	Blocks blocks;


	// Use this for initialization
	void Start () {

		blocks = transform.parent.parent.GetComponent<Blocks> ();
		
	}



	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.name == "Player") {
			blocks.putRandomBlock ();
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

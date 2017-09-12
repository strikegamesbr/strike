using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//por enquanto ele só está lidando com o pulo, as outras coisas estão sendo lidadas com os próprios colisores
public class PlayerCollisions : MonoBehaviour {


	private PlayerState playerState;


	// Use this for initialization
	void Start () {

		playerState = GetComponent<PlayerState> ();

	}


	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "floor")
			playerState.Grounded = true;
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if (col.gameObject.tag == "floor")
			playerState.Grounded = false;
	}


	void OnCollisionStay2D (Collision2D col)
	{
	}


	void OnTriggerEnter2D (Collider2D col)
	{
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

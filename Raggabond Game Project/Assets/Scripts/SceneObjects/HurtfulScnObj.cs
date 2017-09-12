using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtfulScnObj : SceneObjects { //SceneObjects herda de MonoBehaviour



	// Use this for initialization
	void Start () {
		toStart ();
	}


	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.gameObject.name == "Player") {

			int damageToTake = 0;

			if (gameObject.name == "skatista")
				damageToTake = scnObjManager.danoSkatista;
			else if (gameObject.name == "patinadora")
				damageToTake = scnObjManager.danoPatinadora;

			playerState.takeDamage (damageToTake);

			StartCoroutine (takeDamageRoutine (col.gameObject));

		}
	}


	IEnumerator takeDamageRoutine (GameObject player)
	{
		//mudar material de player e dele mesmo


	}


	
	// Update is called once per frame
	void Update () {
		toUpdate ();
	}
}

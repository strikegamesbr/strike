using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointfulScnObj : SceneObjects { //SceneObjects herda de MonoBehaviour


	// Use this for initialization
	void Start () {
		toStart ();
	}


	void OnTriggerEnter2D (Collision2D col)
	{

		if (col.gameObject.name == "Player") {

			ulong scoreToGain = 0;

			if (gameObject.name == "apple")
				scoreToGain = scnObjManager.scoreApple;
			else if (gameObject.name == "guitar")
				scoreToGain = scnObjManager.scoreGuitar;

			playerState.gainScore (scoreToGain);

		}


	}


	// Update is called once per frame
	void Update () {
		toUpdate ();
	}
}

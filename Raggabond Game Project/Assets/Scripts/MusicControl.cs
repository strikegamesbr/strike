using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControl : MonoBehaviour {


	[SerializeField]
	private 	float 		timeBeforePlayingMusic = 3;

	[SerializeField]
	private 	AudioSource music;	

	// Use this for initialization
	void Start () {

		switch (SceneManager.GetActiveScene().name) {

		case "Stage1":
//			timeBeforePlayingMusic = 3;
			break;

		default:
			timeBeforePlayingMusic = 3;
			break;
		}

		StartCoroutine (startMusic ());


	}
	

	IEnumerator startMusic ()
	{

		yield return new WaitForSeconds (timeBeforePlayingMusic);

		music.Play ();

	}



}

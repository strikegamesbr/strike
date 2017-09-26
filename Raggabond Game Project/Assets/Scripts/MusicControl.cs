using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControl : MonoBehaviour {


	[SerializeField]
	private float timeBeforePlayingMusic = 0, timeBetweenSongs = 1;

	[SerializeField]
	private AudioSource[] songs;	

	// Use this for initialization
	void Start () {

		StartCoroutine (playSongs ());

	}


		
	//toca as músicas, uma depois da outra, e quando acabar a última toca a primeira
	IEnumerator playSongs ()
	{

		int index = 0;

		yield return new WaitForSeconds (timeBeforePlayingMusic);


		while (true) {

			//toca a música
			songs [index].Play();

			//enquanto a música estiver tocando , deixa tocando
			do {
				yield return new WaitForEndOfFrame ();
			} while (songs [index].isPlaying);

			//a música acabou
			//vamos mudar o index para a pŕoxima música, ou primeira se for a última
			if (index < songs.Length - 1)
				index++;
			else
				index = 0;

			yield return new WaitForSeconds (timeBetweenSongs);

		}
	}



}

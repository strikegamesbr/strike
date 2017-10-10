using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTrack : MonoBehaviour {


	[SerializeField]
	private Transform trackPrefab, previousTrack;//, trackToDestroy; 

	private bool firstTime = true;


	private GameObject[] Tracks;


	void Start() 
	{

		Tracks = new GameObject[2];

		//vamos preencher Tracks
		//para o primeiro vamos colocar o que já está colocado na cena no editor
		Tracks[0] = previousTrack.gameObject;

		//o outro instancia um novo
		Tracks[1] = Instantiate (trackPrefab.gameObject);

		Tracks [1].transform.parent = this.transform;
		Tracks[1].transform.rotation = previousTrack.rotation;

		//este novo deve estar invisível para não aparecer na tela
		Tracks [1].SetActive (false);

	}



	//garante que não retorna previousTrack
	private GameObject nextTrack () {

		int j = -1;

		for (int i = 0; i < Tracks.Length; i++) {

			if (Tracks [i] == previousTrack.gameObject) {

				if (i != Tracks.Length - 1)
					j = i + 1;
				else
					j = 0;

				break;
			}

		}

		//		print ("j=" + j);


		if (j >= 0 && j < Tracks.Length) {
			Tracks [j].SetActive (true);
			return Tracks [j];
		}
		else
			return null;

	}




	public void createFloor ()
	{

		//cria o floor na mesma posição de previous com x + 5*previousTrack.localScale.x (5 é metade do comprimento padrão do plano)


		//cria o floor na mesma posição de previous com x + 0.5*previousTrack.localScale.x (0.5 é metade do comprimento padrão de Quad)
		GameObject newTrack = nextTrack ();
		newTrack.transform.position = new Vector3 (previousTrack.position.x + 5 * previousTrack.localScale.x, previousTrack.position.y, previousTrack.position.z);//new Vector3 (previousBG.position.x + 0.5f * previousBG.localScale.x, previousBG.position.y, previousBG.position.z);

		//previousTrack = novo track
		previousTrack = newTrack.transform;



//		GameObject newTrack = Instantiate (trackPrefab.gameObject, 
//			new Vector3 (previousTrack.position.x + 5*previousTrack.localScale.x, previousTrack.position.y, previousTrack.position.z), 
//			previousTrack.rotation, Tracking);
//
//
//		//destrói trackToDestroy
//		if (!firstTime)
//			Destroy (trackToDestroy.gameObject);
//		else
//			firstTime = false;
//
//
//		//trackToDestroy = previousTrack
//		trackToDestroy = previousTrack;
//
//		//previousTrack = novo track
//		previousTrack = newTrack.transform;

	}





}

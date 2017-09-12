using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTrack : MonoBehaviour {


	[SerializeField]
	private Transform Tracking, trackPrefab, previousTrack, trackToDestroy; 

	private bool firstTime = true;




	public void createFloor ()
	{

		//cria o floor na mesma posição de previous com x + 5*previousTrack.localScale.x (5 é metade do comprimento padrão do plano)

		GameObject newTrack = Instantiate (trackPrefab.gameObject, new Vector3 (previousTrack.position.x + 5*previousTrack.localScale.x, previousTrack.position.y, previousTrack.position.z), previousTrack.rotation, Tracking);


		//destrói trackToDestroy
		if (!firstTime)
			Destroy (trackToDestroy.gameObject);
		else
			firstTime = false;


		//trackToDestroy = previousTrack
		trackToDestroy = previousTrack;

		//previousTrack = novo track
		previousTrack = newTrack.transform;

	}





}

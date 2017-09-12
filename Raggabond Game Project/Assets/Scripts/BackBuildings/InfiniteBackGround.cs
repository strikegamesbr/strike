using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackGround : MonoBehaviour {

	[SerializeField]
	private Transform BackGround, BGPrefab, previousBG, BGToDestroy; 


	private bool firstTime = true;


	void Start()
	{


//		Mesh planeMesh = transform.Find("background").GetComponent<MeshFilter>().mesh;
//		Bounds bounds = planeMesh.bounds;
//		// size in pixels
//		float boundsX = bounds.size.x;
//		float boundsY = bounds.size.y;
//		float boundsZ = bounds.size.z;
//
//		print ("boundsX = " + boundsX);

	}


	public void createBG ()
	{

		//cria o floor na mesma posição de previous com x + 0.5*previousTrack.localScale.x (0.5 é metade do comprimento padrão de Quad)

		GameObject newBG = Instantiate (BGPrefab.gameObject, new Vector3 (previousBG.position.x + 0.5f*previousBG.localScale.x, previousBG.position.y, previousBG.position.z), previousBG.rotation, BackGround);


		//destrói trackToDestroy
		if (!firstTime)
			Destroy (BGToDestroy.gameObject);
		else
			firstTime = false;


		//trackToDestroy = previousTrack
		BGToDestroy = previousBG;

		//previousTrack = novo track
		previousBG = newBG.transform;

	}
}

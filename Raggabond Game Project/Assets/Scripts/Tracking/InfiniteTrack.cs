using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTrack : MonoBehaviour {


	[SerializeField]
	private Transform trackPrefab, previousTrack;//, trackToDestroy; 

	[SerializeField]
	private PoolingAux poolAux;

	private GameObject[] Tracks;


	void Start() 
	{
		poolAux.toStart (ref Tracks, new Transform[1] { previousTrack }, previousTrack, this.transform);
	}


	public void createFloor ()
	{

		//cria o floor na mesma posição de previous com x + 5*previousTrack.localScale.x (5 é metade do comprimento padrão do plano)
		Vector3 newPosition = new Vector3 (previousTrack.position.x + 5 * previousTrack.localScale.x, previousTrack.position.y, previousTrack.position.z);
		poolAux.createObject (Tracks, ref previousTrack, newPosition);
		//previousTrack = newTrack.transform; na função acima

	}


}

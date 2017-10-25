using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackGround : MonoBehaviour {

	[SerializeField]
	private Transform BGPrefab, previousBG; 

	[SerializeField]
	private PoolingAux poolAux;

	private GameObject[] Backgrounds;

	DebuggingRag debug;


	//com vetor de 2
	void Start()
	{
		debug = FindObjectOfType<DebuggingRag> ();
		debug.debugLog (4);
		//Debug.Log ("Vamos criar o pool do background - (004)");
		poolAux.toStart (ref Backgrounds, new Transform[1] {BGPrefab}, previousBG, this.transform);
	}


	public void createBG ()
	{
		debug.debugLog (5);
//		Debug.Log ("Vamos colocar um novo backgroung do pool mais na frente - (005)");
		//cria o floor na mesma posição de previous com x + 0.5*previousTrack.localScale.x (0.5 é metade do comprimento padrão de Quad)
		Vector3 newPosition = new Vector3 (previousBG.position.x + 0.5f * previousBG.localScale.x, previousBG.position.y, previousBG.position.z);
		poolAux.createObject (Backgrounds, ref previousBG, newPosition);
		//previousBG = newBG.transform; na função acima


	}






}

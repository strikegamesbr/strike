using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//todo deletar os quarteirões que passaram


public class Blocks : MonoBehaviour {

	[SerializeField]
	PoolingAux poolAux;

	[SerializeField]
	private Transform[] blocksPrefabs;

	[SerializeField]
	private float startX;

	private Transform previousBlock;//, toEraseBlock;

	private GameObject[] BlocksPool;



	// Use this for initialization
	void Start () {


		Debug.Log ("Vamos colocar o quarteirão inicial - (002)");
		//vamos instanciar o bloco inicial, que vai aparecer no início do jogo
		Transform newBlock = Instantiate (blocksPrefabs [0].gameObject).transform;
		newBlock.position = new Vector3 (startX, blocksPrefabs [0].position.y, blocksPrefabs [0].position.z);
		newBlock.SetParent (this.transform);
		previousBlock = newBlock;
//		toEraseBlock = null;


		Debug.Log ("E vamos instanciar os outros quarteirões para fazerem parte do pool de quarteirões - (003)");
		//agora começar o pooling

		//primeiro, vamos fazer um newBlocksPrefab sem o inicial, sem o índice 0
		Transform[] newBlocksPrefabs = new Transform[blocksPrefabs.Length-1];

		for (int i = 1; i < blocksPrefabs.Length; i++) {
			newBlocksPrefabs [i - 1] = blocksPrefabs [i];
		}

		//agora chamar a função de poolAux
		poolAux.toStart(ref BlocksPool, newBlocksPrefabs, previousBlock, this.transform);

	}

	public void putRandomBlock ()
	{

		Debug.Log ("Vamos colocar um novo quarteirão randômico do pool mais na frente - (006)");

		//A posição currentX está no meio do bloco anterior
		//Vamos mover meio bloco anterior para chegar ao seu fim
		float newX;
		Bounds boundsPrevious = previousBlock.GetComponent<SpriteRenderer> ().bounds;
		newX = previousBlock.position.x + boundsPrevious.size.x/2;


		//vamos instanciar newBlock, sem definir posição nem parent
		Transform newBlock = poolAux.createObject(BlocksPool, ref previousBlock).transform;


		//vamos mover currentX para a posição do meio do novo bloco, onde deve ser instanciada
		Bounds boundsNext = newBlock.GetComponent<SpriteRenderer> ().bounds;
		newX = newX + boundsNext.size.x/2;

		//posição
		newBlock.position = new Vector3 (newX, newBlock.position.y, newBlock.position.z);
//		newBlock.position = new Vector3 (newX, blocksPrefabs [index].position.y, blocksPrefabs [index].position.z);

		//parent, para se mover
		newBlock.SetParent (this.transform);

		//apagar toEraseBlock, o bem anterior
//		if (toEraseBlock != null) //só é null se for a primeira iteração
//			Destroy(toEraseBlock.gameObject);

		//e as modificações para a próxima iteração
//		toEraseBlock = previousBlock;
//		previousBlock = newBlock;

	}


//	public void putRandomBlock ()
//	{
//		int index = Random.Range (0, blocksPrefabs.Length); //com int, Range tem max exclusive
//
//		putBlock (index);
//	}


//	private void putBlock (int index)
//	{
//
//		//A posição currentX está no meio do bloco anterior
//		//Vamos mover meio bloco anterior para chegar ao seu fim
//		float newX;
//		Bounds boundsPrevious = previousBlock.GetComponent<SpriteRenderer> ().bounds;
//		newX = previousBlock.position.x + boundsPrevious.size.x/2;
//
//
//		//vamos instanciar newBlock, sem definir posição ainda
//		Transform newBlock = Instantiate (blocksPrefabs [index].gameObject).transform;
//
//
//		//vamos mover currentX para a posição do meio do novo bloco, onde deve ser instanciada
//		Bounds boundsNext = newBlock.GetComponent<SpriteRenderer> ().bounds;
//		newX = newX + boundsNext.size.x/2;
//
//		//posição
//		newBlock.position = new Vector3 (newX, blocksPrefabs [index].position.y, blocksPrefabs [index].position.z);
//
//		//parent, para se mover
//		newBlock.SetParent (this.transform);
//
//		//apagar toEraseBlock, o bem anterior
//		if (toEraseBlock != null) //só é null se for a primeira iteração
//			Destroy(toEraseBlock.gameObject);
//		
//		//e as modificações para a próxima iteração
//		toEraseBlock = previousBlock;
//		previousBlock = newBlock;
//
//	}


	// Update is called once per frame
	void Update () {


	}
}

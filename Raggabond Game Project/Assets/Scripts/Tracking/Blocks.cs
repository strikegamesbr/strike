using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//todo deletar os quarteirões que passaram


public class Blocks : MonoBehaviour {

	[SerializeField]
	private Transform[] blocksPrefabs;

	[SerializeField]
	private float startX = 12.9f;

	[SerializeField]
	private Transform player;

	private Transform previousBlock, toEraseBlock;





	// Use this for initialization
	void Start () {

		//vamos instanciar o bloco inicial
		Transform newBlock = Instantiate (blocksPrefabs [0].gameObject).transform;
		newBlock.position = new Vector3 (startX, blocksPrefabs [0].position.y, blocksPrefabs [0].position.z);
		newBlock.SetParent (this.transform);
		previousBlock = newBlock;
		toEraseBlock = null;

	}


	public void putRandomBlock ()
	{
		int index = Random.Range (0, blocksPrefabs.Length); //com int, Range tem max exclusive

		putBlock (index);
	}


	private void putBlock (int index)
	{

		//A posição currentX está no meio do bloco anterior
		//Vamos mover meio bloco anterior para chegar ao seu fim
		float newX;
		Bounds boundsPrevious = previousBlock.GetComponent<SpriteRenderer> ().bounds;
		newX = previousBlock.position.x + boundsPrevious.size.x/2;


		//vamos instanciar newBlock, sem definir posição ainda
		Transform newBlock = Instantiate (blocksPrefabs [index].gameObject).transform;


		//vamos mover currentX para a posição do meio do novo bloco, onde deve ser instanciada
		Bounds boundsNext = newBlock.GetComponent<SpriteRenderer> ().bounds;
		newX = newX + boundsNext.size.x/2;

		//posição
		newBlock.position = new Vector3 (newX, blocksPrefabs [index].position.y, blocksPrefabs [index].position.z);

		//parent, para se mover
		newBlock.SetParent (this.transform);

		//apagar toEraseBlock, o bem anterior
		if (toEraseBlock != null) //só é null se for a primeira iteração
			Destroy(toEraseBlock.gameObject);
		
		//e as modificações para a próxima iteração
		toEraseBlock = previousBlock;
		previousBlock = newBlock;

	}


	// Update is called once per frame
	void Update () {


	}
}

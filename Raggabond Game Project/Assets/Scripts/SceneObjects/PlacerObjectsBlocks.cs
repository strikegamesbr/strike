using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacerObjectsBlocks : MonoBehaviour {


	[SerializeField]
	private float startX = 12.9f;

	[SerializeField]
	private StageProgression stageProgression;
	[SerializeField]
	private Transform defaultParent; //por agora deve ser SceneObjectsManager

	private Transform previousObjBlock, toEraseObjBlock;

	//hierarchy daqui, então esta classe retornará um aleatório para a fase dada, e a outra classe colocará
	//no cenário, com algoritmo parecido com o dos blocos de casas, mas tirará todos os filhos dele e deixará
	//o SceneObjectsManager como parent, e daí setará para mudar a posição de acordo com o lane.


	// Use this for initialization
	void Start () {

		//vamos instanciar o bloco inicial
		Transform newBlock = stageProgression.getBlockOfObjects().transform;

		newBlock.position = new Vector3 (startX, newBlock.position.y, newBlock.position.z);
		previousObjBlock = newBlock;
		toEraseObjBlock = null;

		//cada objeto deverá ter SceneObjectsManager como parent, daí eles sairão de newblock
		Transform[] objects = newBlock.GetComponentsInChildren<Transform> ();
		foreach (Transform obj in objects) {
			obj.parent = defaultParent;
		}					


	}


	public void putObjectsBlock ()
	{


		//A posição currentX está no meio do bloco anterior
		//Vamos mover meio bloco anterior para chegar ao seu fim
		float newX;
		Bounds boundsPrevious = previousObjBlock.GetComponent<SpriteRenderer> ().bounds;
		newX = previousObjBlock.position.x + boundsPrevious.size.x/2;


		//vamos instanciar newBlock, sem definir posição ainda
		Transform newBlock = stageProgression.getBlockOfObjects().transform;


		//vamos mover currentX para a posição do meio do novo bloco, onde deve ser instanciada
		Bounds boundsNext = newBlock.GetComponent<SpriteRenderer> ().bounds;
		newX = newX + boundsNext.size.x/2;

		//posição
		newBlock.position = new Vector3 (newX, newBlock.position.y, newBlock.position.z);


		//cada objeto deverá ter SceneObjectsManager como parent, daí eles sairão de newblock
		Transform[] objects = newBlock.GetComponentsInChildren<Transform> ();
		foreach (Transform obj in objects) {
			obj.parent = defaultParent;
		}

		//apagar toEraseBlock, o bem anterior
		if (toEraseObjBlock != null) //só é null se for a primeira iteração
			Destroy(toEraseObjBlock.gameObject);


		//e as modificações para a próxima iteração
		toEraseObjBlock = previousObjBlock;
		previousObjBlock = newBlock;


	}




	
	// Update is called once per frame
	void Update () {
		
	}
}

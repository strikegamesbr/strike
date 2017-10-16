using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacerObjectsBlocks : MonoBehaviour {

	[SerializeField]
	private PoolingAux poolAux;

	[SerializeField]
	private float startX = 40f;

	private ScnObjManager scnObjMan;

	[SerializeField]
	private StageProgression stageProgression;

	[SerializeField]
	private Transform defaultParent; //por agora deve ser SceneObjectsManager

	private Transform previousObjBlock;//, toEraseObjBlock;

	[SerializeField]
	private GameObject[] stage1ObstaclesPrefab, stage2ObstaclesPrefab, stage3ObstaclesPrefab, stage4ObstaclesPrefab, stage5ObstaclesPrefab, 
	stage6ObstaclesPrefab, stage7ObstaclesPrefab, stage8ObstaclesPrefab, stage9ObstaclesPrefab;

	private GameObject[] stage1Obstacles, stage2Obstacles, stage3Obstacles, stage4Obstacles, stage5Obstacles, 
						stage6Obstacles, stage7Obstacles, stage8Obstacles, stage9Obstacles;



	void Start() {

		scnObjMan = GetComponent<ScnObjManager> ();

		//vamos instanciar cada bloco, cada stageObstacles será um pool de sua respectiva fase
		//lembre-se que eles são instanciados com null como parent
		if (stageProgression.LastStage >= 1) {
			InstantiateStageObstaclesFromPrefab (ref stage1Obstacles, stage1ObstaclesPrefab);
		}

		if (stageProgression.LastStage >= 2) {
			InstantiateStageObstaclesFromPrefab (ref stage2Obstacles, stage2ObstaclesPrefab);
		}

		if (stageProgression.LastStage >= 3) {
			InstantiateStageObstaclesFromPrefab (ref stage3Obstacles, stage3ObstaclesPrefab);
		}

		if (stageProgression.LastStage >= 4) {
			InstantiateStageObstaclesFromPrefab (ref stage4Obstacles, stage4ObstaclesPrefab);
		}

		if (stageProgression.LastStage >= 5) {
			InstantiateStageObstaclesFromPrefab (ref stage5Obstacles, stage5ObstaclesPrefab);
		}

		if (stageProgression.LastStage >= 6) {
			InstantiateStageObstaclesFromPrefab (ref stage6Obstacles, stage6ObstaclesPrefab);
		}

		if (stageProgression.LastStage >= 7) {
			InstantiateStageObstaclesFromPrefab (ref stage7Obstacles, stage7ObstaclesPrefab);
		}

		if (stageProgression.LastStage >= 8) {
			InstantiateStageObstaclesFromPrefab (ref stage8Obstacles, stage8ObstaclesPrefab);
		}

		if (stageProgression.LastStage >= 9) {
			InstantiateStageObstaclesFromPrefab (ref stage9Obstacles, stage9ObstaclesPrefab);
		}
		//precisa deste "estado" inicial
		if (!GetComponent<ScnObjManager> ().EmptyStreetsForTesting)
			placeFirstObjBlock ();	

	}


	private void InstantiateStageObstaclesFromPrefab(ref GameObject[] stageObstacles, GameObject[] stageObstaclesPrefab)
	{

		int length = 0; 

		if (stageProgression.LastStage >= 1) {
			length = stageObstaclesPrefab.Length;
			stageObstacles = new GameObject[length];
			for (int i = 0; i < length; i++) {
				stageObstacles [i] = Instantiate (stageObstaclesPrefab [i]);

				//precisamos setar o parent original para poder retornar
				stageObstacles [i].SetActive (true);
				foreach (Transform obj in stageObstacles [i].transform) {
					//se não for um é outro
					try {
						obj.GetComponent<HurtfulScnObj> ().OriginalParent = obj.parent;
					} catch {
						try {
							obj.GetComponent<PointfulScnObj> ().OriginalParent = obj.parent;	
						} catch {
						}
					}

				}
				stageObstacles [i].transform.parent = defaultParent;
				stageObstacles [i].SetActive (false);
			}
		}


	}


	private void placeFirstObjBlock ()
	{
		//vamos instanciar o bloco inicial
		Transform newBlock = stage1Obstacles [Random.Range (0, stage1Obstacles.Length)].transform;

		//para a posição abaixo funcionar
		newBlock.parent = null;

		newBlock.position = new Vector3 (startX, newBlock.position.y, newBlock.position.z);

		newBlock.gameObject.SetActive (true);

		previousObjBlock = newBlock;

		newBlock.parent = defaultParent;

	}


	private GameObject[] getcurStageObstacles ()
	{
		print ("stageProgression.CurrentStage=" + stageProgression.CurrentStage);

		switch (stageProgression.CurrentStage) {
		case 1:
			return stage1Obstacles;
		case 2:
			return stage2Obstacles;
		case 3:
			return stage3Obstacles;
		case 4:
			return stage4Obstacles;
		case 5:
			return stage5Obstacles;
		case 6:
			return stage6Obstacles;
		case 7:
			return stage7Obstacles;
		case 8:
			return stage8Obstacles;
		case 9:
			return stage9Obstacles;
		default:
			return null;
		}

	}


	public void putObjectsBlock ()
	{
		//para manipular as posições melhor
//		previousObjBlock.parent = null;

		//A posição currentX está no meio do bloco anterior
		//Vamos mover meio bloco anterior para chegar ao seu fim
		float newX;
		Bounds boundsPrevious = previousObjBlock.GetComponent<SpriteRenderer> ().bounds;
		newX = previousObjBlock.position.x + boundsPrevious.size.x/2;


		//vamos instanciar newBlock, sem definir posição ainda
//		Transform newBlock = stageProgression.getBlockOfObjects().transform;

		GameObject[] curStageObstacles = getcurStageObstacles ();
		print ("curStageObstacles = " + curStageObstacles);

		Transform newBlock = poolAux.createObject(getcurStageObstacles(), ref previousObjBlock).transform;
		//para manipular as posições melhor
//		newBlock.parent = null;


		print ("newBlock=" + newBlock);


		//vamos mover currentX para a posição do meio do novo bloco, onde deve ser instanciada
		Bounds boundsNext = newBlock.GetComponent<SpriteRenderer> ().bounds;
		newX = newX + boundsNext.size.x/2;


		//vamos reativar os objetos
		foreach (Transform child in newBlock)
			child.gameObject.SetActive (true);


//		Transform[] objectsBlocksAll = defaultParent.GetComponentsInChildren<Transform> (true);
//
//		foreach (Transform blocksObj in objectsBlocksAll) {	
//
//			Transform[] objects = blocksObj.GetComponentsInChildren<Transform> (true);
//
//			foreach (Transform tObj in objects)
//				tObj.gameObject.SetActive (true);
//		}



		//antes de mudar a posição vamos colocar cada objeto de volta a ser child dele
		//e ativá-lo
//		Transform[] objectsAll = defaultParent.GetComponentsInChildren<Transform> (true);
//
//		foreach (Transform obj in objectsAll) {	
//
//			//se não for um é outro
//			try {				
//				if (obj.GetComponent<HurtfulScnObj> ().OriginalParent == newBlock) {
//					obj.parent = newBlock;
////					scnObjMan.simulActivInactivObj (obj.gameObject, true);
//					obj.gameObject.SetActive(true);
//				}
//
//			} catch {	
//				try {	
//					if (obj.GetComponent<PointfulScnObj> ().OriginalParent == newBlock) {
//						obj.parent = newBlock;
////						scnObjMan.simulActivInactivObj (obj.gameObject, true);
//						obj.gameObject.SetActive(true);
//					}
//				} catch {
//				}
//			}
//
//		}

		//posição
		newBlock.position = new Vector3 (newX, newBlock.position.y, newBlock.position.z);

		newBlock.parent = defaultParent;


		//cada objeto deverá ter SceneObjectsManager como parent, daí eles sairão de newblock
//		Transform[] objects = newBlock.GetComponentsInChildren<Transform> (true);
//		foreach (Transform obj in objects) {			
//			obj.parent = defaultParent;
//		}

//		//apagar toEraseBlock, o bem anterior
//		if (toEraseObjBlock != null) //só é null se for a primeira iteração
//			Destroy(toEraseObjBlock.gameObject);
//
//
//		//e as modificações para a próxima iteração
//		toEraseObjBlock = previousObjBlock;
//		previousObjBlock = newBlock;


	}




	
	// Update is called once per frame
	void Update () {


//		print ("previousObjBlock=" + previousObjBlock);

	}
}

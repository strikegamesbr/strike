using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//tem a descrição de cada bloco de obstáculos, com as posições x e lanes de cada objeto
public class BlockOfObjects : MonoBehaviour {

	ObjectsPool objectsPool;
	StageProgression stageProgression;

	[SerializeField]
	Transform MoreObjBlockTrigger;


	//a ordem em que os objetos estão nos array importam - são os que aparecem primeiro
	private ObjectInBlock[] objectsInBlock1, objectsInBlock2, objectsInBlock3, objectsInBlock4, objectsInBlock5, 
							objectsInBlock6, objectsInBlock7, objectsInBlock8, objectsInBlock9;

	//um para cada um dos nove blocos
	private float[] ObjBlockLength = {69.5f, 70.5f, 68.2f}; //deverá ter 9 depois

//	[SerializeField]
//	private float startXOfBlock = 40;

	[SerializeField]
	private Transform startXOfBlock;



	private float nextOffsetStartXOfBlock= 0;



	Coroutine[] curCoroutines;


	// Use this for initialization
	void Start () {

		objectsPool = FindObjectOfType<ObjectsPool> ();
		stageProgression = FindObjectOfType<StageProgression> ();

		//vamos listar abaixo os blocos de obstáculos, em suas versões em script

		//bloco1
		objectsInBlock1 = new ObjectInBlock[19];
		objectsInBlock1[0] = new ObjectInBlock (kindObj.coin, 2.4f, Lane.lower);
		objectsInBlock1[1] = new ObjectInBlock(kindObj.coin, 2.4f, Lane.middle);
		objectsInBlock1[2] = new ObjectInBlock(kindObj.cone, 10.6f, Lane.middle);
		objectsInBlock1[3] = new ObjectInBlock(kindObj.cone, 12.7f, Lane.lower);
		objectsInBlock1[4] = new ObjectInBlock(kindObj.skatista, 20.3f, Lane.upper);
		objectsInBlock1[5] = new ObjectInBlock(kindObj.cone, 22f, Lane.middle);
		objectsInBlock1[6] = new ObjectInBlock(kindObj.lilMario, 29.3f, Lane.upper);
		objectsInBlock1[7] = new ObjectInBlock(kindObj.skatista, 29.4f, Lane.lower);
		objectsInBlock1[8] = new ObjectInBlock(kindObj.coin, 35.3f, Lane.lower);
		objectsInBlock1[9] = new ObjectInBlock(kindObj.coin, 38.4f, Lane.lower);
		objectsInBlock1[10] = new ObjectInBlock(kindObj.coin, 41.4f, Lane.lower);
		objectsInBlock1[11] = new ObjectInBlock(kindObj.coin, 43.7f, Lane.upper);
		objectsInBlock1[12] = new ObjectInBlock(kindObj.coin, 46.4f, Lane.upper);
		objectsInBlock1[13] = new ObjectInBlock(kindObj.coin, 48.8f, Lane.upper);
		objectsInBlock1[14] = new ObjectInBlock(kindObj.lilMario, 51.7f, Lane.upper);
		objectsInBlock1[15] = new ObjectInBlock(kindObj.cone, 54.5f, Lane.middle);
		objectsInBlock1[16] = new ObjectInBlock(kindObj.cone, 57f, Lane.lower);
		objectsInBlock1[17] = new ObjectInBlock(kindObj.skatista, 65.6f, Lane.upper);
		objectsInBlock1[18] = new ObjectInBlock(kindObj.lilMario, 68.9f, Lane.lower);


//		print ("Testando: objectsInBlock1[0].KindOfObject = " + objectsInBlock1[0].KindOfObject);


		//bloco2
		objectsInBlock2 = new ObjectInBlock[19];
		objectsInBlock2[0] = new ObjectInBlock (kindObj.skatista, 6.8f, Lane.upper);
		objectsInBlock2[1] = new ObjectInBlock(kindObj.skatista, 9.5f, Lane.lower);
		objectsInBlock2[2] = new ObjectInBlock(kindObj.lilMario, 15.2f, Lane.upper);
		objectsInBlock2[3] = new ObjectInBlock(kindObj.cone, 17.1f, Lane.middle);
		objectsInBlock2[4] = new ObjectInBlock(kindObj.cone, 19.8f, Lane.middle);
		objectsInBlock2[5] = new ObjectInBlock(kindObj.coin, 24.7f, Lane.middle);
		objectsInBlock2[6] = new ObjectInBlock(kindObj.coin, 27.2f, Lane.middle);
		objectsInBlock2[7] = new ObjectInBlock(kindObj.coin, 29.5f, Lane.middle);
		objectsInBlock2[8] = new ObjectInBlock(kindObj.coin, 32.5f, Lane.lower);
		objectsInBlock2[9] = new ObjectInBlock(kindObj.coin, 35.2f, Lane.lower);
		objectsInBlock2[10] = new ObjectInBlock(kindObj.coin, 37.7f, Lane.lower);
		objectsInBlock2[11] = new ObjectInBlock(kindObj.skatista, 39.7f, Lane.upper);
		objectsInBlock2[12] = new ObjectInBlock(kindObj.lilMario, 41.5f, Lane.middle);
		objectsInBlock2[13] = new ObjectInBlock(kindObj.skatista, 42.8f, Lane.lower);
		objectsInBlock2[14] = new ObjectInBlock(kindObj.cone, 49.9f, Lane.middle);
		objectsInBlock2[15] = new ObjectInBlock(kindObj.cone, 52.6f, Lane.middle);
		objectsInBlock2[16] = new ObjectInBlock(kindObj.guitar, 57.5f, Lane.middle);
		objectsInBlock2[17] = new ObjectInBlock(kindObj.skatista, 65.9f, Lane.upper);
		objectsInBlock2[18] = new ObjectInBlock(kindObj.skatista, 68.6f, Lane.lower);

		//bloco3
		objectsInBlock3 = new ObjectInBlock[21];
		objectsInBlock3[0] = new ObjectInBlock (kindObj.coin, 2.4f, Lane.upper);
		objectsInBlock3[1] = new ObjectInBlock(kindObj.coin, 4.6f, Lane.lower);
		objectsInBlock3[2] = new ObjectInBlock(kindObj.coin, 7f, Lane.upper);
		objectsInBlock3[3] = new ObjectInBlock(kindObj.cone, 18.5f, Lane.middle);
		objectsInBlock3[4] = new ObjectInBlock(kindObj.cone, 18.5f, Lane.middle);
		objectsInBlock3[5] = new ObjectInBlock(kindObj.coin, 24.5f, Lane.middle);
		objectsInBlock3[6] = new ObjectInBlock(kindObj.coin, 26.9f, Lane.middle);
		objectsInBlock3[7] = new ObjectInBlock(kindObj.coin, 28.9f, Lane.middle);
		objectsInBlock3[8] = new ObjectInBlock(kindObj.coin, 31.3f, Lane.lower);
		objectsInBlock3[9] = new ObjectInBlock(kindObj.coin, 33.8f, Lane.lower);
		objectsInBlock3[10] = new ObjectInBlock(kindObj.coin, 36.2f, Lane.lower);
		objectsInBlock3[11] = new ObjectInBlock(kindObj.lilMario, 40.3f, Lane.upper);
		objectsInBlock3[12] = new ObjectInBlock(kindObj.skatista, 41.2f, Lane.middle);
		objectsInBlock3[13] = new ObjectInBlock(kindObj.skatista, 42f, Lane.lower);
		objectsInBlock3[14] = new ObjectInBlock(kindObj.skatista, 48.6f, Lane.middle);
		objectsInBlock3[15] = new ObjectInBlock(kindObj.skatista, 53f, Lane.middle);
		objectsInBlock3[16] = new ObjectInBlock(kindObj.skatista, 55.4f, Lane.middle);
		objectsInBlock3[17] = new ObjectInBlock(kindObj.coin, 57.7f, Lane.upper);
		objectsInBlock3[18] = new ObjectInBlock(kindObj.coin, 60.3f, Lane.lower);
		objectsInBlock3[19] = new ObjectInBlock(kindObj.coin, 63.3f, Lane.upper);
		objectsInBlock3[20] = new ObjectInBlock(kindObj.lilMario, 68f, Lane.lower);

	}

	// Update is called once per frame
	void Update () {
		
	}

	//vamos descobrir a fase que está, gerar whichBlocksOfObjects e chamar o método com esta informação
	public void placeObstaclesOnScene ()
	{

//		print ("placeObstaclesOnScene ()");

		Debug.Assert (stageProgression.CurrentStage >= 1 && stageProgression.CurrentStage <= 4);

		int[] whichBlocksOfObjects;

		switch (stageProgression.CurrentStage) {

		case 1:
			whichBlocksOfObjects = new int[] {1,2,3};
			break;
		case 2:
			whichBlocksOfObjects = new int[] {4,5};
			break;
		case 3:
			whichBlocksOfObjects = new int[] {6,7};
			break;
		case 4:
			whichBlocksOfObjects = new int[]{8,9};
			break;
		default: //se não for um de cima, está errado
			return;

		}

		Debug.Log ("whichBlocksOfObjects="+whichBlocksOfObjects);

		placeObstaclesOnScene (whichBlocksOfObjects);

	}


	//coloca na fase um dos blocos de obstáculos informados em número por whichBlocksOfObjects
	public void placeObstaclesOnScene (int[] whichBlocksOfObjects) 
	{
		StartCoroutine (placeObstaclesOnSceneRoutine (whichBlocksOfObjects));
	}


	IEnumerator placeObstaclesOnSceneRoutine (int[] whichBlocksOfObjects)
	{
		//vamos escolher uma entre as opções de blocos dadas aleatoriamente
		int numBlock = whichBlocksOfObjects[Random.Range(0, whichBlocksOfObjects.Length)];

		print ("numBlock=" + numBlock);


		ObjectInBlock[] blockObjToPlace;

		switch (numBlock) {

		case 1:
			blockObjToPlace = objectsInBlock1;
			break;
		case 2:
			blockObjToPlace = objectsInBlock2;
			break;
		case 3:
			blockObjToPlace = objectsInBlock3;
			break;
		case 4:
			blockObjToPlace = objectsInBlock4;
			break;
		case 5:
			blockObjToPlace = objectsInBlock5;
			break;
		case 6:
			blockObjToPlace = objectsInBlock6;
			break;
		case 7:
			blockObjToPlace = objectsInBlock7;
			break;
		case 8:
			blockObjToPlace = objectsInBlock8;
			break;
		case 9:
			blockObjToPlace = objectsInBlock9;
			break;
		default: //se não for um de cima, está errado
			blockObjToPlace = new ObjectInBlock[0];
			break;
		}

		Debug.Assert (blockObjToPlace.Length != 0);


		//vamos mover o "cursor" startXOfBlock
		startXOfBlock.position = startXOfBlock.position + new Vector3 (nextOffsetStartXOfBlock,0,0);

//		print ("numBlock=" + numBlock);
		//e atualizar nextOffsetStartXOfBlock para o próximo bloco
		nextOffsetStartXOfBlock = ObjBlockLength[numBlock-1];

		//e vamos mover o trigger MoreObjBlockTrigger
		MoreObjBlockTrigger.position = MoreObjBlockTrigger.position + new Vector3(ObjBlockLength[numBlock-1] * 4/5, 0, 0);


		//vamos matar as corotinas anteriores, se houver
		if (curCoroutines != null) {
			foreach (Coroutine coroutine in curCoroutines) {
				try {
					StopCoroutine (coroutine);
				} catch {
				}
			}
		}

		print ("blockObjToPlace.Length=" + blockObjToPlace.Length);

		//vamos guardar as novas corotinas
		curCoroutines = new Coroutine[blockObjToPlace.Length];



		for (int i = 0; i < blockObjToPlace.Length; i++) {		
			//todo aumentar	startXOfBlock matando as corotinas - na hora que chama outro? depois de um tempo?
			curCoroutines[i] = StartCoroutine(putObjectFromPool (blockObjToPlace [i]));
			yield return new WaitForEndOfFrame (); //para dar preferência aos primeiros objetos, vamos chamar eles antes, dando este espeço de tempo
		}

	}


	IEnumerator putObjectFromPool (ObjectInBlock objToBlock)
	{

		GameObject gObject;

//		print ("tentando " + objToBlock.KindOfObject );

		do {
			gObject = objectsPool.getObject (objToBlock.KindOfObject);
			yield return new WaitForEndOfFrame (); 
		} while (gObject == null); //significa que não achou um objeto invisível ainda, tenta de novo


//		print ("pegou " + gObject.name );

		gObject.SetActive(true);

//		print ("position=" + (startXOfBlock + objToBlock.X));
//		print ("startXOfBlock = " + startXOfBlock);
//		print ("objToBlock.X = " + objToBlock.X);

		gObject.transform.position = new Vector3 (startXOfBlock.position.x + objToBlock.X, gObject.transform.position.y, gObject.transform.position.z);
		changeLaneOfObject (gObject, objToBlock.Lane);

	}


	private void changeLaneOfObject (GameObject gObject, Lane lane) 
	{

		SceneObjects sceneObjects; //pode ser PointfulScnObj ou HurtfulScnObj em gObject
		sceneObjects = gObject.GetComponent<PointfulScnObj> () as SceneObjects;
		if (sceneObjects == null)
			sceneObjects = gObject.GetComponent<HurtfulScnObj> () as SceneObjects;

		//se não pegou um PointfulScnObj nem um HurtfulScnObj algo está errado
		Debug.Assert (sceneObjects != null);

		sceneObjects.Lane = lane;

	}



	private class ObjectInBlock {

		private kindObj kindObj;
		private float posX;
		private Lane lane;


		public ObjectInBlock (kindObj kindOfObj, float posXFrom0, Lane laneObj) {

			kindObj = kindOfObj;
			posX = posXFrom0;
			lane = laneObj;

		}


		public kindObj KindOfObject {
			
			get {
				return kindObj;
			}

//			set {
//				kindObj = value;
//			}
		}


		public float X {

			get {
				return posX;
			}

//			set {
//				posX = value;
//			}

		}

		public Lane Lane {
			get {
				return lane;
			}

//			set {
//				lane = value;
//			}
		}

	}


}


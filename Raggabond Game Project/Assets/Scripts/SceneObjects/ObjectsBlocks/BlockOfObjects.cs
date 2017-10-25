using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//tem a descrição de cada bloco de obstáculos, com as posições x e lanes de cada objeto
public class BlockOfObjects : MonoBehaviour {



	[SerializeField]
	public bool EmptyStreetsForTesting = false, divideBlocksByTwo = false, divideBlocksByFour = false;

	ObjectsPool objectsPool;
	StageProgression stageProgression;
	DebuggingRag debug;

	[SerializeField]
	Transform MoreObjBlockTrigger;


	//a ordem em que os objetos estão nos array importam - são os que aparecem primeiro
	private ObjectInBlock[] objectsInBlock1, objectsInBlock2, objectsInBlock3, objectsInBlock4, objectsInBlock5, 
							objectsInBlock6, objectsInBlock7, objectsInBlock8, objectsInBlock9;

	//um para cada um dos nove blocos
	private float[] ObjBlockLength = {69.5f, 70.5f, 68.2f, 71.5f, 70.28f, 69.1f, 69.1f, 70.2f, 71.84f}; //deverá ter 9 depois

//	[SerializeField]
//	private float startXOfBlock = 40;

	[SerializeField]
	private Transform startXOfBlock;


	private float nextOffsetStartXOfBlock= 0;


	Coroutine[] curCoroutines;
	 

	// Use this for initialization
	void Start () {

		GameSettings settings = FindObjectOfType <GameSettings> ();
		debug = FindObjectOfType<DebuggingRag>();

		EmptyStreetsForTesting = settings.emptyStrees;
		divideBlocksByTwo = settings.divideObstaclesBlocksBy2;
		divideBlocksByFour = settings.divideObstaclesBlocksBy4;


		if (EmptyStreetsForTesting) //se no editor colocar true não vão aparecer obstáculos
			MoreObjBlockTrigger.gameObject.SetActive (false);


		objectsPool = FindObjectOfType<ObjectsPool> ();
		stageProgression = FindObjectOfType<StageProgression> ();

		//vamos listar abaixo os blocos de obstáculos, em suas versões em script

		//tanto divideBlocksByFour quanto divideBlocksByTwo são selecionados no editor do Unity
		if (divideBlocksByFour) { //dividir por 4 tem preferência, mesmo se divideBlocksByTwo também estiver dividido
			objectsInBlock1 = new ObjectInBlock[5];
			objectsInBlock2 = new ObjectInBlock[5];
			objectsInBlock3 = new ObjectInBlock[5];
		} else if (divideBlocksByTwo) {
			objectsInBlock1 = new ObjectInBlock[10];
			objectsInBlock2 = new ObjectInBlock[10];
			objectsInBlock3 = new ObjectInBlock[10];
		} else { //nenhum dos dois acima está ligado
			objectsInBlock1 = new ObjectInBlock[19];
			objectsInBlock2 = new ObjectInBlock[19];
			objectsInBlock3 = new ObjectInBlock[21];
		}


		//bloco1

		objectsInBlock1 [0] = new ObjectInBlock (kindObj.coin, 2.4f, Lane.lower);
		objectsInBlock1 [1] = new ObjectInBlock (kindObj.coin, 2.4f, Lane.middle);
		objectsInBlock1 [2] = new ObjectInBlock (kindObj.cone, 10.6f, Lane.middle);
		objectsInBlock1 [3] = new ObjectInBlock (kindObj.cone, 12.7f, Lane.lower);
		objectsInBlock1 [4] = new ObjectInBlock (kindObj.skatista, 20.3f, Lane.upper);

		if (!divideBlocksByFour) {
			objectsInBlock1 [5] = new ObjectInBlock (kindObj.cone, 22f, Lane.middle);
			objectsInBlock1 [6] = new ObjectInBlock (kindObj.lilMario, 29.3f, Lane.upper);
			objectsInBlock1 [7] = new ObjectInBlock (kindObj.skatista, 29.4f, Lane.lower);
			objectsInBlock1 [8] = new ObjectInBlock (kindObj.coin, 35.3f, Lane.lower);
			objectsInBlock1 [9] = new ObjectInBlock (kindObj.coin, 38.4f, Lane.lower);

			if (!divideBlocksByTwo) {
				objectsInBlock1 [10] = new ObjectInBlock (kindObj.coin, 41.4f, Lane.lower);
				objectsInBlock1 [11] = new ObjectInBlock (kindObj.coin, 43.7f, Lane.upper);
				objectsInBlock1 [12] = new ObjectInBlock (kindObj.coin, 46.4f, Lane.upper);
				objectsInBlock1 [13] = new ObjectInBlock (kindObj.coin, 48.8f, Lane.upper);
				objectsInBlock1 [14] = new ObjectInBlock (kindObj.lilMario, 51.7f, Lane.upper);
				objectsInBlock1 [15] = new ObjectInBlock (kindObj.cone, 54.5f, Lane.middle);
				objectsInBlock1 [16] = new ObjectInBlock (kindObj.cone, 57f, Lane.lower);
				objectsInBlock1 [17] = new ObjectInBlock (kindObj.skatista, 65.6f, Lane.upper);
				objectsInBlock1 [18] = new ObjectInBlock (kindObj.lilMario, 68.9f, Lane.lower);
			}
		}


		//bloco2

		objectsInBlock2 [0] = new ObjectInBlock (kindObj.skatista, 6.8f, Lane.upper);
		objectsInBlock2 [1] = new ObjectInBlock (kindObj.skatista, 9.5f, Lane.lower);
		objectsInBlock2 [2] = new ObjectInBlock (kindObj.lilMario, 15.2f, Lane.upper);
		objectsInBlock2 [3] = new ObjectInBlock (kindObj.cone, 17.1f, Lane.middle);
		objectsInBlock2 [4] = new ObjectInBlock (kindObj.cone, 19.8f, Lane.middle);

		if (!divideBlocksByFour) {
			
			objectsInBlock2 [5] = new ObjectInBlock (kindObj.coin, 24.7f, Lane.middle);
			objectsInBlock2 [6] = new ObjectInBlock (kindObj.coin, 27.2f, Lane.middle);
			objectsInBlock2 [7] = new ObjectInBlock (kindObj.coin, 29.5f, Lane.middle);
			objectsInBlock2 [8] = new ObjectInBlock (kindObj.coin, 32.5f, Lane.lower);
			objectsInBlock2 [9] = new ObjectInBlock (kindObj.coin, 35.2f, Lane.lower);

			if (!divideBlocksByTwo) {

				objectsInBlock2 [10] = new ObjectInBlock (kindObj.coin, 37.7f, Lane.lower);
				objectsInBlock2 [11] = new ObjectInBlock (kindObj.skatista, 39.7f, Lane.upper);
				objectsInBlock2 [12] = new ObjectInBlock (kindObj.lilMario, 41.5f, Lane.middle);
				objectsInBlock2 [13] = new ObjectInBlock (kindObj.skatista, 42.8f, Lane.lower);
				objectsInBlock2 [14] = new ObjectInBlock (kindObj.cone, 49.9f, Lane.middle);
				objectsInBlock2 [15] = new ObjectInBlock (kindObj.cone, 52.6f, Lane.middle);
				objectsInBlock2 [16] = new ObjectInBlock (kindObj.guitar, 57.5f, Lane.middle);
				objectsInBlock2 [17] = new ObjectInBlock (kindObj.skatista, 65.9f, Lane.upper);
				objectsInBlock2 [18] = new ObjectInBlock (kindObj.skatista, 68.6f, Lane.lower);
			}

		}


		//bloco3

		objectsInBlock3 [0] = new ObjectInBlock (kindObj.coin, 2.4f, Lane.upper);
		objectsInBlock3 [1] = new ObjectInBlock (kindObj.coin, 4.6f, Lane.lower);
		objectsInBlock3 [2] = new ObjectInBlock (kindObj.coin, 7f, Lane.upper);
		objectsInBlock3 [3] = new ObjectInBlock (kindObj.cone, 18.5f, Lane.middle);
		objectsInBlock3 [4] = new ObjectInBlock (kindObj.cone, 18.5f, Lane.middle);

		if (!divideBlocksByFour) {

			objectsInBlock3 [5] = new ObjectInBlock (kindObj.coin, 24.5f, Lane.middle);
			objectsInBlock3 [6] = new ObjectInBlock (kindObj.coin, 26.9f, Lane.middle);
			objectsInBlock3 [7] = new ObjectInBlock (kindObj.coin, 28.9f, Lane.middle);
			objectsInBlock3 [8] = new ObjectInBlock (kindObj.coin, 31.3f, Lane.lower);
			objectsInBlock3 [9] = new ObjectInBlock (kindObj.coin, 33.8f, Lane.lower);

			if (!divideBlocksByTwo) {
				
				objectsInBlock3 [10] = new ObjectInBlock (kindObj.coin, 36.2f, Lane.lower);
				objectsInBlock3 [11] = new ObjectInBlock (kindObj.lilMario, 40.3f, Lane.upper);
				objectsInBlock3 [12] = new ObjectInBlock (kindObj.skatista, 41.2f, Lane.middle);
				objectsInBlock3 [13] = new ObjectInBlock (kindObj.skatista, 42f, Lane.lower);
				objectsInBlock3 [14] = new ObjectInBlock (kindObj.skatista, 48.6f, Lane.middle);
				objectsInBlock3 [15] = new ObjectInBlock (kindObj.skatista, 53f, Lane.middle);
				objectsInBlock3 [16] = new ObjectInBlock (kindObj.skatista, 55.4f, Lane.middle);
				objectsInBlock3 [17] = new ObjectInBlock (kindObj.coin, 57.7f, Lane.upper);
				objectsInBlock3 [18] = new ObjectInBlock (kindObj.coin, 60.3f, Lane.lower);
				objectsInBlock3 [19] = new ObjectInBlock (kindObj.coin, 63.3f, Lane.upper);
				objectsInBlock3 [20] = new ObjectInBlock (kindObj.lilMario, 68f, Lane.lower);
			}
		}

		//todo veja o comprimento total dos abaixo

		//bloco4

		objectsInBlock4 [0] = new ObjectInBlock (kindObj.coin, 3.027401f, Lane.middle);
		objectsInBlock4 [1] = new ObjectInBlock (kindObj.coin, 6.348396f, Lane.upper);
		objectsInBlock4 [2] = new ObjectInBlock (kindObj.cone, 13.46481f, Lane.middle);
		objectsInBlock4 [3] = new ObjectInBlock (kindObj.patinadora, 13.85552f, Lane.upper);
		objectsInBlock4 [4] = new ObjectInBlock (kindObj.skatista, 19.744f, Lane.upper);

		if (!divideBlocksByFour) {
			
			objectsInBlock4 [5] = new ObjectInBlock (kindObj.cone, 22.53475f, Lane.upper);
			objectsInBlock4 [6] = new ObjectInBlock (kindObj.skatista, 29.31627f, Lane.middle);
			objectsInBlock4 [7] = new ObjectInBlock (kindObj.lilMario, 29.31627f, Lane.upper);
			objectsInBlock4 [8] = new ObjectInBlock (kindObj.patinadora, 36.54432f, Lane.upper);
			objectsInBlock4 [9] = new ObjectInBlock (kindObj.coin, 35.65128f, Lane.lower);

			if (!divideBlocksByTwo) {
				
				objectsInBlock4 [10] = new ObjectInBlock (kindObj.coin, 38.35831f, Lane.lower);
				objectsInBlock4 [11] = new ObjectInBlock (kindObj.coin, 40.9537f, Lane.lower);
				objectsInBlock4 [12] = new ObjectInBlock (kindObj.coin, 43.24212f, Lane.upper);
				objectsInBlock4 [13] = new ObjectInBlock (kindObj.coin, 45.76f, Lane.upper);
				objectsInBlock4 [14] = new ObjectInBlock (kindObj.coin, 48.20966f, Lane.upper);
				objectsInBlock4 [15] = new ObjectInBlock (kindObj.patinadora, 49.29805f, Lane.lower);
				objectsInBlock4 [16] = new ObjectInBlock (kindObj.lilMario, 51.80972f, Lane.upper);
				objectsInBlock4 [17] = new ObjectInBlock (kindObj.cone, 53.5958f, Lane.upper);
				objectsInBlock4 [18] = new ObjectInBlock (kindObj.cone, 55.68887f, Lane.middle);
				objectsInBlock4 [19] = new ObjectInBlock (kindObj.skatista, 65.81929f, Lane.upper);
				objectsInBlock4 [20] = new ObjectInBlock (kindObj.lilMario, 70.03333f, Lane.middle);
			}

		}


		//bloco5

		objectsInBlock5 [0] = new ObjectInBlock (kindObj.patinadora, 10.55246f, Lane.lower);
		objectsInBlock5 [1] = new ObjectInBlock (kindObj.lilMario, 15.43068f, Lane.upper);
		objectsInBlock5 [2] = new ObjectInBlock (kindObj.cone, 17.07502f, Lane.middle);
		objectsInBlock5 [3] = new ObjectInBlock (kindObj.cone, 19.8156f, Lane.middle);
		objectsInBlock5 [4] = new ObjectInBlock (kindObj.coin, 25.0501f, Lane.middle);


		if (!divideBlocksByFour) {

			objectsInBlock5 [5] = new ObjectInBlock (kindObj.coin, 27.57143f, Lane.middle);
			objectsInBlock5 [6] = new ObjectInBlock (kindObj.coin, 30.22978f, Lane.middle);
			objectsInBlock5 [7] = new ObjectInBlock (kindObj.coin, 32.34003f, Lane.lower);
			objectsInBlock5 [8] = new ObjectInBlock (kindObj.coin, 34.94357f, Lane.lower);
			objectsInBlock5 [9] = new ObjectInBlock (kindObj.coin, 37.27306f, Lane.lower);


			if (!divideBlocksByTwo) {

				objectsInBlock5 [10] = new ObjectInBlock (kindObj.patinadora, 38.20486f, Lane.upper);
				objectsInBlock5 [11] = new ObjectInBlock (kindObj.lilMario, 41.86854f, Lane.middle);
				objectsInBlock5 [12] = new ObjectInBlock (kindObj.skatista, 43.20068f, Lane.lower);
				objectsInBlock5 [13] = new ObjectInBlock (kindObj.cone, 48.72866f, Lane.middle);
				objectsInBlock5 [14] = new ObjectInBlock (kindObj.cone, 51.32671f, Lane.middle);
				objectsInBlock5 [15] = new ObjectInBlock (kindObj.guitar, 57.5611f, Lane.middle);
				objectsInBlock5 [16] = new ObjectInBlock (kindObj.skatista, 65.33655f, Lane.upper);
				objectsInBlock5 [17] = new ObjectInBlock (kindObj.skatista, 68.4334f, Lane.lower);

			}

		}



		//bloco6

		objectsInBlock6 [0] = new ObjectInBlock (kindObj.coin, 2.134842f, Lane.middle);
		objectsInBlock6 [1] = new ObjectInBlock (kindObj.coin, 4.724455f, Lane.middle);
		objectsInBlock6 [2] = new ObjectInBlock (kindObj.coin, 7.314072f, Lane.middle);
		objectsInBlock6 [3] = new ObjectInBlock (kindObj.patinadora_var, 16.05402f, Lane.lower);
		objectsInBlock6 [4] = new ObjectInBlock (kindObj.cone, 18.72456f, Lane.lower);

		if (!divideBlocksByFour) {

			objectsInBlock6 [5] = new ObjectInBlock (kindObj.patinadora, 19.72264f, Lane.upper);
			objectsInBlock6 [6] = new ObjectInBlock (kindObj.coin, 24.90187f, Lane.middle);
			objectsInBlock6 [7] = new ObjectInBlock (kindObj.coin, 27.14081f, Lane.middle);
			objectsInBlock6 [8] = new ObjectInBlock (kindObj.coin, 29.4337f, Lane.middle);
			objectsInBlock6 [9] = new ObjectInBlock (kindObj.coin, 31.75356f, Lane.lower);

			if (!divideBlocksByTwo) {

				objectsInBlock6 [10] = new ObjectInBlock (kindObj.coin, 34.26225f, Lane.lower);
				objectsInBlock6 [11] = new ObjectInBlock (kindObj.coin, 36.55514f, Lane.lower);
				objectsInBlock6 [12] = new ObjectInBlock (kindObj.lilMario, 41.19487f, Lane.middle);
				objectsInBlock6 [13] = new ObjectInBlock (kindObj.skatista, 42.73245f, Lane.upper);
				objectsInBlock6 [14] = new ObjectInBlock (kindObj.skatista, 42.73245f, Lane.lower);
				objectsInBlock6 [15] = new ObjectInBlock (kindObj.patinadora_var, 50.87894f, Lane.middle);
				objectsInBlock6 [16] = new ObjectInBlock (kindObj.skatista, 53.68436f, Lane.middle);
				objectsInBlock6 [17] = new ObjectInBlock (kindObj.patinadora, 55.46472f, Lane.lower);
				objectsInBlock6 [18] = new ObjectInBlock (kindObj.coin, 58.16224f, Lane.middle);
				objectsInBlock6 [19] = new ObjectInBlock (kindObj.coin, 60.83278f, Lane.middle);
				objectsInBlock6 [20] = new ObjectInBlock (kindObj.coin, 63.55727f, Lane.middle);
				objectsInBlock6 [21] = new ObjectInBlock (kindObj.lilMario, 67.23956f, Lane.middle);
			}

		}



		//bloco7

		objectsInBlock7 [0] = new ObjectInBlock (kindObj.coin, 2.489441f, Lane.middle);
		objectsInBlock7 [1] = new ObjectInBlock (kindObj.coin, 4.700306f, Lane.middle);
		objectsInBlock7 [2] = new ObjectInBlock (kindObj.coin, 6.938129f, Lane.middle);
		objectsInBlock7 [3] = new ObjectInBlock (kindObj.patinadora_var, 16.4017f, Lane.lower);
		objectsInBlock7 [4] = new ObjectInBlock (kindObj.coin, 25.48781f, Lane.middle);

		if (!divideBlocksByFour) {

			objectsInBlock7 [5] = new ObjectInBlock (kindObj.coin, 27.94133f, Lane.middle);
			objectsInBlock7 [6] = new ObjectInBlock (kindObj.skatista_var, 29.586f, Lane.upper);
			objectsInBlock7 [7] = new ObjectInBlock (kindObj.coin, 30.44878f, Lane.middle);
			objectsInBlock7 [8] = new ObjectInBlock (kindObj.coin, 32.82141f, Lane.middle);
			objectsInBlock7 [9] = new ObjectInBlock (kindObj.lilMario, 40.15501f, Lane.middle);

			if (!divideBlocksByTwo) {

				objectsInBlock7 [10] = new ObjectInBlock (kindObj.skatista_var, 42.5546f, Lane.upper);
				objectsInBlock7 [11] = new ObjectInBlock (kindObj.skatista_var, 42.5546f, Lane.lower);
				objectsInBlock7 [12] = new ObjectInBlock (kindObj.patinadora_var, 47.4505f, Lane.middle);
				objectsInBlock7 [13] = new ObjectInBlock (kindObj.skatista, 52.71918f, Lane.middle);
				objectsInBlock7 [14] = new ObjectInBlock (kindObj.patinadora, 54.63346f, Lane.lower);
				objectsInBlock7 [15] = new ObjectInBlock (kindObj.coin, 57.94976f, Lane.middle);
				objectsInBlock7 [16] = new ObjectInBlock (kindObj.coin, 60.86702f, Lane.middle);
				objectsInBlock7 [17] = new ObjectInBlock (kindObj.coin, 63.74654f, Lane.middle);
				objectsInBlock7 [18] = new ObjectInBlock (kindObj.lilMario, 68.59966f, Lane.middle);

			}

		}


		//bloco8

		objectsInBlock8 [0] = new ObjectInBlock (kindObj.patinadora, 10.39273f, Lane.middle);
		objectsInBlock8 [1] = new ObjectInBlock (kindObj.lilMario, 15.07791f, Lane.upper);
		objectsInBlock8 [2] = new ObjectInBlock (kindObj.cone, 16.42045f, Lane.middle);
		objectsInBlock8 [3] = new ObjectInBlock (kindObj.cone, 20.11928f, Lane.middle);
		objectsInBlock8 [4] = new ObjectInBlock (kindObj.patinadora_var, 21.76321f, Lane.lower);

		if (!divideBlocksByFour) {

			objectsInBlock8 [5] = new ObjectInBlock (kindObj.coin, 25.28595f, Lane.middle);
			objectsInBlock8 [6] = new ObjectInBlock (kindObj.coin, 27.65394f, Lane.middle);
			objectsInBlock8 [7] = new ObjectInBlock (kindObj.coin, 30.03763f, Lane.middle);
			objectsInBlock8 [8] = new ObjectInBlock (kindObj.coin, 32.25693f, Lane.lower);
			objectsInBlock8 [9] = new ObjectInBlock (kindObj.coin, 34.53102f, Lane.lower);

			if (!divideBlocksByTwo) {

				objectsInBlock8 [10] = new ObjectInBlock (kindObj.coin, 36.94211f, Lane.lower);
				objectsInBlock8 [11] = new ObjectInBlock (kindObj.patinadora, 38.20246f, Lane.upper);
				objectsInBlock8 [12] = new ObjectInBlock (kindObj.lilMario, 41.5451f, Lane.middle);
				objectsInBlock8 [13] = new ObjectInBlock (kindObj.skatista, 42.96984f, Lane.lower);
				objectsInBlock8 [14] = new ObjectInBlock (kindObj.cone, 48.66878f, Lane.middle);
				objectsInBlock8 [15] = new ObjectInBlock (kindObj.skatista_var, 50.20311f, Lane.upper);
				objectsInBlock8 [16] = new ObjectInBlock (kindObj.cone, 51.35385f, Lane.middle);
				objectsInBlock8 [17] = new ObjectInBlock (kindObj.guitar, 57.18979f, Lane.middle);
				objectsInBlock8 [18] = new ObjectInBlock (kindObj.skatista, 65.08063f, Lane.upper);
				objectsInBlock8 [19] = new ObjectInBlock (kindObj.skatista_var, 67.08073f, Lane.lower);
			}

		}


		//bloco9

		objectsInBlock9 [0] = new ObjectInBlock (kindObj.coin, 3.146156f, Lane.lower);
		objectsInBlock9 [1] = new ObjectInBlock (kindObj.coin, 5.927999f, Lane.middle);
		objectsInBlock9 [2] = new ObjectInBlock (kindObj.cone, 12.17158f, Lane.middle);
		objectsInBlock9 [3] = new ObjectInBlock (kindObj.skatista_var, 14.04991f, Lane.middle);
		objectsInBlock9 [4] = new ObjectInBlock (kindObj.skatista_var, 18.3112f, Lane.upper);

		if (!divideBlocksByFour) {

			objectsInBlock9 [5] = new ObjectInBlock (kindObj.cone, 22.51641f, Lane.middle);
			objectsInBlock9 [6] = new ObjectInBlock (kindObj.lilMario, 29.60921f, Lane.upper);
			objectsInBlock9 [7] = new ObjectInBlock (kindObj.skatista_var, 32.10431f, Lane.lower);
			objectsInBlock9 [8] = new ObjectInBlock (kindObj.coin, 35.07599f, Lane.lower);
			objectsInBlock9 [9] = new ObjectInBlock (kindObj.coin, 37.76733f, Lane.lower);

			if (!divideBlocksByTwo) {

				objectsInBlock9 [10] = new ObjectInBlock (kindObj.coin, 40.62688f, Lane.lower);
				objectsInBlock9 [11] = new ObjectInBlock (kindObj.coin, 43.26215f, Lane.upper);
				objectsInBlock9 [12] = new ObjectInBlock (kindObj.coin, 45.57221f, Lane.upper);
				objectsInBlock9 [13] = new ObjectInBlock (kindObj.coin, 47.91592f, Lane.upper);
				objectsInBlock9 [14] = new ObjectInBlock (kindObj.lilMario, 51.86882f, Lane.upper);
				objectsInBlock9 [15] = new ObjectInBlock (kindObj.cone, 54.89658f, Lane.middle);
				objectsInBlock9 [16] = new ObjectInBlock (kindObj.patinadora_var, 57.36591f, Lane.lower);
				objectsInBlock9 [17] = new ObjectInBlock (kindObj.skatista_var, 66.39084f, Lane.upper);
				objectsInBlock9 [18] = new ObjectInBlock (kindObj.lilMario, 69.86714f, Lane.lower);

			}
		}
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

		debug.debugLog (7.01f);
//		Debug.Log ("Até agora definiu um conjunto de bloco de obstáculos baseado no estágio - (007.1)");
//		yield return new WaitForEndOfFrame(); //dar o tempo de dar o log


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

		debug.debugLog (7.02f);
//		Debug.Log ("E já escolheu o bloco em si - (007.2)");
//		yield return new WaitForEndOfFrame(); //dar o tempo de dar o log


		//vamos mover o "cursor" startXOfBlock
		startXOfBlock.position = startXOfBlock.position + new Vector3 (nextOffsetStartXOfBlock,0,0);

//		Debug.Log ("(007.3)");
		debug.debugLog (7.03f);
		//e atualizar nextOffsetStartXOfBlock para o próximo bloco
		nextOffsetStartXOfBlock = ObjBlockLength[numBlock-1];

		if (divideBlocksByTwo)
			nextOffsetStartXOfBlock = nextOffsetStartXOfBlock / 2;
		else if (divideBlocksByFour) 
			nextOffsetStartXOfBlock = nextOffsetStartXOfBlock / 4;


//		Debug.Log ("(007.4)");
		debug.debugLog (7.04f);
		//e vamos mover o trigger MoreObjBlockTrigger
		MoreObjBlockTrigger.position = MoreObjBlockTrigger.position + new Vector3(nextOffsetStartXOfBlock * 4/5, 0, 0);

//		Debug.Log ("(007.5)");
		debug.debugLog (7.05f);
		//vamos matar as corotinas anteriores, se houver
		if (curCoroutines != null) {
			foreach (Coroutine coroutine in curCoroutines) {
				try {
					StopCoroutine (coroutine);
				} catch {
				}
			}
		}

//		print ("blockObjToPlace.Length=" + blockObjToPlace.Length);
//		Debug.Log ("(007.6)");
		debug.debugLog (7.06f);
		//vamos guardar as novas corotinas
		curCoroutines = new Coroutine[blockObjToPlace.Length];


		for (int i = 0; i < blockObjToPlace.Length; i++) {	
			debug.debugLogWithindex (7.07f, i);
//			Debug.Log ("(007.7) [" + i + "]");
			//todo aumentar	startXOfBlock matando as corotinas - na hora que chama outro? depois de um tempo?
			curCoroutines[i] = StartCoroutine(putObjectFromPool (blockObjToPlace [i], i));
			yield return new WaitForEndOfFrame (); //para dar preferência aos primeiros objetos, vamos chamar eles antes, dando este espeço de tempo
//			yield return new WaitForSeconds(0.1f);

			debug.debugLogWithindex (7.12f, i);
//			Debug.Log ("(007.12) [" + i + "]");
		}

		debug.debugLog (7.13f);

//		Debug.Log ("(007.13)");
//		yield return null;
	}


	IEnumerator putObjectFromPool (ObjectInBlock objToBlock, int i) //o i é só para debug, não tem utilidade real aqui
	{

		debug.debugLogWithindex (7.08f, i);
//		Debug.Log ("(007.8) [" + i + "]");
		GameObject gObject;

		do {
			gObject = objectsPool.getObject (objToBlock.KindOfObject);
			yield return new WaitForEndOfFrame (); 
//			Debug.Log ("(007.9) [" + i + "] - veja se este aparece muito " + objToBlock.KindOfObject);
		} while (gObject == null); //significa que não achou um objeto invisível ainda, tenta de novo

		debug.debugLogWithindex (7.10f, i);
//		Debug.Log ("(007.10) [" + i + "]");
//		print ("pegou " + gObject.name );

		gObject.SetActive(true);

//		print ("position=" + (startXOfBlock + objToBlock.X));
//		print ("startXOfBlock = " + startXOfBlock);
//		print ("objToBlock.X = " + objToBlock.X);

		gObject.transform.position = new Vector3 (startXOfBlock.position.x + objToBlock.X, gObject.transform.position.y, gObject.transform.position.z);
		changeLaneOfObject (gObject, objToBlock.Lane);
		debug.debugLogWithindex (7.11f, i);
//		Debug.Log ("(007.11) [" + i + "]");
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

		}


		public float X {

			get {
				return posX;
			}

		}

		public Lane Lane {
			get {
				return lane;
			}
		}

	}


}


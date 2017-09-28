using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//todo criar um GameObject terray para cada fase, cada um com os blocos de objetos de uma fase, e colocar no 
//hierarchy daqui, então esta classe retornará um aleatório para a fase dada, e a outra classe colocará
//no cenário, com algoritmo parecido com o dos blocos de casas, mas tirará todos os filhos dele e deixará
//o SceneObjectsManager como parent, e daí setará para mudar a posição de acordo com o lane.

//as velocidades mudarão de acordo com a pontuação atual
//no começo será mais lento, quando chegar a determinada pontuação a velocidade aumentará, e isso ocorrerá novamente
public class StageProgression : MonoBehaviour {

	//velocidade para 
	// index: 0->começo da fase, 1->primeira mudança, 2->segunda mudança, e se houver mais, podem haver
	[SerializeField]
	private float[] normalSpeed, fastSpeed, slowSpeed;

	//pontuações que mudarão a velocidade
	//index: 0->vamos deixar a pontuação 0, para começo da fase, 1->primeira mudança, 2->segunda mudança, e se houver mais, podem haver
	[SerializeField]
	private ulong[] scoreToChangeSpeed;


	private Track track; //para mudar a velocidade
	[SerializeField]
	private PlayerState playerState; //para checar o score


//	[SerializeField]
//	private GameObjectArray[] stageObstaclesPrefabs;

	[SerializeField]
	private GameObject[] stage1ObstaclesPrefab, stage2ObstaclesPrefab, stage3ObstaclesPrefab, stage4ObstaclesPrefab, stage5ObstaclesPrefab, 
						 stage6ObstaclesPrefab, stage7ObstaclesPrefab, stage8ObstaclesPrefab, stage9ObstaclesPrefab;


	//vamos checar se a velocidade do jogador é a do índice indicado
	private bool isPlayerSpeedOfIndex(int index)
	{
		if (track.NormalSpeed == normalSpeed [index])
			return true;
		else
			return false;		
	}

	//retorna qual stage está
	//vai calcular baseado na pontuação atual
	public int numCurrentStage ()
	{
		//se o tamanho de scoreToChangeSpeed for 4, índices 0, 1, 2, 3
		//começa índice 1, se for menor que scoreToChangeSpeed[1] a fase é 1 (lembre-se que scoreToChangeSpeed[0] == 0), é o comecinho do jogo
		//se for menor que scoreToChangeSpeed[2] a fase é 2
		//se for menor que scoreToChangeSpeed[3] a fase é 3
		//se não for, saiu do for, a fase é 4, o tamanho de scoreToChangeSpeed

//		print ("0");
		for (int i = 1; i < scoreToChangeSpeed.Length; i++) {
//			print ("1");
//			print ("playerState.Score = " + playerState.Score + " scoreToChangeSpeed [i] = " + scoreToChangeSpeed [i]);
			if (playerState.Score < scoreToChangeSpeed [i]) {
//				print ("2");
				return i;
			}
		}
//		print ("3");
		return scoreToChangeSpeed.Length;

	}


	public GameObject getBlockOfObjects ()
	{

		GameObject[] blocks;

		switch (numCurrentStage ()) {

		case 1:
			blocks = stage1ObstaclesPrefab;
			break;
		case 2:
			blocks = stage2ObstaclesPrefab;
			break;
		case 3:
			blocks = stage3ObstaclesPrefab;
			break;
		case 4:
			blocks = stage4ObstaclesPrefab;
			break;
		case 5:
			blocks = stage5ObstaclesPrefab;
			break;
		case 6:
			blocks = stage6ObstaclesPrefab;
			break;
		case 7:
			blocks = stage7ObstaclesPrefab;
			break;
		case 8:
			blocks = stage8ObstaclesPrefab;
			break;
		case 9:
			blocks = stage9ObstaclesPrefab;
			break;
		default:
			blocks = null;
			break;
		}

		print ("blocks = " + blocks);


		GameObject objToReturn = Instantiate(blocks[Random.Range(0, blocks.Length)]);

		print ("objToReturn = " + objToReturn);


		return objToReturn; //retorna um dos valores de blocks, aleatoriamente Random.Range(0, blocks.Length)		 

	}



	// Use this for initialization
	void Start () {
		track = GetComponent<Track> ();
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = scoreToChangeSpeed.Length-1; i >= 0; i--) {

			if (playerState.Score >= scoreToChangeSpeed [i]) {

				if (!isPlayerSpeedOfIndex(i)) {
//					print ("playerState.Score >= scoreToChangeSpeed [" + i + "]");
					track.DefaultNormalSpeed = normalSpeed [i];
					track.DefaultFastSpeed = fastSpeed [i];
					track.DefaultSlowSpeed = slowSpeed [i];
				} 
//				else print ("playerState.Score < scoreToChangeSpeed [" + i + "]");

				break;

			}

		}

	}
}

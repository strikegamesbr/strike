using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//todo criar um GameObject terray para cada fase, cada um com os blocos de objetos de uma fase, e colocar no 
//hierarchy daqui, então esta classe retornará um aleatório para a fase dada, e a outra classe colocará
//no cenário, com algoritmo parecido com o dos blocos de casas, mas tirará todos os filhos dele e deixará
//o SceneObjectsManager como parent, e daí setará para mudar a posição de acordo com o lane.

//as velocidades mudarão de acordo com a pontuação atual
//no começo será mais lento, quando chegar a determinada pontuação a velocidade aumentará, e isso ocorrerá novamente
public class Stage1Progression : MonoBehaviour {

	//velocidade para 
	// index: 0->começo da fase, 1->primeira mudança, 2->segunda mudança, e se houver mais, podem haver
	[SerializeField]
	private float[] normalSpeed, fastSpeed, slowSpeed;

	//pontuações que mudarão a velocidade
	//index: 0->vamos deixar a pontuação 0, para começo da fase, 1->primeira mudança, 2->segunda mudança, e se houver mais, podem haver
	[SerializeField]
	private ulong[] scoreToChangeSpeed;


	[SerializeField]
	private Track track; //para mudar a velocidade
	[SerializeField]
	private PlayerState playerState; //para checar o score


	[SerializeField]
	private GameObjectArray[] ObjectBlocksStage;




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
		for (int i = 1; i < scoreToChangeSpeed.Length; i++) {
			if (playerState.Score < scoreToChangeSpeed [i])
				return i;
		}

		return scoreToChangeSpeed.Length;

	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {




		for (int i = scoreToChangeSpeed.Length-1; i >= 0; i--) {

			if (playerState.Score >= scoreToChangeSpeed [i]) {

				if (!isPlayerSpeedOfIndex(i)) {
					print ("playerState.Score >= scoreToChangeSpeed [" + i + "]");
					track.DefaultNormalSpeed = normalSpeed [i];
					track.DefaultFastSpeed = fastSpeed [i];
					track.DefaultSlowSpeed = slowSpeed [i];
				} else print ("playerState.Score < scoreToChangeSpeed [" + i + "]");

				break;

			}

		}

	}
}

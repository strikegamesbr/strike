using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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



	//vamos checar se a velocidade do jogador é a do índice indicado
	private bool isPlayerSpeedOfIndex(int index)
	{
		if (track.NormalSpeed == normalSpeed [index])
			return true;
		else
			return false;		
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

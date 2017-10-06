using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingOnScreen : MonoBehaviour {


	private fillingPlayersList fillPlyList;

	[SerializeField]
	private Transform[] backNameImages;

	private Text[] namesTextUI, scoresTextUI;


	// Use this for initialization
	void Start () {

		fillPlyList = GetComponent<fillingPlayersList> ();

		//vamos associar namesTextUI e scoresTextUI aos seus respectivos Texts na tela
		namesTextUI = new Text[backNameImages.Length];
		scoresTextUI = new Text[backNameImages.Length];

		for (int i = 0; i < backNameImages.Length; i++) {
			namesTextUI [i] = backNameImages [i].Find ("Name").GetComponent<Text>();
			scoresTextUI [i] = backNameImages [i].Find ("Score").GetComponent<Text>();

		}

	}


	public void fillRankingOnScreen (positionPlayer[] leaderboardLoaded)
	{
		//esta variável vai nos mostrar se tem menos nomes no ranking online 
		//do que tem espaços para mostrar na tela 
		bool leaderboardLoadedHasFewNames;

		//primeiro vamos saber quantos valores de leaderboardLoaded são nulos, se houver
		//pois não vamos considerá-los para saber leaderboardLoadedHasFewNames
		int nullValuesInLeaderboardLoaded = 0;
		foreach (positionPlayer posPly in leaderboardLoaded) {
			if (posPly == null) {
				nullValuesInLeaderboardLoaded++;
			}
		}

		//agora vamos setar leaderboardLoadedHasFewNames corretamente
		if ((leaderboardLoaded.Length - nullValuesInLeaderboardLoaded) < backNameImages.Length)
			leaderboardLoadedHasFewNames = true;
		else 
			leaderboardLoadedHasFewNames = false;


		//primeiro vamos considerar o caso mais simples - quando leaderboardLoadedHasFewNames == false
		if (!leaderboardLoadedHasFewNames) {

			//mesmo que leaderboardLoaded venha com mais nomes, só os primeiros backNameImages.Length interessam
			for (int i = 0; i < backNameImages.Length; i++) {
				namesTextUI [i].text = string.Concat ((i + 1).ToString (), ": ", leaderboardLoaded [i].PlayerName);
				scoresTextUI [i].text = leaderboardLoaded [i].Score.ToString ();
			}

		} else {


			List<positionPlayer> listToShow = new List<positionPlayer> (fillPlyList.FillingPlayers);

			foreach (positionPlayer posPly in leaderboardLoaded) {
				if (posPly != null) {
					listToShow.Add (posPly);
				}
			}

			listToShow.Sort ();

			positionPlayer[] arrayToShow = listToShow.ToArray ();



			//mesmo que leaderboardLoaded venha com mais nomes, só os primeiros backNameImages.Length interessam
			for (int i = 0; i < backNameImages.Length; i++) {
				namesTextUI [i].text = string.Concat ((i + 1).ToString (), ": ", arrayToShow [i].PlayerName);
				scoresTextUI [i].text = arrayToShow [i].Score.ToString ();
			}


		}




	}







	
	// Update is called once per frame
	void Update () {
		
	}
}

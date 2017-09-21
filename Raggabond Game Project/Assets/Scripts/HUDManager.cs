using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	[SerializeField]
	private Text ScoreText;

	[SerializeField]
	private GameObject[] MarioLives;


	[SerializeField]
	private PlayerState playerState;



	// Use this for initialization
	void Start () {




		
	}
	
	// Update is called once per frame
	void Update () {

		//os pontos
		ScoreText.text = playerState.Score.ToString();

		//as vidas
		for (int i = 0; i < MarioLives.Length; i++) {

			if (playerState.Lives >= i + 1)
				MarioLives [i].SetActive (true);
			else
				MarioLives [i].SetActive (false);

		}



		
	}
}

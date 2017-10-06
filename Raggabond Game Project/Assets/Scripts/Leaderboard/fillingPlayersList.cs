using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//colocar nomes de jogadores para preencher a tela do ranking enquanto não tem jogadores de verdade
//preenchendo ali
public class fillingPlayersList : MonoBehaviour {

	[SerializeField]
	private positionPlayer[] fillingPlayers;

	public positionPlayer[] FillingPlayers {
		get {
			return fillingPlayers;
		}
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


using UnityEngine;
using System;
using System.Collections;

[System.Serializable]
public class positionPlayer: IComparable {

	[SerializeField]
	private string playerName;
	[SerializeField]
	private int score;


	public positionPlayer (string PlayerName, int Score)
	{
		playerName = PlayerName;
		score = Score;
	}


	public string PlayerName {
		get {
			return playerName;
		}
	}

	public int Score {
		get {
			return score;
		}
		set {
			score = value;
		}
	}


	//para ordenar esta classe
	public int CompareTo(System.Object obj)
	{
		
		positionPlayer objPP = (positionPlayer)obj;

		if (this != null && objPP != null)
			return (objPP.score - this.score);
		else if (this != null && objPP == null)
			return -1;
		else if (this == null && objPP != null)
			return 1;
		else //só sobra (xPP == null && yPP == null)
			return 0;

	}


}

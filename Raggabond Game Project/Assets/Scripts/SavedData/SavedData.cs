using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedData : MonoBehaviour {

	//observação: ainda não pega o score do servidor, então guarda o maior score desta instalãção somente

	public void saveScore (ulong score)
	{
		//só vai salvar se for maior do que o que já está salvo
		if (score > getScoreFromSave ()) {
			int intScore = (int)score;
			PlayerPrefs.SetInt ("score", intScore);
		}
	}


	public ulong getScoreFromSave ()
	{
		return (ulong) PlayerPrefs.GetInt ("score");
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
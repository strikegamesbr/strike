using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tem as mensagens de log que serão mostradas
public class DebuggingRag : MonoBehaviour {


	[SerializeField]
	private bool showLogs;


	// Use this for initialization
	void Start () {

		showLogs = FindObjectOfType<GameSettings> ().showLogs;

	}


	public void debugLog (float code)
	{
		//somente vai mostrar os logs se ligarmos showLogs
		if (showLogs) {

			string toLog = "";

			if (code == 1)
				toLog = "A cena começou - (001)";
			else if (code == 2)
				toLog = "Vamos colocar o quarteirão inicial - (002)";
			else if (code == 3)
				toLog = "E vamos instanciar os outros quarteirões para fazerem parte do pool de quarteirões - (003)";
			else if (code == 4)
				toLog = "Vamos criar o pool do background - (004)";
			else if (code == 5)
				toLog = "Vamos colocar um novo backgroung do pool mais na frente - (005)";
			else if (code == 6)
				toLog = "Vamos colocar um novo quarteirão randômico do pool mais na frente - (006)";
			else if (code == 7)
				toLog = "Vamos colocar os obstáculos na cena - (007)";
			else if (code == 7.01f)
				toLog = "Até agora definiu um conjunto de bloco de obstáculos baseado no estágio - (007.1)";
			else if (code == 7.02f)
				toLog = "E já escolheu o bloco em si - (007.2)";
			else if (code == 7.03f)
				toLog = "(007.3)";
			else if (code == 7.04f)
				toLog = "(007.4)";
			else if (code == 7.05f)
				toLog = "(007.5)";
			else if (code == 7.06f)
				toLog = "(007.6)";
			else if (code == 7.08f)
				toLog = "(007.8)";
			else if (code == 7.09f)
				toLog = "(007.9)";
			else if (code == 7.12f)
				toLog = "(007.12)";
			else if (code == 7.13f)
				toLog = "(007.13)";
			else if (code == 8)
				toLog = "Recebeu dano (008)";
			else if (code == 9)
				toLog = "Pegou item (009)";

			Debug.Log (toLog);

		}
	}



	public void debugLogWithindex (float code, int index)
	{

		if (showLogs) {

			string toLog = "";

			if (code==7.07f)
				toLog = "(007.7) [" + index + "]";
			else if (code==7.08f)
				toLog = "(007.8) [" + index + "]";
			else if (code==7.09f)
				toLog = "(007.9) [" + index + "] - veja se este aparece muito ";
			else if (code==7.10f)
				toLog = "(007.10) [" + index + "]";
			else if (code==7.11f)
				toLog = "(007.11) [" + index + "]";
			else if (code==7.12f)
				toLog = "(007.12) [" + index + "]";

			Debug.Log (toLog);

		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}

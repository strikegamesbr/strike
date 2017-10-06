using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankingController : MonoBehaviour {

	[SerializeField]
	private FacebookAndPlayFabFunctions faceFabFunctions;

	SavedData savedData;
	RankingOnScreen rankingOnScreen;

	[SerializeField]
	private GameObject cellPhone, ranking, loading;

//	[SerializeField]
//	private Text rankingTextUI;	 

	[SerializeField]
	private float timeToShowRanking = 10, timeWaitToServer=30;

	private Coroutine fetch;

	// Use this for initialization
	void Start () {

		savedData = FindObjectOfType<SavedData> ();
		rankingOnScreen = GetComponent<RankingOnScreen> ();
//		rankingTextUI.gameObject.SetActive (false);

//		StartCoroutine (LoggingUpdatingAndFetchingRoutine ());

	}

	public void pressYesButton ()
	{

//		cellPhone.SetActive (false);
//		ranking.SetActive (true);
		loading.SetActive(true);
//		rankingTextUI.gameObject.SetActive (true);
		fetch = StartCoroutine (LoggingUpdatingAndFetchingRoutine ());

	}

	public void pressToMainMenuButton ()
	{
		print ("mm1");
		SceneManager.LoadScene ("MainMenu");
	}

	public void pressNoButton ()
	{
		print ("mm2");
		SceneManager.LoadScene ("MainMenu");
	}

	IEnumerator LoggingUpdatingAndFetchingRoutine ()
	{

		string rankingText = null;
		float timeBegRoutine = Time.timeSinceLevelLoad;


		//vamos esperar inicializar o Facebook (é provável que só dê falso uma vez, deixe while assim mesmo para garantir)
		while (!faceFabFunctions.FacebookIsInitialized) {
			yield return new WaitForEndOfFrame ();
			if ((Time.timeSinceLevelLoad - timeBegRoutine) >= timeWaitToServer)
				StartCoroutine (ErrorConnectingRoutine (1));
		}

		//agora vamos logar no facebook
		faceFabFunctions.Login ();



		//esperar o processo de login no Facebook terminar
		while (!faceFabFunctions.FacebookIsLogged) {
			yield return new WaitForEndOfFrame ();
			if ((Time.timeSinceLevelLoad - timeBegRoutine) >= timeWaitToServer)
				StartCoroutine (ErrorConnectingRoutine (2));
		}
		//saindo do while significa que está logado no facebook

		//agora esperar o processo de login no Playfab terminar
		while (!faceFabFunctions.PlayFabIsLogged) {
			yield return new WaitForEndOfFrame ();
			if ((Time.timeSinceLevelLoad - timeBegRoutine) >= timeWaitToServer)
				StartCoroutine (ErrorConnectingRoutine (3));
		}
		//saindo do while significa que está logado no playfab

		//todo tem como pegar o valor atual no PlayFab pelo Facebook? Resposta: tentei... Mas pelo menos não atualiza lá se não for maior

		ulong scoreToSend = savedData.getScoreFromSave ();

		faceFabFunctions.UpdateScore ((int)scoreToSend); //ele faz o update mesmo que mande o mesmo valor que já está no servidor

		//quando faceFabFunctions.LastScoreUpdated == scoreToSend ele atualizou o valor no servidor
		while (faceFabFunctions.LastScoreUpdated != scoreToSend) {
			yield return new WaitForEndOfFrame ();
			if ((Time.timeSinceLevelLoad - timeBegRoutine) >= timeWaitToServer)
				StartCoroutine (ErrorConnectingRoutine (4));
		}


		//vamos pegar o ranking
		faceFabFunctions.LoadLeaderBoard();

		//leva um tempo para carregar o leaderboard, vamos esperar o tempo exato
		while (!faceFabFunctions.LeaderboardHasJustLoadedWaitTimeAfter) {
			yield return new WaitForEndOfFrame ();
			if ((Time.timeSinceLevelLoad - timeBegRoutine) >= timeWaitToServer)
				StartCoroutine (ErrorConnectingRoutine (5));
		}
		//atenção: ainda está em teste se este tempo é suficiente depois do while
		//para carregar ainda é preciso esperar um tempo depois do while
		//questão: precisa mesmo do while, ou só esperar um tempo basta? 
		//O while, na verdade, dá uma garantia do funcionamento.
		yield return new WaitForSeconds(0.1f);

		//aqui o array faceFabFunctions.leaderboardLoaded está preenchido, pode pular o código restante se quiser

		print ("faceFabFunctions.leaderboardLoaded.Length = " + faceFabFunctions.leaderboardLoaded.Length);


		rankingOnScreen.fillRankingOnScreen (faceFabFunctions.leaderboardLoaded);

		cellPhone.SetActive (false);
		ranking.SetActive (true);




//		for (int i = 0; i < faceFabFunctions.leaderboardLoaded.Length; i++) {
//
//			if (faceFabFunctions.leaderboardLoaded [i] != null) { //para o caso de não ter sido todo preenchido
//				positionPlayer posPly = faceFabFunctions.leaderboardLoaded [i];
//
//				string newText = string.Concat ((i+1).ToString (), ": ", posPly.PlayerName, " - ", posPly.Score);
//
//				if (string.IsNullOrEmpty (rankingText)) { 
//					rankingText = newText;
//				} else { //vai adicionar nova linha
//					rankingText = string.Concat (rankingText, System.Environment.NewLine, newText);
//				}
//
//			} else {
//				print ("É null");
//			}
//
//			rankingTextUI.text = rankingText;
//
//		}


//		yield return new WaitForSeconds (timeToShowRanking);
//
//		SceneManager.LoadScene ("MainMenu");


	}



	IEnumerator ErrorConnectingRoutine (int cod)
	{
		StopCoroutine (fetch);

		print ("Couldn't connect " + cod);

//		yield return new WaitForSeconds (10);

		loading.transform.Find ("Text-loading").GetComponent<Text> ().text = string.Concat("Failed to connect to server. Code 000", cod);

		print ("mm3");

		yield return new WaitForSeconds (5);

		SceneManager.LoadScene ("MainMenu");

	}




//	IEnumerator LoggingAndFetchingRoutine ()
//	{
//
//		string rankingText = null;
//
//		//vamos esperar inicializar o Facebook (é provável que só dê falso uma vez, deixe while assim mesmo para garantir)
//		while (!faceFabFunctions.FacebookIsInitialized) {
//			yield return new WaitForEndOfFrame ();
//		}
//
//		//agora vamos logar no facebook
//		faceFabFunctions.Login ();
//
//		//esperar o processo de login no Facebook terminar
//		while (!faceFabFunctions.FacebookIsLogged) {
//			yield return new WaitForEndOfFrame ();
//		}
//		//saindo do while significa que está logado no facebook
//
//		//agora esperar o processo de login no Playfab terminar
//		while (!faceFabFunctions.PlayFabIsLogged) {
//			yield return new WaitForEndOfFrame ();
//		}
//		//saindo do while significa que está logado no playfab
//
//
//		//vamos pegar o ranking
//		faceFabFunctions.LoadLeaderBoard();
//
//		//leva um tempo para carregar o leaderboard, vamos esperar o tempo exato
//		while (!faceFabFunctions.LeaderboardHasJustLoadedWaitTimeAfter) {
//			yield return new WaitForEndOfFrame ();
//		}
//		//atenção: ainda está em teste se este tempo é suficiente depois do while
//		//para carregar ainda é preciso esperar um tempo depois do while
//		//questão: precisa mesmo do while, ou só esperar um tempo basta? 
//		//O while, na verdade, dá uma garantia do funcionamento.
//		yield return new WaitForSeconds(0.1f);
//
//		//aqui o array faceFabFunctions.leaderboardLoaded está preenchido, pode pular o código restante se quiser
//
//		print ("faceFabFunctions.leaderboardLoaded.Length = " + faceFabFunctions.leaderboardLoaded.Length);
//
//
//		for (int i = 0; i < faceFabFunctions.leaderboardLoaded.Length; i++) {
//
//			if (faceFabFunctions.leaderboardLoaded [i] != null) { //para o caso de não ter sido todo preenchido
//				positionPlayer posPly = faceFabFunctions.leaderboardLoaded [i];
//
//				string newText = string.Concat ((i+1).ToString (), ": ", posPly.PlayerName, " - ", posPly.Score);
//
//				if (string.IsNullOrEmpty (rankingText)) { 
//					rankingText = newText;
//				} else { //vai adicionar nova linha
//					rankingText = string.Concat (rankingText, System.Environment.NewLine, newText);
//				}
//
//			} else {
//				print ("É null");
//			}
//
//			rankingTextUI.text = rankingText;
//
//		}
//
//	}


	
	// Update is called once per frame
	void Update () {
		
	}
}

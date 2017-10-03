using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingController : MonoBehaviour {

	[SerializeField]
	private FacebookAndPlayFabFunctions faceFabFunctions;


	// Use this for initialization
	void Start () {

		StartCoroutine (LoggingAndFetchingRoutine ());

	}


	IEnumerator LoggingAndFetchingRoutine ()
	{

		//é provável que só dê falso uma vez, deixe assim mesmo
		//vamos esperar inicializar o Facebook
		while (!faceFabFunctions.FacebookIsInitialized) {
//			print ("Facebook não inicializou ainda");
			yield return new WaitForEndOfFrame ();
		}

//		print ("Facebook inicializou");

		//agora vamos logar no facebook
		faceFabFunctions.Login ();

		//esperar o processo de login terminar
		while (!faceFabFunctions.FacebookIsLogged) {
//			print ("Não logou ainda");
			yield return new WaitForEndOfFrame ();
		}

		//saindo do while significa que está logado no facebook


		while (!faceFabFunctions.PlayFabIsLogged) {
			print ("Não logou no PlayFab");
			yield return new WaitForEndOfFrame ();
		}


		print ("Logou no Playfab!");

		//saindo do while significa que está logado no PlayFab


		//vamos pegar o ranking
		faceFabFunctions.LoadLeaderBoard();

		print ("faceFabFunctions.leaderboardLoaded.Length = " + faceFabFunctions.leaderboardLoaded.Length);
		for (int i = 0; i < faceFabFunctions.leaderboardLoaded.Length; i++) {

			//todo é tudo null, esperar mais para carregar?

			if (faceFabFunctions.leaderboardLoaded [i] != null) { //para o caso de não ter sido todo preenchido
				positionPlayer posPly = faceFabFunctions.leaderboardLoaded [i];
				print ((i + 1) + ": " + posPly.PlayerName + " - " + posPly.Score);
			} else {
				print ("É null");
			}

		}








	}



	
	// Update is called once per frame
	void Update () {
		
	}
}

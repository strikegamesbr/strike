using UnityEngine;
using System.Collections;

//por Leonardo Thurler
//classe estática que guarda os dados do usuário no jogo.

public static class FacebookAndPlayFabInfoBackup
{
	//Id do usuário no PlayFab
	public static string userPlayFabId = "";
	//Id do usuário no Facebook
	public static string userFacebookId = "";
	//Nome do usuário no Facebook
	public static string userName = "";
	//Indica se o usuário já está logado no PlayFab
	public static bool isLoggedOnPlayFab = false;
	//Indica se os dados do leaderboard já foram carregados.
	private static bool _leaderboardLoaded = false;

	public static bool leaderboardLoaded {
		get {
			return _leaderboardLoaded;
		}

		set {
			_leaderboardLoaded = value;

			Debug.Log ("_leaderboardLoaded = " + _leaderboardLoaded);
		}
	}
	//Indica se os dados do leaderboard estão sendo carregados.
	public static bool leaderboardIsLoading = false;
}
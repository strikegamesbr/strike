using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class GooglePlayService : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//faz o login aqui
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate();

	}


	public void loginGoogle()
	{
		Social.localUser.Authenticate ((bool success) => { /*se logou o que fazer, senão o que fazer*/	});

	}
	

}

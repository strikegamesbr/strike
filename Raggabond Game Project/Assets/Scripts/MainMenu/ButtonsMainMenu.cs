using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMainMenu : MonoBehaviour {


	[SerializeField]
	private GameObject infoPanel, contactPanel, bioPanel, quitBtn, optionsPanel, creditsPanel;

	[SerializeField]
	private Sounds sounds;

	[SerializeField]
	private string faceURL = "https://www.facebook.com/raggabondband/";

	private GameSettings settings;

	// Use this for initialization
	void Start () {
		
		settings = FindObjectOfType<GameSettings> ();

		#if UNITY_ANDROID
			quitBtn.SetActive(false);
		#endif


	}



	private void playSoundPressButton ()
	{
		sounds.playPressButtonSfx ();
	}

	public void pressTTTSPad ()
	{
		playSoundPressButton ();
		Application.OpenURL ("market://details?id=com.StrikeGames.TicTacToeSP.Mobile");

	}


	public void pressSwitchSoundOnOff ()
	{
		playSoundPressButton ();
		settings.switchSoundOnOff ();
	}


	public void pressPlayGameButton ()
	{
		playSoundPressButton ();
		SceneManager.LoadScene ("Stage1");
	}


	public void pressInfoButton ()
	{
		playSoundPressButton ();
		infoPanel.SetActive (true);
	}


	public void pressOptionsButton ()
	{
		playSoundPressButton ();
		optionsPanel.SetActive (true);
	}

	public void pressLeaderboardsButton ()
	{
	}

	public void pressFaceButton ()
	{
		playSoundPressButton ();
		Application.OpenURL (faceURL);
	}


	public void pressBackInfoPanelButton ()
	{
		playSoundPressButton ();
		infoPanel.SetActive (false);
	}

	public void pressBackOptionsPanelButton ()
	{
		playSoundPressButton ();
		optionsPanel.SetActive (false);
	}

	public void pressContactButton ()
	{
		playSoundPressButton ();
		contactPanel.SetActive (true);
	}

	public void pressBackContactButton ()
	{
		playSoundPressButton ();
		contactPanel.SetActive (false);
	}

	public void pressBioButton ()
	{
		playSoundPressButton ();
		bioPanel.SetActive (true);
	}

	public void pressBackBioButton ()
	{
		playSoundPressButton ();
		bioPanel.SetActive (false);
	}


	public void pressCreditsButton ()
	{
		playSoundPressButton ();
		creditsPanel.SetActive (true);
	}

	public void pressBackCreditsButton ()
	{
		playSoundPressButton ();
		creditsPanel.SetActive (false);
	}


	public void pressQuitGameButton ()
	{
		playSoundPressButton ();
		Application.Quit();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit();
		
	}
}

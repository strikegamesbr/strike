using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMainMenu : MonoBehaviour {


	[SerializeField]
	private GameObject infoPanel, contactPanel, bioPanel, quitBtn, optionsPanel, creditsPanel;

	[SerializeField]
	private string faceURL = "https://www.facebook.com/raggabondband/";


	// Use this for initialization
	void Start () {


		#if UNITY_ANDROID
			quitBtn.SetActive(false);
		#endif


	}


	public void pressPlayGameButton ()
	{
		SceneManager.LoadScene ("Stage1");
	}


	public void pressInfoButton ()
	{
		infoPanel.SetActive (true);
	}


	public void pressOptionsButton ()
	{
		optionsPanel.SetActive (true);
	}

	public void pressLeaderboardsButton ()
	{
	}

	public void pressFaceButton ()
	{
		Application.OpenURL (faceURL);
	}


	public void pressBackInfoPanelButton ()
	{
		infoPanel.SetActive (false);
	}

	public void pressBackOptionsPanelButton ()
	{
		optionsPanel.SetActive (false);
	}

	public void pressContactButton ()
	{
		contactPanel.SetActive (true);
	}

	public void pressBackContactButton ()
	{
		contactPanel.SetActive (false);
	}

	public void pressBioButton ()
	{
		bioPanel.SetActive (true);
	}

	public void pressBackBioButton ()
	{
		bioPanel.SetActive (false);
	}


	public void pressCreditsButton ()
	{
		creditsPanel.SetActive (true);
	}

	public void pressBackCreditsButton ()
	{
		creditsPanel.SetActive (false);
	}


	public void pressQuitGameButton ()
	{
		Application.Quit();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit();
		
	}
}

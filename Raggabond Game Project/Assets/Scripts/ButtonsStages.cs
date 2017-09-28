using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsStages : MonoBehaviour {

	[SerializeField]
	private Sounds sounds;


	// Use this for initialization
	void Start () {
		
	}

	private void playSoundPressButton ()
	{
		sounds.playPressButtonSfx ();
	}


	public void pressBackMainMenuButton ()
	{
		playSoundPressButton ();
		SceneManager.LoadScene ("MainMenu");
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}

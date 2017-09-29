using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {


	[SerializeField]
	private AudioSource pressButtonSfx, acelerateSfx, brakeSfx, collideSfx, collectitemSfx;

	private GameSettings settings;


	// Use this for initialization
	void Start () {

		//as linhas abaixo são necessárias pois os atributos originalmente têm prefabs
		pressButtonSfx = Instantiate (pressButtonSfx) as AudioSource;
		acelerateSfx = Instantiate (acelerateSfx) as AudioSource;
		brakeSfx = Instantiate (brakeSfx) as AudioSource;
		collideSfx = Instantiate (collideSfx) as AudioSource;
		collectitemSfx = Instantiate (collectitemSfx) as AudioSource;

		settings = FindObjectOfType<GameSettings> ();
	}


	public void muteAllSounds ()
	{
		pressButtonSfx.mute = true;
		acelerateSfx.mute = true;
		brakeSfx.mute = true;
		collideSfx.mute = true;
		collectitemSfx.mute = true;
	}


	public void unmuteAllSounds ()
	{
		pressButtonSfx.mute = false;
		acelerateSfx.mute = false;
		brakeSfx.mute = false;
		collideSfx.mute = false;
		collectitemSfx.mute = false;
	}


	private void playSound (AudioSource audioSource)
	{
		audioSource.Play ();
	}


	public void playPressButtonSfx ()
	{		
		playSound (pressButtonSfx);
		//		pressButtonSfx.Play ();
	}

	public void playAcelerateSfx ()
	{
		playSound (acelerateSfx);
//		acelerateSfx.Play();
	}

	public void playBrakeSfx ()
	{
		playSound (brakeSfx);
//		brakeSfx.Play ();
	}

	public void playCollideSfx ()
	{
		playSound (collideSfx);
//		collideSfx.Play ();
	}

	public void playCollectitemSfx ()
	{
		playSound (collectitemSfx);
//		collectitemSfx.Play ();
	}



		
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour {


	[SerializeField]
	private bool soundEffectsOn, musicOn;


	// Use this for initialization
	void Start () {



	}


	public bool sfxIsOn {
		get {
			return soundEffectsOn;
		}

		set {
			soundEffectsOn = value;

			if (value == true)
				FindObjectOfType<Sounds> ().unmuteAllSounds ();
			else
				FindObjectOfType<Sounds> ().muteAllSounds ();

			try {
				if (value == true)
					FindObjectOfType<SpritesButtons>().switchSfxSpritesToOn();
				else
					FindObjectOfType<SpritesButtons>().switchSfxSpritesToOff();
			} catch {
			}
		}

	}

	public bool musicIsOn {
		get {
			return musicOn;
		}

		set {
			musicOn = value;

			if (value == true)
				FindObjectOfType<MusicControl> ().unmuteAllSongs ();
			else
				FindObjectOfType<MusicControl> ().muteAllSongs ();

			try {
				if (value == true)
					FindObjectOfType<SpritesButtons>().switchMusicSpritesToOn();
				else
					FindObjectOfType<SpritesButtons>().switchMusicSpritesToOff();
			} catch {
			}
		}
	}


	public void switchSoundOnOff ()
	{

		sfxIsOn = !sfxIsOn;

	}





	// Update is called once per frame
	void Update () {

		//para quando mudar no hierarchy no Unity executar o set
		sfxIsOn = soundEffectsOn;
		musicIsOn = musicOn;
	}
}

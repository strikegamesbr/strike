using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {


	[SerializeField]
	SpritesButtons spritesButtons;

	[SerializeField]
	private bool soundEffectsOn, musicOn;



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
					spritesButtons.switchSfxSpritesToOn();
				else
					spritesButtons.switchSfxSpritesToOff();
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
					spritesButtons.switchMusicSpritesToOn();
				else
					spritesButtons.switchMusicSpritesToOff();
			} catch {
			}
		}
	}


	public void switchSoundOnOff ()
	{
		
		sfxIsOn = !sfxIsOn;

	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//para quando mudar no hierarchy no Unity executar o set
		sfxIsOn = soundEffectsOn;
		musicIsOn = musicOn;

	}
}

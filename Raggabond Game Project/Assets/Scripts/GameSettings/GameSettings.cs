using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour {


	//for debugging
	public bool divideObstaclesBlocksBy4 = false, divideObstaclesBlocksBy2 = false, emptyStrees = false;




	[SerializeField]
	private bool soundEffectsOn, musicOn;

	#if UNITY_EDITOR //os campos abaixo serão usados para atualizações a cada frame

	Sounds sounds;
	MusicControl musicControl;
	SpritesButtons spritesButtons;

	#endif

	// Use this for initialization
	void Start () {
		
		#if UNITY_EDITOR //os campos abaixo serão usados para atualizações a cada frame

		sounds = FindObjectOfType<Sounds> ();
		spritesButtons = FindObjectOfType<SpritesButtons> ();
		musicControl = FindObjectOfType<MusicControl> ();

		#endif
	}


	public bool sfxIsOn {
		get {
			return soundEffectsOn;
		}

		set {
			soundEffectsOn = value;

			#if UNITY_EDITOR //vai rodar todo frame

			try {

				if (value == true)
					sounds.unmuteAllSounds ();
				else
					sounds.muteAllSounds ();

			} catch {
				sounds = FindObjectOfType<Sounds> ();
				//e daí faz no próximo frame
			}

			try {
				if (value == true)
					spritesButtons.switchSfxSpritesToOn();
				else
					spritesButtons.switchSfxSpritesToOff();
			} catch {				
				spritesButtons = FindObjectOfType<SpritesButtons> ();
				//e daí faz no próximo frame
			}

			#else

			try {

			if (value == true)
				FindObjectOfType<Sounds> ().unmuteAllSounds ();
			else
				FindObjectOfType<Sounds> ().muteAllSounds ();

			} catch {
			}

			try {
			if (value == true)
				FindObjectOfType<SpritesButtons> ().switchSfxSpritesToOn();
			else
				FindObjectOfType<SpritesButtons> ().switchSfxSpritesToOff();
			} catch {				
			//e daí faz no próximo frame
			}

			#endif
		}

	}

	public bool musicIsOn {
		get {
			return musicOn;
		}

		set {
			musicOn = value;

			#if UNITY_EDITOR

			try {

				if (value == true)
					musicControl.unmuteAllSongs ();
				else
					musicControl.muteAllSongs ();
			} catch {
				musicControl = FindObjectOfType<MusicControl> ();
				//e daí faz no próximo frame
			}

			try {
				if (value == true)
					spritesButtons.switchMusicSpritesToOn();
				else
					spritesButtons.switchMusicSpritesToOff();
			} catch {
				spritesButtons = FindObjectOfType<SpritesButtons> ();
				//e daí faz no próximo frame
			}

			#else


			try {

				if (value == true)
					FindObjectOfType<MusicControl> ().unmuteAllSongs ();
				else
					FindObjectOfType<MusicControl> ().muteAllSongs ();


				if (value == true)
					FindObjectOfType<SpritesButtons>().switchMusicSpritesToOn();
				else
					FindObjectOfType<SpritesButtons>().switchMusicSpritesToOff();
			} catch {
				
			}

			#endif



		}
	}


	public void switchSoundOnOff ()
	{

		sfxIsOn = !sfxIsOn;

	}





	// Update is called once per frame
	void Update () {

		#if UNITY_EDITOR
		//para quando mudar no hierarchy no Unity executar o set
		sfxIsOn = soundEffectsOn;
		musicIsOn = musicOn;
		#endif
	}
}

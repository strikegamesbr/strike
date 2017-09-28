using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//todo testar mudança de sprites nos botões aqui e no GameSettings tb

public class SpritesButtons : MonoBehaviour {


	[SerializeField]
	private Sprite musicOnNormal, musicOnOver, musicOffNormal, musicOffOver, soundOnNormal, soundOnOver, soundOffNormal, soundOffOver;

	[SerializeField]
	private Button musicButton, sfxButton;



//	public void musicIsOn(bool isOn)
//	{
//
//		SpriteState curSpriteState = new SpriteState ();
//
//		if (isOn) {
//
//			//			print ("now music is on");
//
//			musicButton.GetComponent<Image> ().sprite = musicOn;
//			curSpriteState.pressedSprite = musicOn;
//			curSpriteState.highlightedSprite = musicOn_over;	
//
//		} else {
//			//			print ("now music is off");
//			musicButton.GetComponent<Image> ().sprite = musicOff;
//			curSpriteState.pressedSprite = musicOff;
//			curSpriteState.highlightedSprite = musicOff_over;
//		}
//
//		musicButton.spriteState = curSpriteState;
//
//	}


	private void musicIsOn(bool isOn)
	{

		SpriteState curSpriteState = new SpriteState ();

		if (isOn) {
			musicButton.GetComponent<Image> ().sprite = musicOnNormal;
			curSpriteState.pressedSprite = musicOnNormal;
			curSpriteState.highlightedSprite = musicOnOver;	

		} else {
			musicButton.GetComponent<Image> ().sprite = musicOffNormal;
			curSpriteState.pressedSprite = musicOffNormal;
			curSpriteState.highlightedSprite = musicOffOver;
		}

		musicButton.spriteState = curSpriteState;

	}


	private void sfxIsOn(bool isOn)
	{

		SpriteState curSpriteState = new SpriteState ();

		if (isOn) {
			sfxButton.GetComponent<Image> ().sprite = soundOnNormal;
			curSpriteState.pressedSprite = soundOnNormal;
			curSpriteState.highlightedSprite = soundOnOver;	

		} else {
			sfxButton.GetComponent<Image> ().sprite = soundOffNormal;
			curSpriteState.pressedSprite = soundOffNormal;
			curSpriteState.highlightedSprite = soundOffOver;
		}

		sfxButton.spriteState = curSpriteState;

	}


	public void switchMusicSpritesToOn ()
	{
		musicIsOn (true);
	}

	public void switchMusicSpritesToOff ()
	{
		musicIsOn (false);
	}

	public void switchSfxSpritesToOn ()
	{
		sfxIsOn (true);
	}

	public void switchSfxSpritesToOff ()
	{
		sfxIsOn (false);
	}






	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

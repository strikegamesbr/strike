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
		
		//verifica se o usuário desligou o som - se sim, muda os sprites do botão de som nas opções
		//serve especialmente se o usuário voltar de outras cenas para o menu principal
		sfxIsOn (FindObjectOfType<GameSettings> ().sfxIsOn);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

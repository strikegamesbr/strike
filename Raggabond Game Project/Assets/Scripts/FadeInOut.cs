using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour {

	private Image fadeImage;
	public float fadeSpeed;
	public float timeBetweenFades;
	public GameObject[] screens;


	void Start() {

		fadeImage = GetComponent<Image>();

		StartCoroutine ("fadeRoutine");

	}

	public IEnumerator fadeRoutine ()
	{ //diminuir a cor
		//fadeTexture = GetComponent<SpriteRenderer> ();
		Color cor = new Color (0, 0, 0, 1); //criou a cor preta

		foreach (GameObject screen in screens) {
			
			fadeImage.color = cor;
			screen.SetActive (true);
			for (float f = 1; f > 0; f -= fadeSpeed) {			
				cor.a = f;
				fadeImage.color = cor;
				yield return new WaitForEndOfFrame ();
			}

			yield return new WaitForSeconds (timeBetweenFades);

			//fadeTexture = GetComponent<SpriteRenderer>();
			//Color cor = new Color(0,0,0,0); 
			fadeImage.color = cor;
			for (float f = 0; f < 1; f += fadeSpeed) {
				cor.a = f;
				fadeImage.color = cor;
				yield return new WaitForEndOfFrame ();
			}
			screen.SetActive (false);
		}
		

		SceneManager.LoadScene ("MainMenu");

	}


	void Update ()
	{		

	}


}








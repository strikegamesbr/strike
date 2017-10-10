using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackGround : MonoBehaviour {

	[SerializeField]
	private Transform BGPrefab, previousBG; 

	private bool firstTime = true;

	private GameObject[] Backgrounds;



	//com vetor de 2
	void Start()
	{

		Backgrounds = new GameObject[2];

		//vamos preencher Backgrounds
		//para o primeiro vamos colocar o que já está colocado na cena no editor
		Backgrounds[0] = previousBG.gameObject;

		//o outro instancia um novo
		Backgrounds[1] = Instantiate (BGPrefab.gameObject);
		Backgrounds[1].transform.rotation = previousBG.rotation;
		Backgrounds [1].transform.parent = this.transform;
		//este novo deve estar invisível para não aparecer na tela
		Backgrounds [1].SetActive (false);

	}



	//garante que não retorna previousBG
	private GameObject nextBG () {

		int j = -1;

		for (int i = 0; i < Backgrounds.Length; i++) {
			
			if (Backgrounds [i] == previousBG.gameObject) {

				if (i != Backgrounds.Length - 1)
					j = i + 1;
				else
					j = 0;

				break;
			}

		}

//		print ("j=" + j);


		if (j >= 0 && j < Backgrounds.Length) {
			Backgrounds [j].SetActive (true);
			return Backgrounds [j];
		}
		else
			return null;

	}


	public void createBG ()
	{

		//cria o floor na mesma posição de previous com x + 0.5*previousTrack.localScale.x (0.5 é metade do comprimento padrão de Quad)
		GameObject newBG = nextBG ();
		newBG.transform.position = new Vector3 (previousBG.position.x + 0.5f * previousBG.localScale.x, previousBG.position.y, previousBG.position.z);

		//previousTrack = novo track
		previousBG = newBG.transform;

	}






}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchControl : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}


	void singleTouch ()
	{
		//se entrar no if abaixo, há toques na tela
		if (Input.touchCount > 0) {

			Touch touch = Input.touches [0];

			switch (touch.phase) {

			case TouchPhase.Began: 
				//COMANDOS AO TOCAR NA TELA
				print("tocou na tela");
				break;
			case TouchPhase.Ended:
				//COMANDOS AO TIRAR O DEDO DA TELA
				break;
			case TouchPhase.Moved:				
				//COMANDOS AO MOVER O DEDO NA TELA - ele não usa
				break;
			case TouchPhase.Stationary:
				//COMANDOS SE O DEDO PERMANECER NA TELA
				//encostou na tela já conta, no began ele já executa stationary
				break;
			case TouchPhase.Canceled:
				//COMANDOS CASO EXCEDA O LIMITE DO TOQUE
				//como colocar a mão inteira na tela, qualé!
				break;
			}
		}
	}

	void multiTouches ()
	{
		
		if (Input.touchCount > 0) {

			foreach (Touch touch in Input.touches) {

				switch (touch.phase) {

				case TouchPhase.Began: 
					//COMANDOS AO TOCAR NA TELA

					break;
				case TouchPhase.Ended:
					//COMANDOS AO TIRAR O DEDO DA TELA
					break;
				case TouchPhase.Moved:
					//COMANDOS AO MOVER O DEDO NA TELA - ele não usa
					break;
				case TouchPhase.Stationary:
					//COMANDOS SE O DEDO PERMANECER NA TELA
					//encostou na tela já conta, no began ele já executa stationary
					break;
				case TouchPhase.Canceled:
					//COMANDOS CASO EXCEDA O LIMITE DO TOQUE
					//como colocar a mão inteira na tela, qualé!
					break;
				}

			}

		}


	}


	
	// Update is called once per frame
	void Update () {

		singleTouch ();


	}
}

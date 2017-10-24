using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

	[SerializeField]
	PlayerState playerState;

	[SerializeField]
	private float timeGameOverToMainMenu=3;


	public float TimeGameOverToMainMenu {
		get {
			return timeGameOverToMainMenu;
		}
	}



	void Awake () 
	{

		playerState.Lane = Lane.middle;

	}


	// Use this for initialization
	void Start () {

		Debug.Log ("A cena começou - (001)");


	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKeyDown (KeyCode.Escape))
//			Application.Quit();
//
	}
}

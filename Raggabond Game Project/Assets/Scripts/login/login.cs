using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class login : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


	public void pressBackButton ()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene ("MainMenu");
		}

	}
}

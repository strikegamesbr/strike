using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjects : MonoBehaviour {

	[SerializeField]
	private Transform defaultParent;

	[SerializeField]
	private Lane lane;

	public  Lane  Lane {
		get {
			return lane;
		}

		set {
			lane = value;

			transform.parent = null;

			switch (lane) {

			case Lane.lower:
				GetComponent<SpriteRenderer> ().sortingOrder = 2;
				transform.position = new Vector3 (transform.position.x, yLower, transform.position.z);
				break;
			case Lane.middle:
				GetComponent<SpriteRenderer> ().sortingOrder = 1;
				transform.position = new Vector3 (transform.position.x, yMedium, transform.position.z);
				break;
			case Lane.upper:
				GetComponent<SpriteRenderer> ().sortingOrder = 0;
				transform.position = new Vector3 (transform.position.x, yUpper, transform.position.z);
				break;
			}

			transform.parent = defaultParent;

		}

	}


	private float yUpper, yMedium, yLower;


	private ScnObjManager _scnObjManager;
	private PlayerState _playerState;

	public ScnObjManager scnObjManager {
		get {
			return _scnObjManager;
		}
	}

	public PlayerState playerState {
		get {
			return _playerState;
		}
	}



	// Use this for initialization
	//start e update não são passados por herança!
	void Start () {
		toStart ();
	}

	protected void toStart ()
	{
		_scnObjManager = transform.parent.GetComponent<ScnObjManager> (); 
		_playerState = FindObjectOfType<PlayerState> ();
		defaultParent = _scnObjManager.transform; //o parent dele é o mesmo objeto que tem o script ScnObjManager



		if (gameObject.name.Contains ("apple")) {
			yUpper = scnObjManager.yUpperApple;
			yMedium = scnObjManager.yMediumApple;
			yLower = scnObjManager.yLowerApple;
		} else if ( gameObject.name.Contains ("guitar")) {
			yUpper = scnObjManager.yUpperGuitar;
			yMedium = scnObjManager.yMediumGuitar;
			yLower = scnObjManager.yLowerGuitar;
		} else if (gameObject.name.Contains ("lilMario")) {
			yUpper = scnObjManager.yUpperLilMario;
			yMedium = scnObjManager.yMediumLilMario;
			yLower = scnObjManager.yLowerLilMario;
		} else if ( gameObject.name.Contains ("patinadora")) {
			yUpper = scnObjManager.yUpperPatinadora;
			yMedium = scnObjManager.yMediumPatinadora;
			yLower = scnObjManager.yLowerPatinadora;
		} else if ( gameObject.name.Contains ("beachBall")) {
			yUpper = scnObjManager.yUpperBeachBall;
			yMedium = scnObjManager.yMediumBeachBall;
			yLower = scnObjManager.yLowerBeachBall;
		} else if (gameObject.name.Contains ("skatista")) {
			yUpper = scnObjManager.yUpperSkatista;
			yMedium = scnObjManager.yMediumSkatista;
			yLower = scnObjManager.yLowerSkatista;		

		}



	}

	protected void toUpdate ()
	{		
		Lane = lane; //caso o valor seja mudado na janela 

	}


	// Update is called once per frame
	//start e update não são passados por herança!
	void Update () {
		toUpdate ();
	}
}

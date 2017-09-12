using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjects : MonoBehaviour {

	[SerializeField]
	private Lane lane;

	public  Lane  Lane {
		get {
			return lane;
		}

		set {
			lane = value;

			switch (lane) {

			case Lane.lower:
				GetComponent<SpriteRenderer> ().sortingOrder = 0;
				break;
			case Lane.middle:
				GetComponent<SpriteRenderer> ().sortingOrder = 1;
				break;
			case Lane.upper:
				GetComponent<SpriteRenderer> ().sortingOrder = 2;
				break;
			}

		}

	}


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

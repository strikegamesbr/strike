﻿using System.Collections;
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

//			switch (lane) {
//
//			case Lane.lower:
//				GetComponent<SpriteRenderer> ().sortingOrder = 2;
//				transform.position = new Vector3 (transform.position.x, yLower, transform.position.z);
//				break;
//			case Lane.middle:
//				GetComponent<SpriteRenderer> ().sortingOrder = 1;
//				transform.position = new Vector3 (transform.position.x, yMedium, transform.position.z);
//				break;
//			case Lane.upper:
//				GetComponent<SpriteRenderer> ().sortingOrder = 0;
//				transform.position = new Vector3 (transform.position.x, yUpper, transform.position.z);
//				break;
//			}


			setYPositionAndSortingOrderByLane ();


			transform.parent = defaultParent;

		}

	}


	private float yUpper, yMedium, yLower;


	private ScnObjManager _scnObjManager;
	private PlayerState _playerState;
	private Sounds _sounds;

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

	public Sounds sounds {
		get {
			return _sounds;
		}
	}

	public Transform DefaultParent {

		get {
			return defaultParent;
		}

	}

	[SerializeField]
	private float speed;




	// Use this for initialization
	//start e update não são passados por herança!
	void Start () {
		toStart ();
	}

	protected void toStart ()
	{
		_scnObjManager = FindObjectOfType<ScnObjManager> (); 
		_playerState = FindObjectOfType<PlayerState> ();
		_sounds = FindObjectOfType<Sounds> ();
		defaultParent = transform.parent; //o parent dele é o mesmo objeto que tem o script ScnObjManager



		if (gameObject.name.Contains ("apple")) {
			yUpper = scnObjManager.yUpperApple;
			yMedium = scnObjManager.yMediumApple;
			yLower = scnObjManager.yLowerApple;
			speed = scnObjManager.speedApple;
		} else if ( gameObject.name.Contains ("guitar")) {
			yUpper = scnObjManager.yUpperGuitar;
			yMedium = scnObjManager.yMediumGuitar;
			yLower = scnObjManager.yLowerGuitar;
			speed = scnObjManager.speedGuitar;
		} else if (gameObject.name.Contains ("lilMario")) {
			yUpper = scnObjManager.yUpperLilMario;
			yMedium = scnObjManager.yMediumLilMario;
			yLower = scnObjManager.yLowerLilMario;
			speed = scnObjManager.speedLilMario;
		} else if ( gameObject.name.Contains ("patinadora")) {
			yUpper = scnObjManager.yUpperPatinadora;
			yMedium = scnObjManager.yMediumPatinadora;
			yLower = scnObjManager.yLowerPatinadora;
			speed = scnObjManager.speedPatinadora;
		} else if ( gameObject.name.Contains ("beachBall")) {
			yUpper = scnObjManager.yUpperBeachBall;
			yMedium = scnObjManager.yMediumBeachBall;
			yLower = scnObjManager.yLowerBeachBall;
			speed = scnObjManager.speedBeachBall;
		} else if (gameObject.name.Contains ("skatista")) {
			yUpper = scnObjManager.yUpperSkatista;
			yMedium = scnObjManager.yMediumSkatista;
			yLower = scnObjManager.yLowerSkatista;	
			speed = scnObjManager.speedSkatista;

		}


	}

	public void setYPositionAndSortingOrderByLane ()
	{

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

	}

	protected void toUpdate ()
	{		
		Lane = lane; //caso o valor seja mudado na janela 
		transform.position = transform.position + new Vector3((speed*Time.deltaTime)/10, 0, 0);


//		//rolar a bola, enquanto for child de um mesh não dá, daí a troca de parent
//		if (gameObject.name.Contains ("beachBall")) {
//			
//			float speedRoll = 60;
//			transform.parent = null;
//
//			transform.Rotate(new Vector3(- 0.1f, - 0.1f, - 0.1f));
//
//			transform.parent = DefaultParent;
//		}

//		speedRoll*Time.deltaTime
	}


	// Update is called once per frame
	//start e update não são passados por herança!
	void Update () {
		toUpdate ();

	}
}
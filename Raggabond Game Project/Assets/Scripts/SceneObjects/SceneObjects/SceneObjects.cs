using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjects : MonoBehaviour {

	[SerializeField]
	private Transform defaultParent;

	[SerializeField]
	private Lane lane;

	private Transform originalParent;

	public  Lane  Lane {
		get {
			return lane;
		}

		set {
			lane = value;

			transform.parent = null;


			setYPositionAndSortingOrderByLane ();


			transform.parent = defaultParent;

		}

	}

	public Transform OriginalParent {
		get {
			return originalParent;
		}

		set {
			originalParent = value;
		}
	}


	private float yUpper, yMedium, yLower;


	private ScnObjManager _scnObjManager;
	private PlayerState _playerState;
	private Sounds _sounds;

	[SerializeField]
	private float speed;

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

	public float Speed {
		get {
			return speed;
		}

		set {
			speed = value;
		}

	}


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
			if (Speed == 0) //se for um objeto parado
				GetComponent<SpriteRenderer> ().sortingOrder = 4;
			else
				GetComponent<SpriteRenderer> ().sortingOrder = 5;
			transform.position = new Vector3 (transform.position.x, yLower, transform.position.z);
			break;
		case Lane.middle:
			if (Speed == 0) //se for um objeto parado
				GetComponent<SpriteRenderer> ().sortingOrder = 2;
			else
				GetComponent<SpriteRenderer> ().sortingOrder = 3;
			transform.position = new Vector3 (transform.position.x, yMedium, transform.position.z);
			break;
		case Lane.upper:
			if (Speed == 0) //se for um objeto parado
				GetComponent<SpriteRenderer> ().sortingOrder = 0;
			else
				GetComponent<SpriteRenderer> ().sortingOrder = 1;
			transform.position = new Vector3 (transform.position.x, yUpper, transform.position.z);
			break;
		}

	}

	protected void toUpdate ()
	{		
		Lane = lane; //caso o valor seja mudado na janela 
		transform.position = transform.position + new Vector3((speed*Time.deltaTime)/10, 0, 0);

	}


	// Update is called once per frame
	//start e update não são passados por herança!
	void Update () {
		toUpdate ();

	}
}

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


	private kindObj kind = kindObj.none;
	private bool isVisible = false;
	private bool taken = false; //se já foi pega para fazer parte de um bloco de objetos
	private float yUpper, yMedium, yLower;


	private ScnObjManager _scnObjManager;
	private PlayerState _playerState;
	private Sounds _sounds;
	private Track _track;


	[SerializeField]
	private float speed;

	public kindObj Kind {
		get {
			return kind;
		}
		set {
			kind = value;
		}
	}

	public bool IsVisible {
		get {
			return isVisible;
		}
		set {
			isVisible = value;
		}
	}

	public bool Taken {
		get {
			return taken;
		}
		set {
			taken = value;
		}
	}


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


	public Track track {
		get {
			return _track;
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
		_track = FindObjectOfType<Track> ();
		defaultParent = transform.parent; //o parent dele é o mesmo objeto que tem o script ScnObjManager



		if (gameObject.name.Contains ("coin")) {
			kind = kindObj.coin;
			yUpper = scnObjManager.yUpperApple;
			yMedium = scnObjManager.yMediumApple;
			yLower = scnObjManager.yLowerApple;
			speed = scnObjManager.speedApple;
		} else if ( gameObject.name.Contains ("guitar")) {
			kind = kindObj.guitar;
			yUpper = scnObjManager.yUpperGuitar;
			yMedium = scnObjManager.yMediumGuitar;
			yLower = scnObjManager.yLowerGuitar;
			speed = scnObjManager.speedGuitar;
		} else if (gameObject.name.Contains ("lilMario")) {
			kind = kindObj.lilMario;
			yUpper = scnObjManager.yUpperLilMario;
			yMedium = scnObjManager.yMediumLilMario;
			yLower = scnObjManager.yLowerLilMario;
			speed = scnObjManager.speedLilMario;
		} else if ( gameObject.name.Contains ("patinadora")) {

			if (gameObject.name.Contains ("patinadora_var"))
				kind = kindObj.patinadora_var;
			else
				kind = kindObj.patinadora;

			yUpper = scnObjManager.yUpperPatinadora;
			yMedium = scnObjManager.yMediumPatinadora;
			yLower = scnObjManager.yLowerPatinadora;
			speed = scnObjManager.speedPatinadora;
		} else if ( gameObject.name.Contains ("cone")) {
			kind = kindObj.cone;
			yUpper = scnObjManager.yUpperBeachBall;
			yMedium = scnObjManager.yMediumBeachBall;
			yLower = scnObjManager.yLowerBeachBall;
			speed = scnObjManager.speedBeachBall;
		} else if (gameObject.name.Contains ("skatista")) {
			
			if (gameObject.name.Contains ("skatista_var"))
				kind = kindObj.skatista_var;
			else
				kind = kindObj.skatista;
			
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
		transform.position = transform.position + new Vector3( ( (-track.CurrentSpeed+speed) * Time.deltaTime )/10 , 0, 0);

	}


	// Update is called once per frame
	//start e update não são passados por herança!
	void Update () {
		toUpdate ();

	}
}

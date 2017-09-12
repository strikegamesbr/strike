using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {


	private speedType currentSpeedType;
	private float currentSpeed;

	[SerializeField]
	private float 	NormalSpeed = 50, FastSpeed = 100, SlowSpeed = 10;

	[SerializeField]
	Animator PlayerAnimator;


	// Use this for initialization
	void Start () {

		currentSpeedType = speedType.normal;

	}


	public speedType CurrentSpeedType {

		get {
			return currentSpeedType;
		}

		set {
			currentSpeedType = value;
		}
	}



	
	// Update is called once per frame
	void Update () {


		switch (currentSpeedType) {

		case speedType.normal:
			currentSpeed = NormalSpeed;
			break;
		case speedType.fast:
			currentSpeed = FastSpeed;
			break;
		case speedType.slow:
			currentSpeed = SlowSpeed;
			break;
		}


		transform.position = transform.position - new Vector3(currentSpeed/1000, 0, 0);

	}
}

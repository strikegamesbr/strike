using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {


	private speedType currentSpeedType;
	private float currentSpeed;

	[SerializeField]
	private BackBuildings backBuildings;

	[SerializeField]
	private float normalSpeed = 50, fastSpeed = 100, slowSpeed = 10;
	[SerializeField]
	private float defaultNormalSpeed = 50, defaultFastSpeed = 100, defaultSlowSpeed = 10;

	[SerializeField]
	Animator PlayerAnimator;

	bool lockSpeedChange = false; //só mude para Game Over

	public float NormalSpeed {
		get {
			return normalSpeed;
		}

		set {
			if (!lockSpeedChange)
				normalSpeed = value;
		}
	}


	public float FastSpeed {
		get {
			return fastSpeed;
		}

		set {
			if (!lockSpeedChange)
				fastSpeed = value;
		}
	}

	public float SlowSpeed {
		get {
			return slowSpeed;
		}

		set {
			if (!lockSpeedChange)
				slowSpeed = value;
		}
	}


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


	public IEnumerator stopTrackForSeconds (float seconds)
	{
		//atenção: não há a certeza de que o stopcoroutine abaixo funcione do que jeito que está
		StopCoroutine ("stopTrackForSeconds");

		stopTrack ();

		//a rotina abaixo e a parada a seguir devem durar o mesmo tempo
		StartCoroutine (backBuildings.stopTrackForSeconds (seconds));
		yield return new WaitForSeconds(seconds);

		returnTrackToGo ();

	}

	public void stopTrack ()
	{
		NormalSpeed = 0;
		FastSpeed = 0;
		SlowSpeed = 0;
	}


	public void returnTrackToGo ()
	{
		NormalSpeed = defaultNormalSpeed;
		FastSpeed = defaultFastSpeed;
		SlowSpeed = defaultSlowSpeed;
	}

	//só para GameOver
	public void stopTrackAndLock ()
	{
		NormalSpeed = 0;
		FastSpeed = 0;
		SlowSpeed = 0;

		lockSpeedChange = true;

		backBuildings.stopTrackAndLock ();
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

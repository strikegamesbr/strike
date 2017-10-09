using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBuildings : MonoBehaviour {

	[SerializeField]
	private float 	speed = 10, defaultSpeed = 10;


	public float Speed {
		get {
			return speed;
		}

		set {
			if (!lockSpeedChange)
				speed = value;
		}
	}

	bool lockSpeedChange = false; //só mude para Game Over


	// Use this for initialization
	void Start () {
		
	}


	public IEnumerator stopTrackForSeconds (float seconds)
	{

		Speed = 0;

		yield return new WaitForSeconds(seconds);

		Speed = defaultSpeed;

	}

	//só para GameOver
	public void stopTrackAndLock ()
	{
		Speed = 0;

		lockSpeedChange = true;
	}


	void 



	// Update is called once per frame
	void Update () {

		transform.position = transform.position - new Vector3((speed*Time.deltaTime)/10, 0, 0);

	}
}

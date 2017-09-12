using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBuildings : MonoBehaviour {

	[SerializeField]
	float 	speed = 10;



	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {

		transform.position = transform.position - new Vector3(speed/1000, 0, 0);

	}
}

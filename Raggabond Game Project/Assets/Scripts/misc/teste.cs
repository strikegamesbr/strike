using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour {

	public GameObject t1, t2;
	// Use this for initialization
	void Start () {

		if (t1 == t2)
			print ("iguais");
		else
			print ("diferentes");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

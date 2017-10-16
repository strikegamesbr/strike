using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//o objeto que tiver este script se "move" junto com a pista, como se estivesse parado nele.
//os objetos já tem speed neles em outros scripts, só use este em coisas novas
public class TrackSpeed : MonoBehaviour {


	private Track track;
	private float speed = 0;


	public float Speed {
		get {
			return speed;
		}

		set {
			speed = value;
		}
	}


	// Use this for initialization
	void Start () {
	
		track = FindObjectOfType <Track> ();

	}
	
	// Update is called once per frame
	void Update () {

		//anda junto com o track, ou até simula andar com uma velocidade speed sobre a pista
		transform.position = transform.position + new Vector3( ( (-track.CurrentSpeed+speed) * Time.deltaTime )/10 , 0, 0);
		
	}
}

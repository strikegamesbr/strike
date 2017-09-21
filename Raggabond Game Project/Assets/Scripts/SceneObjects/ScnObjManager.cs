using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScnObjManager : MonoBehaviour {

	[SerializeField]
	private Material normalMaterial, hurtMaterial, pointMaterial;

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private float timeStoppedByDamage = 1, timeChangedMaterialPositively=1;

	public float 	yUpperPatinadora, yMediumPatinadora, yLowerPatinadora,
					yUpperSkatista, yMediumSkatista, yLowerSkatista,
					yUpperBeachBall, yMediumBeachBall, yLowerBeachBall,
					yUpperApple, yMediumApple, yLowerApple,
					yUpperGuitar, yMediumGuitar, yLowerGuitar,
					yUpperLilMario, yMediumLilMario, yLowerLilMario;


	public ulong scoreApple = 10, scoreGuitar = 100, scoreLilMario = 100;
	public int livesApple = 0, livesGuitar = 0, livesLilMario = 1;
	public int danoSkatista = 1, danoPatinadora = 1, danoBeachBall = 1;



	public Material NormalMaterial {
		get {
			return normalMaterial;
		}
	}

	public Material HurtMaterial {
		get {
			return hurtMaterial;
		}
	}

	public Material PointMaterial {
		get {
			return pointMaterial;
		}
	}

	public GameObject Player {
		get {
			return player;
		}
	}

	public float TimeDamage {
		get {
			return timeStoppedByDamage;
		}
	}

	public float TimePositiveItem {
		get {
			return timeChangedMaterialPositively;
		}
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreByTimeManager : MonoBehaviour {

	[SerializeField]
	private Track track;
	private PlayerState playerState;

	[SerializeField]
	private ulong pointsPerSecondNormal = 5;//, pointsPerSecondFast = 15, pointsPerSecondSlow = 5;


	public bool haltGainingPoints = false;



	// Use this for initialization
	void Start () {
		playerState = GetComponent<PlayerState> ();

		StartCoroutine (gainPointsPerSeconds ());

	}


	IEnumerator gainPointsPerSeconds ()
	{
		bool gainPoints = true;

		while (true) {

			yield return new WaitForSeconds (1); 

			if (!haltGainingPoints) {
					playerState.Score = playerState.Score + pointsPerSecondNormal;
			}

		}

	}

	
	// Update is called once per frame
	void Update () {





	}
}

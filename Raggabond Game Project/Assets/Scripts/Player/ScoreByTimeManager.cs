using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreByTimeManager : MonoBehaviour {

	[SerializeField]
	private Track track;
	private PlayerState playerState;

	[SerializeField]
	private ulong pointsPerSecondNormal = 10, pointsPerSecondFast = 15, pointsPerSecondSlow = 5;


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

			yield return new WaitForSeconds (0.1f); 

			if (!haltGainingPoints) {

				switch (track.CurrentSpeedType) {

				case speedType.normal:
					playerState.Score = playerState.Score + pointsPerSecondNormal / 10;
					break;

				case speedType.fast:
					playerState.Score = playerState.Score + pointsPerSecondFast / 10;
					break;

				case speedType.slow:
					playerState.Score = playerState.Score + pointsPerSecondSlow / 10;
					break;

				}
			}

		}

	}

	
	// Update is called once per frame
	void Update () {





	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForLoading : MonoBehaviour {


	[SerializeField]
	private Transform baseScreen;

	[SerializeField]
	private Transform toSpin;

	private AsyncOperation async;


//	[SerializeField]
//	public float timeBeforeShowingScreen = 2f;


	private float previousProgress = 0;


	// Use this for initialization
	void Start () {

		async = SceneManager.LoadSceneAsync ("MainScene");

	}
	
	// Update is called once per frame
	void Update () {
		
		if (!async.isDone) {
			try {
				toSpin.Rotate (0, 0, -150 * Time.deltaTime);
			} catch {
			}
		}

	}



}

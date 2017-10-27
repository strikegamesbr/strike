using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointfulScnObj : SceneObjects { //SceneObjects herda de MonoBehaviour

	bool lockFurtherUse = false;


	// Use this for initialization
	void Start () {
		toStart ();
	}


	void OnTriggerStay2D (Collider2D col) {		
		checkAndUseItem (col);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		checkAndUseItem (col);
	}


	private void checkAndUseItem (Collider2D col) {
		if (col.name == "Player" && col.GetComponent<PlayerState> ().Lane == this.Lane) {
			
			useItem ();
		} 
	}



	private void useItem ()
	{

		if (!lockFurtherUse) {

			debug.debugLog (9);
//			Debug.Log ("Pegou item " + Kind + " (009)");

			lockFurtherUse = true; //vai ser destrancado quando o objeto for desabilitado

			ulong scoreToGain = 0;
			int livesToGain = 0;

			if (gameObject.name.Contains("coin")) {
				scoreToGain = scnObjManager.scoreApple;
				livesToGain = scnObjManager.livesApple; //é 0, mas pode mudar
			} else if (gameObject.name.Contains("guitar")) {
				scoreToGain = scnObjManager.scoreGuitar;
				livesToGain = scnObjManager.livesGuitar; //é 0, mas pode mudar
			} else if (gameObject.name.Contains("lilMario")) {
				scoreToGain = scnObjManager.scoreLilMario;
				livesToGain = scnObjManager.livesLilMario; //é 1, mas pode mudar
			}

			playerState.gainScoreLives (scoreToGain, livesToGain);

			StartCoroutine (playerGetPointsFromObjRoutine ());
			scnObjManager.showScoreGained(scoreToGain, this.transform);

		}

	}


	IEnumerator lockFurtherUseForSeconds(float seconds)
	{
		lockFurtherUse = true;
		yield return new WaitForSeconds (seconds);
		lockFurtherUse = false;
	}

	//somente as animações associadas, não a pontuação (vida?) em si
	IEnumerator playerGetPointsFromObjRoutine ()
	{
		//as instruções pra valer começam agora
		sounds.playCollectitemSfx ();
		yield return new WaitForSeconds (scnObjManager.TimeDamage/3);

//		scnObjManager.simulActivInactivObj (this.gameObject, false);
		gameObject.SetActive(false); //para destruir
	}



	void OnBecameVisible ()
	{

		//se for a câmera do editor do Unity não interessa
		#if UNITY_EDITOR
		if (Camera.current.name == "SceneCamera") 
			return;
		#endif
		// put your code here

		IsVisible = true;

	}


	void OnBecameInvisible ()
	{
		//se for a câmera do editor do Unity não interessa
//		#if UNITY_EDITOR
//		try {
//		if (Camera.current.name == "SceneCamera") 
//			return;
//		} catch {}
//		#endif
		// put your code here

		IsVisible = false;
		Taken = false; //se ficou invisível pode ficar disponível para outros blocos


	}


	void OnEnable () {
		lockFurtherUse = false;
	}


	void OnDestroy ()
	{
//		print ("destruído?" + this.gameObject.name);

	}


	// Update is called once per frame
	void Update () {
		toUpdate ();
	}
}

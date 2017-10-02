using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtfulScnObj : SceneObjects { //SceneObjects herda de MonoBehaviour


	bool lockDamage = false;


	// Use this for initialization
	void Start () {
		toStart ();
	}

	void OnTriggerStay2D (Collider2D col) {
		OnTriggerEnter2D (col);
	}


	void OnTriggerEnter2D (Collider2D col)
	{

//		print ("sem condição funciona 1");

		if (col.name == "Player" && col.GetComponent<PlayerState> ().Lane == this.Lane) {
			damagePlayer ();
		}

		if (col.name == "destroyer") {
			Destroy (this.gameObject);
		}

	}


	private void damagePlayer ()
	{

		if (!lockDamage) {
			lockDamage = true; //não precisa voltar a ser falso pois será destruído
			playerState.gameObject.GetComponent<ScoreByTimeManager>().HaltGainingPoints = true;


			int damageToTake = 0;

			if (gameObject.name.Contains ("skatista"))
				damageToTake = scnObjManager.danoSkatista;
			else if (gameObject.name.Contains ("patinadora"))
				damageToTake = scnObjManager.danoPatinadora;
			else if (gameObject.name.Contains ("beachBall"))
				damageToTake = scnObjManager.danoBeachBall;

			playerState.takeDamage (damageToTake);

			StartCoroutine (damagePlayerRoutine ());
		}

	}



	//somente as animações associadas, não o dano em si (nem a retirada de um mario/vida na UI, nem o Game Over)
	IEnumerator damagePlayerRoutine ()
	{

		//mudar material de player e dele mesmo

		//vamos colocar valores necessários em variáveis locais
		Material hurtMat = scnObjManager.HurtMaterial;
		Material normalMat = scnObjManager.NormalMaterial;
		GameObject player = scnObjManager.Player;
		float timeToWait = scnObjManager.TimeDamage;

		SpriteRenderer srHurtObj = GetComponent<SpriteRenderer> ();
		SpriteRenderer srPlayer = player.GetComponent<SpriteRenderer> ();


		//as instruções pra valer começam agora
		//tanto a corotina abaixo quanto a espera devem durar o mesmo tempo
		//a rotina abaixo pára a estrada

		StartCoroutine (track ().stopTrackForSeconds(timeToWait));

		sounds.playCollideSfx ();
		srHurtObj.material = hurtMat;
		srPlayer.material = hurtMat;
		yield return new WaitForSeconds (timeToWait/3);
		srHurtObj.material = normalMat;
		srPlayer.material = normalMat;
		yield return new WaitForSeconds (timeToWait/3);
		srHurtObj.material = hurtMat;
		srPlayer.material = hurtMat;
		yield return new WaitForSeconds (timeToWait/3);
		srHurtObj.material = normalMat;
		srPlayer.material = normalMat;

		if (!playerState.GameOver)
			playerState.gameObject.GetComponent<ScoreByTimeManager>().HaltGainingPoints = false;

		Destroy (this.gameObject);

	}


	private Track track ()
	{
		return transform.parent.parent.GetComponent<Track> ();
	}


	
	// Update is called once per frame
	void Update () {
		toUpdate ();
	}
}

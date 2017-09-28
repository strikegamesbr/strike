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
		OnTriggerEnter2D (col);
	}

	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.name == "Player" && col.GetComponent<PlayerState> ().Lane == this.Lane) {

			useItem ();

		} else if (col.name == "destroyer")
			Destroy (this.gameObject);
	}


	private void useItem ()
	{

		if (!lockFurtherUse) {

			lockFurtherUse = true; //não precisa voltar a ser falso pois será destruído

			ulong scoreToGain = 0;
			int livesToGain = 0;

			if (gameObject.name.Contains("apple")) {
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


	//somente as animações associadas, não a pontuação (vida?) em si
	IEnumerator playerGetPointsFromObjRoutine ()
	{

		//mudar material de player e dele mesmo

		//vamos colocar valores necessários em variáveis locais
		Material pointMat = scnObjManager.PointMaterial;
		Material normalMat = scnObjManager.NormalMaterial;
		GameObject player = scnObjManager.Player;
		float timeToWait = scnObjManager.TimeDamage;

		SpriteRenderer srPointObj = GetComponent<SpriteRenderer> ();
		SpriteRenderer srPlayer = player.GetComponent<SpriteRenderer> ();


		//as instruções pra valer começam agora
		srPointObj.material = pointMat;
		srPlayer.material = pointMat;
		yield return new WaitForSeconds (timeToWait/3);
		srPointObj.material = normalMat;
		srPlayer.material = normalMat;
		srPointObj.enabled = false; //faz sumir;
		yield return new WaitForSeconds (timeToWait/3);
		srPointObj.material = pointMat;
		srPlayer.material = pointMat;
		yield return new WaitForSeconds (timeToWait/3);
		srPointObj.material = normalMat;
		srPlayer.material = normalMat;

		Destroy (this.gameObject); //para destruir
	}

//	//mostrar o score ganho ao pegar um item subindo
//	IEnumerator showScoreGained (ulong scoreToGain)
//	{
//		//instanciar o texto e escrever o valor da pontuação ganha
//		Text scoreText = Instantiate (scnObjManager.ScoreFromItemTextPrefab);
//		scoreText.text = scoreToGain.ToString ();
//
//		//colocá-lo na mesma posição do item, o que requer que tenha o mesmo parent do item
//		scoreText.transform.parent = transform.parent;
//		scoreText.transform.position = transform.position;
//
//		//agora vamos deixar o Canvas como parent para ele aparecer!
//		scoreText.transform.parent = scnObjManager.CanvasParent;
//
//
//		//agora vamos definir a posição de destino do texto
//		float destY = scoreText.transform.position.y + 3;
//
//		float speedUp = 4;
//
//		//e vamos fazê-lo subir até lá
//		while (destY - scoreText.transform.position.y > 2){
//			yield return new WaitForEndOfFrame ();
//			scoreText.rectTransform.position = scoreText.rectTransform.position + new Vector3 (0, speedUp*Time.deltaTime, 0);
//		}
//
//
//		Destroy (scoreText.gameObject);
//
//	}



	// Update is called once per frame
	void Update () {
		toUpdate ();
	}
}

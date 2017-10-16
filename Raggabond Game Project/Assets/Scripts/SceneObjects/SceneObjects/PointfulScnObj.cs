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
//		print ("col.name=" + col.name + " gameObject.name=" + gameObject.name);

		if (col.name == "Player" && col.GetComponent<PlayerState> ().Lane == this.Lane) {			
			useItem ();
		}  
//		else if (col.name == "destroyer")
//			this.gameObject.SetActive(false);;
	}


	private void useItem ()
	{

		if (!lockFurtherUse) {


//			lockFurtherUse = true; //não precisa voltar a ser falso pois será destruído

//			StartCoroutine(lockFurtherUseForSeconds(3));

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
		#if UNITY_EDITOR
		try {
		if (Camera.current.name == "SceneCamera") 
			return;
		} catch {}
		#endif
		// put your code here

		IsVisible = false;
		Taken = false; //se ficou invisível pode ficar disponível para outros blocos


	}


	void OnEnable () {
		lockFurtherUse = false;
	}


	//não delete abaixo ainda, é o código com shader
//	//somente as animações associadas, não a pontuação (vida?) em si
//	IEnumerator playerGetPointsFromObjRoutine ()
//	{
//
//		//mudar material de player e dele mesmo
//
//		//vamos colocar valores necessários em variáveis locais
////		Material pointMat = scnObjManager.PointMaterial;
////		Material normalMat = scnObjManager.NormalMaterial;
////		GameObject player = scnObjManager.Player;
//		float timeToWait = scnObjManager.TimeDamage;
//
//		SpriteRenderer srPointObj = GetComponent<SpriteRenderer> ();
////		SpriteRenderer srPlayer = player.GetComponent<SpriteRenderer> ();
//
//
//		//as instruções pra valer começam agora
//		sounds.playCollectitemSfx ();
////		srPointObj.material = pointMat;
////		srPlayer.material = pointMat;
//		yield return new WaitForSeconds (timeToWait/3);
////		srPointObj.material = normalMat;
////		srPlayer.material = normalMat;
//		srPointObj.enabled = false; //faz sumir;
////		yield return new WaitForSeconds (timeToWait/3);
////		srPointObj.material = pointMat;
////		srPlayer.material = pointMat;
////		yield return new WaitForSeconds (timeToWait/3);
////		srPointObj.material = normalMat;
////		srPlayer.material = normalMat;
//
//		Destroy (this.gameObject); //para destruir
//	}

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


	void OnDestroy ()
	{
		print ("destruído?");

	}


	// Update is called once per frame
	void Update () {
		toUpdate ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScnObjManager : MonoBehaviour {


	[SerializeField]
	public bool EmptyStreetsForTesting = false;

	[SerializeField]
	private Material normalMaterial, hurtMaterial, pointMaterial;

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private Transform canvasParent; //para colocar objetos UI como filhos dele

	public Text ScoreFromItemTextPrefab;

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


	public float speedApple = 0, speedGuitar = 0, speedLilMario = 0;
	public float speedSkatista = 50, speedPatinadora = 70, speedBeachBall = 30;


	[SerializeField]
	private int numMovableObjects=0, maxNumMovableObjects=3;


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

	public Transform CanvasParent {
		get {
			return canvasParent;
		}
	}



//	//se desativar aqui deve ativar por aqui tb
//	public void simulActivInactivObj(GameObject gObject, bool activate) 
//	{
//
//		gObject.GetComponent<SpriteRenderer> ().enabled = activate;
////		gObject.GetComponent<BoxCollider2D> ().enabled = activate;
//
//	}


	//mostrar o score ganho ao pegar um item subindo
	public void showScoreGained  (ulong scoreToGain, Transform item)
	{
		StartCoroutine (showScoreGainedRoutine (scoreToGain, item));
	}


	//mostrar o score ganho ao pegar um item subindo
	IEnumerator showScoreGainedRoutine (ulong scoreToGain, Transform item) //lembre-se que este item será logo destruído, use antes do frame passar
	{
		//instanciar o texto e escrever o valor da pontuação ganha
		Text scoreText = Instantiate (ScoreFromItemTextPrefab);
		scoreText.text = scoreToGain.ToString ();

		scoreText.text = string.Concat ("+", scoreText.text);


		//colocá-lo na mesma posição do item, o que requer que tenha o mesmo parent do item
		scoreText.transform.parent = item.transform.parent;
		scoreText.transform.position = item.transform.position;

		//agora vamos deixar o Canvas como parent para ele aparecer!
		scoreText.transform.parent = CanvasParent;


		//agora vamos definir a posição de destino do texto, que fica na linha da cabeça do player
		float destY = player.transform.position.y + 4;

		float speedUp = 3.5f;

		//e vamos fazê-lo subir até lá
		while (destY - scoreText.transform.position.y > 2){
			yield return new WaitForEndOfFrame ();
			scoreText.rectTransform.position = scoreText.rectTransform.position + new Vector3 (0, speedUp*Time.deltaTime, 0);
		}


		Destroy (scoreText.gameObject);

	}

	//avisa que um objeto se tornou visível ao mesmo tempo que pergunta se deve se auto-destruir
	public bool destroyOneMovableObjectBecameVisible () {

		if (numMovableObjects < maxNumMovableObjects) {
			numMovableObjects++;
			return false;
		} else {
			return true;
		}

	}

	//avisa que um objeto se tornou invisível
	public void oneMovableObjectBecameInvisible () {

		if (numMovableObjects > 0) { //sanity check
			numMovableObjects--;
		}

	}




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumMovableObjsManager : MonoBehaviour {


	[SerializeField]
	private int numMovableObjects=0, maxNumMovableObjects=3;


	// Use this for initialization
	void Start () {
		
	}


	///avisa que um objeto se tornou visível - a depender o objeto pode ser destruído
	public void OneMovableObjectBecameVisible (GameObject obj) {

		if (numMovableObjects < maxNumMovableObjects) {
			numMovableObjects++;
		} else {
			disappearWith (obj);
		}

	}


	private void disappearWith (GameObject obj)
	{

		//destroyer é o lixo dos objetos, quando colidem com ele são destruídos
		//logo, levar o objeto a ele é o mesmo que destruí-lo

		obj.GetComponent<HurtfulScnObj> ().Speed = 0;
		obj.GetComponent<BoxCollider2D> ().enabled = false;
		obj.GetComponent<SpriteRenderer> ().enabled = false;


		StartCoroutine (destroyRoutine (obj));

	}


	IEnumerator destroyRoutine (GameObject obj) {


		obj.transform.parent = null;

//		int tentativas = 0;

		//tem sido sempre depois de dois loops, somente por segurança que não fixou aqui
		while (obj != null) {

			try {
				Destroy(obj);
			} catch {}

//			tentativas++;

			yield return new WaitForEndOfFrame ();

		}

//		print ("Conseguiu destruir depois de " + tentativas + " tentativas.");

	}



	///avisa que um objeto se tornou invisível
	public void oneMovableObjectBecameInvisible () {

		if (numMovableObjects > 0) { //sanity check
			numMovableObjects--;
		}


	}

	
	// Update is called once per frame
	void Update () {
		
	}
}

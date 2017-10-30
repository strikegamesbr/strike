using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingAux : MonoBehaviour {

	//esta função funciona quando há um objeto inicial visível já colocado no editor  (NOTA: acabou sendo a instanciação do primeiro)
	//prefabsToFillPool não deve conter o mesmo de startVisibleObj a não ser que uma cópia dele seja desejável
	//PoolArray é o array de objetos que será preenchido
	//prefabsToFillPool são os prefabs dos objetos que preencherão PoolArray, serão instanciados aqui
	//mais um objeto ocupará PoolArray, e é startVisibleObj - ele é o objeto inicial, aparecerá na tela
	//ele já deve estar colocado no editor - a rotação dos outros será copiada dele
	public void toStart(ref GameObject[] PoolArray, Transform[] prefabsToFillPool, Transform startVisibleObj, Transform parent) 
	{

		PoolArray = new GameObject[prefabsToFillPool.Length + 1];

		//vamos preencher PoolArray
		//para o primeiro vamos colocar o que já está colocado na cena no editor
		PoolArray[0] = startVisibleObj.gameObject;
		PoolArray [0].SetActive (true); //se certifica de que ele está visível na tela

		//os outros são instâncias de prefabsToFillPool
		//começarão invisíveis na tela
		for (int i = 0; i < prefabsToFillPool.Length; i++) {

			PoolArray [i + 1] = Instantiate (prefabsToFillPool [i].gameObject);
			PoolArray [i + 1].transform.parent = parent;
			PoolArray[i + 1].transform.rotation = startVisibleObj.rotation;

			//este novo deve estar invisível para não aparecer na tela
			PoolArray [i + 1].SetActive (false);

		}

	}





	//garante que não retorna previousObject, mas qualquer outro aleatoriamente
	//é aqui que o objeto é tornado visível
	private GameObject nextObject (GameObject[] PoolArray, Transform previousObject) 
	{

		if (PoolArray.Length < 2)
			return null;

		int i, j = -1;

		//vamos descobrir qual o objeto pevious no array, com index indo a j
		for (i = 0; i < PoolArray.Length; i++) {

			if (PoolArray [i] == previousObject.gameObject)
				break;			
		}

		//agora i tem o índice do valor anterior, que não queremos
		//vamos escolher outro aleatoriamente
		//este if é para garantir que o previousObject está no PoolArray
		if (i >= 0 && i < PoolArray.Length) { 
			do {				
				j = Random.Range (0, PoolArray.Length);
			} while (j == i);

			PoolArray [j].SetActive (true); //se certifica de que fica visível
			return PoolArray [j];

		} else {
			Debug.Log ("Objeto " + previousObject.name + " não está no Array " + PoolArray.ToString());
			j = Random.Range (0, PoolArray.Length);
			PoolArray [j].SetActive (true);
			return PoolArray [j]; 
//			return null;
		}


//		if (j >= 0 && j < PoolArray.Length) { //sanity check
//			PoolArray [j].SetActive (true); //se certifica de que fica visível
//			return PoolArray [j];
//		}
//		else
//			return null;

	}


	//pega o objeto no pool e deixa ele na posição na tela
	//o nome 'create' é meio enganador
	public void createObject (GameObject[] PoolArray, ref Transform previousObject, Vector3 newPosition)
	{
		
		//cria o floor na mesma posição de previous com x + 0.5*previousTrack.localScale.x (0.5 é metade do comprimento padrão de Quad)
		GameObject newObject = nextObject(PoolArray, previousObject);
		newObject.transform.position = newPosition;

		//previousTrack = novo track
		previousObject = newObject.transform;

	}


	//pega o objeto no pool sem mexer em sua posição e o retorna
	//o nome 'create' é meio enganador
	public GameObject createObject (GameObject[] PoolArray, ref Transform previousObject)
	{

		//cria o floor na mesma posição de previous com x + 0.5*previousTrack.localScale.x (0.5 é metade do comprimento padrão de Quad)
		GameObject newObject = nextObject(PoolArray, previousObject);

		//previousTrack = novo track
		previousObject = newObject.transform;

		return newObject;

	}



}

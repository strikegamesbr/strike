using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour {


//	[SerializeField]
//	private GameObject coinPrefab, conePrefab, guitarPrefab, lilMarioPrefab, patinadoraPrefab, 
//				patinadora_varPrefab, skatistaPrefab, skatista_varPrefab;

	[SerializeField]
	private  GameObject[] coins, cones, guitars, lilMarios, patinadoras,					
				patinadora_var, skatista, skatista_var;


	//WARNING: verifique se funciona em objetos inativos
	//pega um objeto que não está visível na tela
	//NÃO torna o objeto visível, cerifique-se de ativá-la
	public GameObject getObject (kindObj ofKind) {

//		print ("ofKind = " + ofKind);

		GameObject[] goArray;

		switch (ofKind) {

		case kindObj.coin:
			goArray = coins;
			break;
		case kindObj.cone:
			goArray = cones;
			break;
		case kindObj.guitar:
			goArray = guitars;
			break;
		case kindObj.lilMario:
			goArray = lilMarios;
			break;
		case kindObj.patinadora:
			goArray = patinadoras;
			break;
		case kindObj.patinadora_var:
			goArray = patinadora_var;
			break;
		case kindObj.skatista:
			goArray = skatista;
			break;
		case kindObj.skatista_var:
			goArray = skatista_var;
			break;
		default:
			goArray = new GameObject[0]; //se não for um de cima, está errado
			break;
		}


		foreach (GameObject obj in goArray) {
//			obj.SetActive (true);
			//vamos pegar o componente SceneObjects correto
			SceneObjects sceneObject; //pode ser PointfulScnObj ou HurtfulScnObj em gObject
			sceneObject = obj.GetComponent<PointfulScnObj> () as SceneObjects;
			if (sceneObject == null)
				sceneObject = obj.GetComponent<HurtfulScnObj> () as SceneObjects;

			//e checar se está invisível, para poder pegá-lo
			if (!sceneObject.IsVisible && !sceneObject.Taken) {
//				print ("Is not visible");
				sceneObject.Taken = true; //vamos pegar este
				return obj;
			} else {
//				print ("Is visible");
			}

//			obj.SetActive (false); //se chegou aqui o return acima não foi ativado
		}

		//se chegou aqui, todos os objetos são visíveis, não dá para pegar
		return null;

	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

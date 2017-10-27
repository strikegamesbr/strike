using System;
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

	private Type pointfulType; //para usar em HasScriptAsComponent()




	// Use this for initialization
	void Start () {
		pointfulType = (new PointfulScnObj().GetType());
	}


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
//			print ("ESTÁ ERRADO! ofKind = " + ofKind);
			goArray = new GameObject[0]; //se não for um de cima, está errado
			break;
		}

//		Debug.Assert (goArray.Length > 0);


//		for (int i = 0; i < goArray.Length; i++) {
//			print ("ofKind = " + ofKind + " no index " + i);
//			goArray [i].SetActive(goArray [i].activeSelf);
//		}



		foreach (GameObject obj in goArray) {
//			obj.SetActive (true);
			//vamos pegar o componente SceneObjects correto
			SceneObjects sceneObject; //pode ser PointfulScnObj ou HurtfulScnObj em gObject


			if (HasScriptAsComponent(obj, pointfulType)) {
				sceneObject = obj.GetComponent<PointfulScnObj> () as SceneObjects;
			} else {//deve ter HurtfulScnObj
				sceneObject = obj.GetComponent<HurtfulScnObj> () as SceneObjects;
			}

			//obj deve ter um componente PointfulScnObj ou HurtfulScnObj, ou algo está errado com a implementação
			Debug.Assert (sceneObject != null);
			
//			if (sceneObject == null)
//				sceneObject = obj.GetComponent<HurtfulScnObj> () as SceneObjects;

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



	private static bool HasScriptAsComponent(GameObject obj, Type ClassType )
	{
		Component[] cs = (Component[])obj.GetComponents(typeof(Component));
		foreach (Component c in cs)
		{

			if (c.GetType() == ClassType)
			{
				return true;
			}

		}
		return false;
	}






	
	// Update is called once per frame
	void Update () {
		
	}
}

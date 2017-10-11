using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour {


	[SerializeField]
	private GameObject coinPrefab, conePrefab, guitarPrefab, lilMarioPrefab, patinadoraPrefab, 
				patinadora_varPrefab, skatistaPrefab, skatista_varPrefab;

	[SerializeField]
	private  GameObject[] coins, cones, guitars, lilMarios, patinadoras,					
				patinadora_var, skatista, skatista_var;


	//WARNING: verifique se funciona em objetos inativos
	//pega uma moeda que não está visível na tela
	//NÃO torna a moeda visível, cerifique-se de ativá-la
	public GameObject getCoin () {

		foreach (GameObject coin in coins) {
			if (!coin.GetComponent<PointfulScnObj>().IsVisible)
				return coin;
		}

		//se chegou aqui, todos os objetos são visíveis
		return null;

	}






	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

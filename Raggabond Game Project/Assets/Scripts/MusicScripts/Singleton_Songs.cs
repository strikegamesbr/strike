using System.Collections;
using UnityEngine;

//IMPORTANTE!!!
//Copie este conteúdo para cada objeto, mas não coloque estre script diretamente. Ou só vai funcionar em um objeto

public class Singleton_Songs : MonoBehaviour {

	private static Singleton_Songs _instance;

	public static Singleton_Songs instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<Singleton_Songs>();

				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}

			return _instance;
		}
	}

	void Awake() 
	{
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}

	public void Play()
	{
		//Play some audio!
	}
}

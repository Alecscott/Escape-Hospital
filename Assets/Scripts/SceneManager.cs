using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	private Scene pCurrentScene;

	// public accessors
	public Scene getCurrentScene(){
		return getInstance().pCurrentScene;
	}
	public Scene setCurrentScene(Scene pNewScene){
		return getInstance().pCurrentScene = pNewScene;
	}

	//private functions
	private static SceneManager instance;

	private SceneManager(){
	}

	private static SceneManager getInstance(){
		if (instance == null) {
			instance = new SceneManager ();
		}
		return instance;
	}
}

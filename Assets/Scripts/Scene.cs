using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

	public string levelName;

	// Use this for initialization
	void onTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			SceneManager.LoadScene (levelName);
		}
	}
}

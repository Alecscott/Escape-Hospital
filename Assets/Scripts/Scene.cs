using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

	public string levelName;

	// Use this for initialization
	void OnTriggerEnter(Collider col){
		Debug.Log (col.tag);
		if (col.CompareTag ("Player")) {
			Debug.Log ("Got to Scene Load");
			SceneManager.LoadScene (levelName);
		}
	}
}

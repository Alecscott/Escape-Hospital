using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour {
	private GameObject door;
	// Use this for initialization
	void Start () {
		door = GameObject.FindGameObjectWithTag ("Door1");
		Debug.Log ("found");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter (Collider Col){
		if (Col.gameObject.tag == "Player") {
			door.GetComponent<Animator> ().SetBool ("Opening", true);
			Debug.Log ("Open");
		}
	}

	void OnTriggerExit (Collider Col){
		if (Col.gameObject.tag == "Player") {
			door.GetComponent<Animator>().SetBool ("Closing", true);
			Debug.Log ("Close");
		}
	}

}

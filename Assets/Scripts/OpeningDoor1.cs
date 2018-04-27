using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor1 : MonoBehaviour {
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
			door.GetComponent<Animator> ().SetBool ("Closing", false);
			Debug.Log ("Open");
		}
	}

	void OnTriggerExit (Collider Col){
		if (Col.gameObject.tag == "Player") {
			door.GetComponent<Animator>().SetBool ("Closing", true);
			door.GetComponent<Animator>().SetBool ("Opening", false);
			Debug.Log ("Close");
		}
	}

}

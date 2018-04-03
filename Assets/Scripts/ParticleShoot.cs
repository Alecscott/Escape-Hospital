using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShoot : MonoBehaviour {
	
	public ParticleSystem particleEffect;
	public bool firing;

	// Use this for initialization
	void Start () {
		firing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetAxis("RHandTrigger") == 1 || Input.GetAxis("LHandTrigger") == 1)){
			particleEffect.Play ();
		}
		if(Input.GetAxis("RHandTrigger") == 0){
			firing = true;
		}
	}
}

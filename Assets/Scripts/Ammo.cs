﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			ParticleShoot.ammoCount = ParticleShoot.ammoCount + 1;
			Destroy(this.gameObject)
		}
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShoot : MonoBehaviour {
	
	public ParticleSystem particleEffect;
	public bool firing;
	public GameObject player;
	private ParticleSystem p;
    private ParticleSystem.MainModule main;

    // Use this for initialization
    void Start () {
        p = null;
        //main = p.main;
        //main.loop = false;
        firing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetAxis("RightMainTrigger") == 1 || Input.GetAxis("LeftMainTrigger") == 1) && !firing){

            if (p == null)
            {
                p = (ParticleSystem)Instantiate(particleEffect, player.transform.position, player.transform.rotation);
                
            }
            
            main = p.main;

            firing = true;
            
			Debug.Log ("firing");
			p.Play ();
            main.loop = true;
			
		}
		if((Input.GetAxis("RightMainTrigger") == 0 && Input.GetAxis("LeftMainTrigger") == 0) && firing){
			//Debug.Log ("stop firing");
			p.Stop();
            main.loop = false;
            firing = false;
		}
	}
}

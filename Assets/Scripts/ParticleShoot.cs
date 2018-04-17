using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleShoot : MonoBehaviour {
	
	public ParticleSystem particleEffect;
	public bool firing;
	public GameObject player;
	private ParticleSystem p;
    private ParticleSystem.MainModule main;
	public float ammoCount = 0.0f;
	public Text uiText;
	public float vomitTime = 1;

    // Use this for initialization
    void Start () {
        p = null;
        //main = p.main;
        //main.loop = false;
        firing = false;
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetAxis("RightMainTrigger") == 1 || Input.GetAxis("LeftMainTrigger") == 1) && !firing && ammoCount > 0)
        {

            if (p == null) {
				Debug.Log("Initializing particle");
				p = (ParticleSystem)Instantiate (particleEffect, player.transform.position, player.transform.rotation);
                
			} else {
				Debug.Log ("Particle Position Updated");
				p.transform.position = player.transform.position;
				p.transform.rotation = player.transform.rotation;
			}
            
            main = p.main;

            
            firing = true;
            Debug.Log("firing");
            p.Play();

            main.loop = true;
			
		}
        if (firing)
        {
            ammoCount -= Time.deltaTime;
        }

        if (((Input.GetAxis("RightMainTrigger") == 0 && Input.GetAxis("LeftMainTrigger") == 0) && firing)||ammoCount<=0){
			//Debug.Log ("stop firing");
			p.Stop();
            main.loop = false;
            firing = false;
		}

	}
}

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
	public int ammoCount = 0;
	public Text uiText;

    // Use this for initialization
    void Start () {
        p = null;
        //main = p.main;
        //main.loop = false;
        firing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetAxis("RightMainTrigger") == 1 || Input.GetAxis("LeftMainTrigger") == 1) && !firing && ammoCount>0){

			if (p == null) {
				p = (ParticleSystem)Instantiate (particleEffect, player.transform.position, player.transform.rotation);
                
			} else {
				p.transform.position = player.transform.position;
				p.transform.rotation = player.transform.rotation;
			}
            
            main = p.main;

            firing = true;
            
			Debug.Log ("firing");
			p.Play ();
			ammoCount--;
            main.loop = true;
			
		}
		if((Input.GetAxis("RightMainTrigger") == 0 && Input.GetAxis("LeftMainTrigger") == 0) && firing){
			//Debug.Log ("stop firing");
			p.Stop();
            main.loop = false;
            firing = false;
		}
		uiText.text = ammoCount.ToString;
	}
}

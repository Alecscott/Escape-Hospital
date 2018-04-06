using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShoot : MonoBehaviour {
	
	public ParticleSystem particleEffect;
	public bool firing;
	public GameObject player;
	private ParticleSystem p;

	// Use this for initialization
	void Start () {
		firing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetAxis("RightMainTrigger") == 1 || Input.GetAxis("LeftMainTrigger") == 1) && !firing){
			p = (ParticleSystem)Instantiate (particleEffect,player.transform.position,player.transform.rotation);
			Debug.Log ("firing");
			firing = true;
			p.Play ();
			Destroy (p, p.main.duration);
		}
		if((Input.GetAxis("RightMainTrigger") == 0 && Input.GetAxis("LeftMainTrigger") == 0) && firing){
			//Debug.Log ("stop firing");
			//p.Stop();
			firing = false;
		}
	}
}

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
		if((Input.GetAxis("RightMainTrigger") == 1 || Input.GetAxis("LeftMainTrigger") == 1)){
			p = ParticleSystem.Instantiate (particleEffect);
			Debug.Log ("firing");
			firing = true;
			p.transform.position = player.transform.position;
			p.Play ();
		}
		if(Input.GetAxis("RightMainTrigger") == 0|| Input.GetAxis("LeftMainTrigger") == 0){
			//Debug.Log ("stop firing");
			ParticleSystem.Destroy (p);
			firing = false;
		}
	}
}

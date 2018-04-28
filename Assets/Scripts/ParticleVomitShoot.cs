using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleVomitShoot : MonoBehaviour {

	public ParticleSystem particleEffect;
	public bool firing;
	public GameObject player;
	private ParticleSystem p;
	private ParticleSystem.MainModule main;
	public static float ammoCount = 0.0f;
	public Text uiText;
	public float vomitTime = 1;
	private SoundManager soundManager;

	// Use this for initialization
	void Start () {
		p = null;
		Debug.Log ("start");
		//main = p.main;
		//main.loop = false;
		firing = false;
		soundManager = (SoundManager)GameObject.Find ("SoundManager").GetComponent (typeof(SoundManager));

	}

	// Update is called once per frame
	void Update () {
		if (p == null) {
			Debug.Log("Initializing particle");
			p = (ParticleSystem)Instantiate (particleEffect, player.transform.position, player.transform.rotation);
			p.Stop ();

		} 

		if ((Input.GetAxis("RightMainTrigger") == 1 || Input.GetAxis("LeftMainTrigger") == 1)&& !firing && ammoCount > 0)
		{
			Debug.Log (p);

			Debug.Log ("Particle Position Updated");
			p.transform.position = player.transform.position;
			p.transform.rotation = player.transform.rotation;


			main = p.main;


			firing = true;
			Debug.Log("firing");
			p.Play();

			main.loop = true;
			soundManager.PlayAudioClip ("vomit");

		}
		if (firing)
		{
			ammoCount -= Time.deltaTime;
		}

		if (((Input.GetAxis("RightMainTrigger") == 0 && Input.GetAxis("LeftMainTrigger") == 0) && firing)||ammoCount<=0){
			//Debug.Log ("stop firing");
			p.Stop();
			soundManager.EndAudioClip("vomit");
			if (main.loop) {
				main.loop = false;
			}
			firing = false;
		}

	}
}

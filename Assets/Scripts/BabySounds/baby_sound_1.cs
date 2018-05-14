using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baby_sound_1 : MonoBehaviour {

	public AudioClip audioClip;
	private AudioSource source;
	public int alarmTime;
	private int counter;
	private SoundManager manager;

	// Use this for initialization
	void Start () {
		counter = 0;
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (counter >= alarmTime) 
		{
			source.Play ();
			counter = 0;
		}
		counter++;
	}
}

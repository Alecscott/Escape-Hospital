using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	// Use this for initialization
	public AudioClip[] audioClips;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	public void PlayAudioClip(string clipName)
	{
		foreach (AudioClip clip in audioClips) 
		{
			if (clip.name == clipName) 
			{
				audioSource.PlayOneShot (clip);
			}
		}
	}

	public void PlayAudioClipRepeated(string clipName)
	{
		foreach (AudioClip clip in audioClips) 
		{
			if (clip.name == clipName) 
			{
				audioSource.PlayOneShot(clip);
			}
		}
	}

	public void EndAudioClip(string clipName)
	{
		foreach (AudioClip clip in audioClips) 
		{
			if (clip.name == clipName) 
			{
				audioSource.clip = clip;
				audioSource.Stop ();
			}
		}
	}
}

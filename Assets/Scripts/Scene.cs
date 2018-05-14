using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene : MonoBehaviour {

	public Image fadeOutImg;
	public float fadeSpeed = 0.8f; 

	public string levelName;

	void OnEnable(){
		StartCoroutine (Fade(1,0));
	}

	// Use this for initialization
	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			//Debug.Log ("Got to Scene Load");
			StartCoroutine (FadeAndLoadScene(0,1));
		}
	}

	private IEnumerator Fade(float fadeStart,float fadeEnd){
		Debug.Log ("Fading");
		if (fadeStart > fadeEnd) {
			Debug.Log("In");
			while (fadeStart >= fadeEnd) {
				SetColorImage (ref fadeStart, fadeEnd);
				//SetColorImage (ref fadeEnd, fadeStart);
				yield return null;
			}
			fadeOutImg.enabled = false;
		} else {
			Debug.Log ("Out");
			fadeOutImg.enabled = true;
			while (fadeStart < fadeEnd) {
				SetColorImage (ref fadeStart,fadeEnd);
				//SetColorImage (ref fadeEnd, fadeStart);
				yield return null;
			}
		}
	}

	private IEnumerator FadeAndLoadScene(float fadeStart, float fadeEnd) 
	{
		//yield return Fade(fadeStart, fadeEnd);
		StartCoroutine (Fade(0,1));
		SceneManager.LoadScene(levelName);
		yield return null;
	}

	private void SetColorImage(ref float alpha, float end)
	{
		fadeOutImg.color = new Color (fadeOutImg.color.r,fadeOutImg.color.g, fadeOutImg.color.b, alpha);
		if (alpha < end) {
			alpha += Time.deltaTime * (1.0f / fadeSpeed);
		} else {
			alpha -= Time.deltaTime * (1.0f / fadeSpeed);
		}
	}
}

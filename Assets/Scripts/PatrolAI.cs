using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class PatrolAI : MonoBehaviour {

	public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;
	public bool chasingPlayer = false;
	public int timeChase;
	private Transform player;
	public Transform enemySpawn;


	public Image fadeOutImg;
	public float fadeSpeed = 0.8f; 

	public string levelName;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.autoBraking = false;
		GotoNextPoint ();
	}

	void GotoNextPoint(){
		if (points.Length == 0) {
			return;
		}

		agent.destination = points [destPoint].position;
		destPoint = (destPoint + 1) % points.Length;
	}
	// Update is called once per frame
	void Update () {
		StartCoroutine (FindPlayer());
		if (!agent.pathPending && agent.remainingDistance < 0.5f && !chasingPlayer) {
			GotoNextPoint ();
		} else if (chasingPlayer) {
			agent.destination = player.position;
		}
	}

	void OnTriggerEnter(Collider col){
		Debug.Log (col.tag);
		if (col.CompareTag ("Player")) {
			StartCoroutine (FadeAndLoadScene(0,1));
		}
	}

	void OnParticleCollision(GameObject sys){
		Debug.Log("Running Away");
		agent.destination = enemySpawn.position;
	}

	IEnumerator FindPlayer(){
		RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out hit)) {
				if (hit.collider.CompareTag ("Player")) {
					chasingPlayer = true;
					player = hit.transform;
					//Debug.Log ("Raycast Hit");
				} else {
					if (chasingPlayer == true) {
						yield return new WaitForSeconds (timeChase);
					}
					chasingPlayer = false;
				}
			}
		}

	private IEnumerator Fade(float fadeStart,float fadeEnd){
		Debug.Log ("Fading");
		if (fadeStart > fadeEnd) {
			Debug.Log("In");
			while (fadeStart >= fadeEnd) {
				SetColorImage (ref fadeStart, fadeEnd);
				yield return null;
			}
			fadeOutImg.enabled = false;
		} else {
			Debug.Log ("Out");
			fadeOutImg.enabled = true;
			while (fadeStart <= fadeEnd) {
				SetColorImage (ref fadeStart,fadeEnd);
				yield return null;
			}
		}
	}

	private IEnumerator FadeAndLoadScene(float fadeStart, float fadeEnd) 
	{
		yield return Fade(fadeStart, fadeEnd);
		SceneManager.LoadScene(levelName);
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

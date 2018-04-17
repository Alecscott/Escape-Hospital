using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour {

	public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;
	public bool chasingPlayer = false;
	public int timeChase;
	private Transform player;

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


}

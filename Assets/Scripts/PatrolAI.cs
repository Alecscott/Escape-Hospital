using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour {

	public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;

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
		if (!agent.pathPending && agent.remainingDistance < 0.5f) {
			GotoNextPoint ();
		}
	}
}

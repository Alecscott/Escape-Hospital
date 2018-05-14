using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//this.transform.position = player.transform.position;
		//this.transform.rotation.Set(player.transform.rotation.x,0, player.transform.rotation.z, this.transform.rotation.w);
		//this.transform.rotation.z = player.transform.rotation.z;
		//this.transform.rotation = player.transform.rotation;
		var lookDir = player.transform.position;
		lookDir.y = 0;
		this.transform.rotation = Quaternion.LookRotation (lookDir);
	}
}

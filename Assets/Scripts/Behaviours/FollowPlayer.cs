using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		Follow();
	}

	void Follow() {
		transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
	}
}

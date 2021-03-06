﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedChecker : MonoBehaviour {

	public float fallingSpeedIncrease = 5f;

	public static bool onGround = true;

	public static List<Vector3> touching;
	private static List<string> touchingNames;

	private Rigidbody r;

	// Use this for initialization
	void Start () {
		r = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ();

		touching = new List<Vector3> ();
		touchingNames = new List<string> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (onGround == false) {
			r.velocity -= new Vector3(0, fallingSpeedIncrease, 0);
		}
	}

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag != "Player") {
//			Vector3 avgPoint = Vector3.zero;
//			int count = 0;
//			foreach (ContactPoint contactPoint in collision.contacts) {
//				avgPoint += contactPoint.point;
//				count++;
//			}
//			if (count != 0) {
//				avgPoint /= count;
//				touching.Add (avgPoint);
//				touchingNames.Add (collision.gameObject.name);
//			}
		}
	}

	void OnTriggerStay(Collider collider){
		if (collider.gameObject.tag != "Player") {
			//Debug.Log (collider.gameObject.name);
			onGround = true;
		}
	}

	void OnTriggerExit(Collider collider){
		if (collider.gameObject.tag != "Player") {
			//Debug.Log (collider.gameObject.name + " exit");
			onGround = false;
//			findName = collision.gameObject.name;
//			touching.RemoveAt (touchingNames.FindIndex(isName));
//			touchingNames.Remove (collision.gameObject.name);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject cameraPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		FollowPlayer ();
	}

	void FollowPlayer(){
		transform.position = cameraPosition.transform.position;
	}
}

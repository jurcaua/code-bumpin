using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject player;
	public GameObject cameraFollow;
	public GameObject cameraPosition;

	public float turningSpeed = 2f; // how fast does the man look around? this fast

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { // FOLLOWS ALL THE TIME 
		FollowPlayer ();
	}

	void FollowPlayer(){ // stalker tbh watch out
		transform.position = cameraPosition.transform.position;
		transform.rotation = Quaternion.LookRotation (cameraFollow.transform.position - transform.position);

		// see if we wants to take a gander uo or down
		if (Input.GetAxis ("Mouse Y") > 0) {
			cameraFollow.transform.position +=  new Vector3(0, turningSpeed, 0);
		} else if (Input.GetAxis ("Mouse Y") < 0) {
			cameraFollow.transform.position -= new Vector3(0, turningSpeed, 0);
		}

		// make sure hes not looking like a mad man (get it)
		cameraFollow.transform.position = new Vector3 
			(
				cameraFollow.transform.position.x, 
				Mathf.Clamp (cameraFollow.transform.position.y, -8 + player.transform.position.y, 30 + player.transform.position.y), 
				cameraFollow.transform.position.z
			);
	}
}

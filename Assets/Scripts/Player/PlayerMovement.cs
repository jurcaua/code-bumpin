using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

	public float speed = 1000f;
	public float jumpSpeed = 5f;
	public float bounceMultiplier;
	public float maxVelY = 15f;

	private Rigidbody r;

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Jump ();
	}

	void FixedUpdate() {
		Move ();
		Rotate ();
	}

	void Move() {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		r.velocity = new Vector3 (horizontal * speed * Time.deltaTime, r.velocity.y, vertical * speed * Time.deltaTime);
	}

	void Rotate() {

	}

	void Jump(){
		// check if on ground
		// if so, get the input from the jump button
		// if the input is pressed, then jump and all the conditions are met ay lmao
		//Debug.Log(GroundedChecker.onGround);
		if (r.velocity.y > maxVelY) {
			r.velocity = new Vector3 (r.velocity.x, maxVelY, r.velocity.z);
		}
		Debug.Log(r.velocity);
		if (GroundedChecker.onGround && Input.GetButtonDown("Jump")){
//			Vector3 jumpDirection = transform.position - AveragePosition ();
//			Debug.Log (jumpDirection);
//			r.velocity += jumpDirection * jumpSpeed;
			r.velocity = new Vector3 (r.velocity.x, jumpSpeed, r.velocity.z);
		}
	}

	Vector3 AveragePosition() {
		Vector3 avgPos = Vector3.zero;
		for (int i = 0; i < GroundedChecker.touching.Count; i++) {
			avgPos += GroundedChecker.touching [i];
		}
		if (GroundedChecker.touching.Count != 0) {
			avgPos /= GroundedChecker.touching.Count;
		}

		return avgPos;
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Launcher") {
			r.velocity += transform.up * AudioPeer.amplitude * bounceMultiplier;
		}
	}
}

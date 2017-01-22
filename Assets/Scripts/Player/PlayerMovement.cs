using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

	public float speed = 1000f;
	public float jumpSpeed = 5f;
	public float turningRate = 10f;
	public float bounceMultiplier;
	public float maxVelY = 15f;

	private Rigidbody r;

	private float horizontal;
	private float vertical;

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody> ();

		// stopping stuff from happening cause they get in the way jesus
		r.freezeRotation = true;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		Jump (); // check for jumps
	}

	void FixedUpdate() {
		Move (); // see if the man wants to move
		Rotate (); // if hes tryna look around? probably
	}

	void Move() {
		horizontal = Input.GetAxisRaw ("Horizontal"); // to da left
		vertical = Input.GetAxisRaw ("Vertical"); // to da forward

		//r.velocity = new Vector3 (horizontal * speed * Time.deltaTime, r.velocity.y, vertical * speed * Time.deltaTime);
		r.velocity = (transform.forward * vertical * speed * Time.deltaTime) + // fun stuff over here tbh
		(transform.right * horizontal * speed * Time.deltaTime) +
		new Vector3 (0, r.velocity.y, 0);
	}

	void Rotate() {
//		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
//			Quaternion targetRotation = Quaternion.Euler 
//				(
//					new Vector3 (0, (vertical - 1) * -90, 0) + new Vector3 (0, horizontal * 90, 0) 
//				);
			//transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, turningRate * Time.deltaTime);
			//transform.rotation = targetRotation;
		//}

		// where ur mouse at
		if (Input.GetAxis ("Mouse X") > 0) {
			transform.Rotate (Vector3.up * turningRate);
		} else if (Input.GetAxis ("Mouse X") < 0) {
			transform.Rotate (-Vector3.up * turningRate);
		}
	}

	void Jump(){
		// check if on ground
		// if so, get the input from the jump button
		// if the input is pressed, then jump and all the conditions are met ay lmao
		//Debug.Log(GroundedChecker.onGround);
		if (r.velocity.y > maxVelY) { // dont go to fast my friend
			r.velocity = new Vector3 (r.velocity.x, maxVelY, r.velocity.z);
		}
		//Debug.Log(r.velocity); // checkin ur no over the speed limit good sir
		if (GroundedChecker.onGround && Input.GetButtonDown("Jump")){ // are u legally allowed to jump? i hope so
//			Vector3 jumpDirection = transform.position - AveragePosition ();
//			Debug.Log (jumpDirection);
//			r.velocity += jumpDirection * jumpSpeed;
			r.velocity = new Vector3 (r.velocity.x, jumpSpeed, r.velocity.z);
		}
	}

//	Vector3 AveragePosition() {
//		Vector3 avgPos = Vector3.zero;
//		for (int i = 0; i < GroundedChecker.touching.Count; i++) {
//			avgPos += GroundedChecker.touching [i];
//		}
//		if (GroundedChecker.touching.Count != 0) {
//			avgPos /= GroundedChecker.touching.Count;
//		}
//
//		return avgPos;
//	}

	void OnCollisionEnter(Collision collision){ // failed idea that never worked cri cri
		if (collision.gameObject.tag == "Launcher") {
			//r.velocity += transform.up * AudioPeer.amplitude * bounceMultiplier;
		}
	}
}

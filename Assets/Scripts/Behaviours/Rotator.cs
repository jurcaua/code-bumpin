using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float rotateSpeed = 50f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Rotate ();
	}

	void Rotate() {
		transform.Rotate // unique spin is cool with those random value multipliers
		(
			rotateSpeed * Time.deltaTime * Random.value, 
			rotateSpeed * Time.deltaTime * Random.value, 
			rotateSpeed * Time.deltaTime * Random.value
		);
	}
}

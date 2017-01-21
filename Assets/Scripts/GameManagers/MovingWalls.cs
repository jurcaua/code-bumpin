using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour {

	public float minSpeed = 0.1f;

	private GameObject[] walls;

	// Use this for initialization
	void Start () {
		walls = new GameObject[transform.childCount];
		for (int i = 0; i < walls.Length; i++) {
			walls [i] = transform.GetChild (i).gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < walls.Length; i++) {
			walls [i].transform.position -=  walls [i].transform.position * minSpeed * AudioPeer.amplitude * Time.deltaTime;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour {

	public float minSpeed = 0.1f;
	public float gameOverDistance = 15f;

	public Transform wall1;
	public Transform wall2;

	private GameObject[] walls;
	//private Vector3[] wallsClamped;
	private PlayerManager playerManager;

	// Use this for initialization
	void Start () {
		playerManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerManager> ();

		walls = new GameObject[transform.childCount];
		for (int i = 0; i < walls.Length; i++) {
			walls [i] = transform.GetChild (i).gameObject;
			//wallsClamped [i] = transform.GetChild (i).gameObject.transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < walls.Length; i++) {
			walls [i].transform.position -=  walls [i].transform.position * minSpeed * AudioPeer.amplitude * Time.deltaTime;
		}
		CheckClose ();
	}

	void CheckClose(){
		if (Vector3.Distance (wall1.position, wall2.position) < gameOverDistance) {
			playerManager.GameOver ();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourglassPickup : MonoBehaviour {

	// slow down music
	// slow down the walls --> minSPeed
	// lasts 3 seconds
	// can only spawn when amp is over some value

	public float slowDownTime = 3f;
	public float pushBackValue = 0.1f;

	private PickUpSpawner spawner;
	private AudioPeer audioPeer;
	private MovingWalls movingWalls;

	private AudioSource source;

	private int numSpawned = 0;

	// Use this for initialization
	void Start () {
		spawner = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PickUpSpawner>();

		audioPeer = GameObject.FindGameObjectWithTag ("AudioPeer").GetComponent<AudioPeer>();

		movingWalls = GameObject.FindGameObjectWithTag ("MovingWalls").GetComponent<MovingWalls> ();

		source = GameObject.FindGameObjectWithTag ("AudioPeer").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider){
		audioPeer.StartCoroutine ("SlowDown", slowDownTime);

		movingWalls.PushBack (pushBackValue);

		Destroy(gameObject);
		if (numSpawned == 0) {
			spawner.SpawnPickup ();
			numSpawned++;
		}
	}
}

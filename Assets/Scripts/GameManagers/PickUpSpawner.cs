﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour {

	public GameObject[] pickups;
	public GameObject[] spawnPoints;

	public float hourglassAmpMin = 0.3f;

	private int pastPickupIndex = 1;

	// Use this for initialization
	void Start () {
		Debug.Log (pickups.Length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnPickup(){
		int randPickupIndex = 0;
		int randSpawnPointIndex = 0;

		bool found = false;
		do {
			randPickupIndex = Random.Range (0, pickups.Length);
			randSpawnPointIndex = Random.Range (0, spawnPoints.Length);

			found = true;

			Debug.Log(AudioPeer.amplitude);
			Debug.Log(pickups [randPickupIndex].name);
			if ((pickups [randPickupIndex].name == "HourGlassPickup" && AudioPeer.amplitude < hourglassAmpMin)) {
				found = false;
				if (pastPickupIndex == 1 && randPickupIndex == 1){
					randPickupIndex = 0;
					found = true;
				}
			}
		} while (!found);

		pastPickupIndex = randPickupIndex;

		Instantiate (pickups [randPickupIndex], spawnPoints [randSpawnPointIndex].transform.position, spawnPoints[randSpawnPointIndex].transform.rotation);
	}
}

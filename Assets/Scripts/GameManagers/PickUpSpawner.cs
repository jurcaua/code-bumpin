using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour {

	public GameObject[] pickups;
	public GameObject[] spawnPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnPickup(){
		int randPickupIndex = Random.Range (0, pickups.Length);
		int randSpawnPointIndex = Random.Range (0, spawnPoints.Length);


	}
}

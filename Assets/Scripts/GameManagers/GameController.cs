using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private PickUpSpawner spawner;

	// Use this for initialization
	void Start () {
		spawner = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PickUpSpawner>();

		spawner.SpawnPickup ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayButton(){
		SceneManager.LoadScene ("main");
	}
}

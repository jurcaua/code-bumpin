using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBackPickup : MonoBehaviour {

    public float PushBackValue = 10f;

	private GameObject[] walls;
	private GameObject movingWalls;

	private PickUpSpawner spawner;

	private int numSpawned = 0;

    // Use this for initialization
    void Start () {
		spawner = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PickUpSpawner>();

		movingWalls = GameObject.FindGameObjectWithTag ("MovingWalls");

		walls = new GameObject[movingWalls.transform.childCount];
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i] = movingWalls.transform.GetChild(i).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].transform.position += walls[i].transform.position * PushBackValue;
        }
        Destroy(gameObject);
		if (numSpawned == 0) {
			spawner.SpawnPickup ();
			numSpawned++;
		}
    }

}

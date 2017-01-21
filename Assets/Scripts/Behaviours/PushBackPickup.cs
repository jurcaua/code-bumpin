using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBackPickup : MonoBehaviour {

    private GameObject[] walls;
    public GameObject MovingWalls;
    public float PushBackValue = 10f;

    // Use this for initialization
    void Start () {
		walls = new GameObject[MovingWalls.transform.childCount];
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i] = MovingWalls.transform.GetChild(i).gameObject;
            Debug.Log(walls[i].name);
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
    }

}

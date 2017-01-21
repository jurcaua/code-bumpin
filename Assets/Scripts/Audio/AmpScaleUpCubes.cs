using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpScaleUpCubes : MonoBehaviour {

	public float cubeSize = 10f;
	public float startScale = 2f;
	public float scaleMultiplier = 10f;

	private GameObject[] cubes;

	// Use this for initialization
	void Start () {
		cubes = new GameObject[transform.childCount];
		for (int i = 0; i < cubes.Length; i++) {
			cubes [i] = transform.GetChild (i).gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < cubes.Length; i++) {
			cubes[i].transform.localScale = Vector3.Lerp
			(
				cubes[i].transform.localScale, 
				new Vector3 (cubeSize, (AudioPeer.amplitudeBuffer * scaleMultiplier) + startScale, cubeSize),
				0.5f
			);
		}
	}
}

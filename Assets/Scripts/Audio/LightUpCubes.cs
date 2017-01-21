using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpCubes : MonoBehaviour {

	public bool useAmp = true;

	public float minEmission = 0f;
	public float maxEmission = 0.5f;

	private Material[] cubes;

	// Use this for initialization
	void Start () {
		cubes = new Material[transform.childCount];
		for (int i = 0; i < cubes.Length; i++) {
			cubes [i] = transform.GetChild (i).gameObject.GetComponentInChildren<MeshRenderer>().material;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (useAmp) {
			for (int i = 0; i < cubes.Length; i++) {
				float lerpedValue = Mathf.Lerp (minEmission, maxEmission, AudioPeer.amplitudeBuffer);
				Color color = new Color (lerpedValue, lerpedValue, lerpedValue);
				cubes [i].SetColor ("_EmissionColor", color);
			}
		} else {
			for (int i = 0; i < cubes.Length; i++) {
				float lerpedValue = Mathf.Lerp (minEmission, maxEmission, AudioPeer.audioBandBuffer [i]);
				Color color = new Color (lerpedValue, lerpedValue, lerpedValue);
				cubes [i].SetColor ("_EmissionColor", color);
			}
		}
	}
}

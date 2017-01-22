using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelection : MonoBehaviour {

	public AudioClip[] songs;
	public Text[] songTitles;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < songs.Length; i++) {
			songTitles [i].text = songs [i].name;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

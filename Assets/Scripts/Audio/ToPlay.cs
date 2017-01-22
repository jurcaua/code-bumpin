using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToPlay : MonoBehaviour {

	public AudioClip mainMenuSong;

	public AudioClip clipToPlay;

	private static ToPlay instance = null;

	void Awake() {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static ToPlay Instance{
		get { return instance; }
	}
}

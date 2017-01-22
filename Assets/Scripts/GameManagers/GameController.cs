using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text timeText;

	private PickUpSpawner spawner;

	private float currentTime = 0f;

	// Use this for initialization
	void Start () {
		spawner = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PickUpSpawner>();

		spawner.SpawnPickup ();
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		UpdateTime ();
	}

	void FixedUpdate(){

	}

	public void PlayButton(){
		SceneManager.LoadScene ("main");
	}

	void UpdateTime(){
		float minutes = Mathf.Round (currentTime / 60);
		float seconds = Mathf.Round (currentTime % 60);

		string minutesStr = minutes.ToString();
		string secondsStr = seconds.ToString();

		if (seconds % 10 == seconds) {
			secondsStr = "0" + secondsStr;
		}
		if (minutes % 10 == minutes) {
			minutesStr = "0" + minutesStr;
		}

		timeText.text = minutesStr + ":" + secondsStr;
	}
}

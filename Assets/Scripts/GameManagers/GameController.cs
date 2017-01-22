using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text timeText;
	public GameObject songSelectionPanel;

	private PickUpSpawner spawner;

	private float currentTime = 0f;

	private AudioPeer audioPeer;

	// Use this for initialization
	void Start () {
		spawner = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PickUpSpawner>();

		if (spawner != null) {
			spawner.SpawnPickup ();
		}

		songSelectionPanel.SetActive(false);

		audioPeer = GameObject.FindGameObjectWithTag ("AudioPeer").GetComponent<AudioPeer> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		UpdateTimeText ();
	}

	void FixedUpdate(){

	}

	public void PlayButton(){
		//SceneManager.LoadScene ("main");
		songSelectionPanel.SetActive(true);
	}

	void UpdateTimeText(){
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

	public void PlaySong(AudioClip clip) {
		for (int i = 0; i < audioPeer.transform.childCount; i++) {
			Destroy (audioPeer.transform.GetChild (i).gameObject);
		}

		audioPeer.source.clip = clip;
		SceneManager.LoadSceneAsync ("main");
	}
}

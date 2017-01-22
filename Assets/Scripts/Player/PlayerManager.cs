using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

	public GameObject gameOverPanel;
	public Text finalScoreText;
	public Text songLengthText;

	private bool gameOver = false;

	private int wallsTouching = 0;

	private GameController gameController;
	private AudioPeer audioPeer;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		audioPeer = GameObject.FindGameObjectWithTag ("AudioPeer").GetComponent<AudioPeer> ();

		gameOverPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		CheckSquished ();
		CheckSides ();

		if (gameOver) {
			//Debug.Log (Input.anyKey);
			if (Input.anyKey) {
				Time.timeScale = 1;
				SceneManager.LoadScene ("startMenu");
			}
		}
	}

	// for wall jumping maybe i the future? that would be lit
	void CheckSides(){

	}

	void CheckSquished(){
		if (wallsTouching >= 3) {
			GameOver ();
		}
	}

	public void GameOver(){
		//Time.timeScale = 0; // for now just like pause this stuff i guess??? make an game over screen later
		Debug.Log("GAME OVER");
		gameOverPanel.SetActive (true);
		finalScoreText.text = "You lasted - " + gameController.minutesStr + ":" + gameController.secondsStr;
		songLengthText.text = "Song Length - " + Mathf.Round(audioPeer.source.clip.length / 60) + ":" + Mathf.Round(audioPeer.source.clip.length % 60);

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		gameOver = true;
		Time.timeScale = 0;
		//SceneManager.LoadScene ("startMenu");
	}

	void OnCollisionEnter (Collision collision){
		if (collision.gameObject.tag == "Wall") {
			wallsTouching += 1;
		}
	}

	void OnCollisionExit (Collision collision){
		if (collision.gameObject.tag == "Wall") {
			wallsTouching -= 1;
		}
	}
}

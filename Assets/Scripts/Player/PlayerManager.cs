using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

	private int wallsTouching = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckSquished ();
		CheckSides ();
	}

	// for wall jumping maybe i the future? that would be lit
	void CheckSides(){

	}

	void CheckSquished(){
		if (wallsTouching >= 3) {
			Time.timeScale = 0; // for now just like pause this stuff i guess??? make an game over screen later
			Debug.Log("GAME OVER");
			SceneManager.LoadScene ("startMenu");

		}
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

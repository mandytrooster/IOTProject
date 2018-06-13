using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public static GameController instance;
	public GameObject gameOverText;
	public static bool gameOver = false;
	public Text scoreText;
	public static int score = 0;


		
	void Update () {
	
		if (gameOver == true) {
			OnGround ();
		}

		if (gameOver == true && Input.GetMouseButtonDown (0)) {
			gameOver = false;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		} 
	}
		
	public void Scored(){
		if (gameOver == true) {
			return;
		}
		score++;
		scoreText.text = "Score: " + score.ToString ();
	}

	public void OnGround(){	
		gameOverText.SetActive (true);
	}
}

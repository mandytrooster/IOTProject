using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public GameObject inputText;
	public GameObject gameOverText;
	public static bool gameOver = false;
	public Text scoreText;
	public static int score;

	void Start(){
		score = 0;
		inputText.SetActive (false);
	}
		
	void Update () {
		if (gameOver == true) {
			OnGround ();
		}

		if (gameOver == true && Input.GetKeyDown("space")) {
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
		inputText.SetActive (true);
		gameOver = true;
		HighScore.newScore = score;
	}
}

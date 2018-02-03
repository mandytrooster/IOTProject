using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public static GameController instance;
	public GameObject gameOverText;
	public bool gameOver = false;
	public Text scoreText;
	private int score = 0;


	void Awake () {
		if (instance == null) {
			instance = this;
		}  else if (instance != this) 
		{
			Destroy (gameObject);
		}
	}
		
	void Update () {
		Debug.Log (gameOver);
		if (gameOver == true && Input.GetMouseButtonDown (0)) {
			
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void Scored(){
		if (gameOver) {
			return;
		}
		score++;
		scoreText.text = "Score: " + score.ToString ();
	}

	public void OnGround(){
	
		gameOverText.SetActive (true);
		gameOver = true;
	}
}

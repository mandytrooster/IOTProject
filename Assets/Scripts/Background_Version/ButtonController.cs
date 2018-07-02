using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {
	private	List<PlayerScore> highscore;

	void Start(){
		highscore = new List<PlayerScore>();
	}

	public void clearLeaderBoard(){
		HighScore._instance.ClearLeaderBoard();
	}

	public void getHighScore ()
	{
		SceneManager.LoadScene("HighScoreScene");
	}

	public void startGame(){
		SceneManager.LoadScene("FlappyBird");
	}

	public void mainMenu(){
		SceneManager.LoadScene("StartMenu");
	}
}

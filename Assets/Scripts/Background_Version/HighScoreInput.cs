using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class HighScoreInput : MonoBehaviour {
	public string highscoreName;
	public InputField mainInputField;
	List<PlayerScore> highscore;

	private string analyticsScore;

	void Start(){
		mainInputField.ActivateInputField();
		mainInputField.onEndEdit.AddListener(delegate {LockInput(mainInputField); });
		highscore = new List<PlayerScore>();
//		dictionary.Add ("highscore",0);
	}

	void LockInput(InputField input)
	{
		if (input.text.Length > 0)
		{
			Debug.Log("Text has been entered " + input.text);
			highscoreName = input.text;
			HighScore._instance.SubmitScore (highscoreName, GameController.score);
		}
		else if (input.text.Length == 0)
			{
				Debug.Log("Main Input Empty");
			}
	}

}

//	void OnGUI(){
//
//		if(GUILayout.Button("Clear Leaderboard"))
//		{
//			HighScore._instance.ClearLeaderBoard();            
//		}
//
//		if(GUILayout.Button("Get LeaderBoard"))
//		{
//			highscore = HighScore._instance.GetHighScore();  
//		}
//
//		GUILayout.Space (60);
//
//		GUILayout.BeginHorizontal ();
//		GUILayout.Label ("Name", GUILayout.Width (Screen.width / 2));
//		GUILayout.Label ("Scores", GUILayout.Width (Screen.width / 2));
//		GUILayout.EndHorizontal ();
//
//		GUILayout.Space (25);
//
//		foreach (PlayerScore _score in highscore) {
//			GUILayout.BeginHorizontal ();
//			GUILayout.Label (_scoreGUI.name, GUILayout.Width (Screen.width / 2));
//			GUILayout.Label ("" + _score.score, GUILayout.Width (Screen.width / 2));
//			GUILayout.EndHorizontal ();
//		}
//	}
//}

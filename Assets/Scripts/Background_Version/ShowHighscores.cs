using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHighscores : MonoBehaviour {
	List<PlayerScore> highscore;
	private int fontSize;

	void Start () {
		highscore = new List<PlayerScore>();
	}

	void OnGUI(){

			highscore = HighScore._instance.GetHighScore();  
			GUI.contentColor = Color.grey;

		    GUILayout.Space (100);
			GUILayout.BeginHorizontal ();
			GUILayout.Space (100);
	    	GUILayout.Label ("Name", GUILayout.Width (Screen.width / 2));
			GUILayout.Label ("Scores", GUILayout.Width (Screen.width / 2));
			GUILayout.EndHorizontal ();

		foreach (PlayerScore _score in highscore) {
			GUILayout.BeginHorizontal ();
			GUILayout.Space (100);
			GUILayout.Label (_score.name, GUILayout.Width (Screen.width / 2));
			GUILayout.Label ("" + _score.score, GUILayout.Width (Screen.width / 2));
			GUILayout.EndHorizontal ();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using UnityEngine.Networking;

public class HighScoreInput : MonoBehaviour {
	public string highscoreName;
	public InputField mainInputField;
	List<PlayerScore> highscore;

	private string analyticsScore;

	void Start(){
		mainInputField.ActivateInputField();
		mainInputField.onEndEdit.AddListener(delegate {LockInput(mainInputField); });
		highscore = new List<PlayerScore>();
	}

	void LockInput(InputField input)
	{
		if (input.text.Length > 0)
		{
			Debug.Log("Text has been entered " + input.text);
			highscoreName = input.text;
			HighScore._instance.SubmitScore (highscoreName, GameController.score);
			StartCoroutine(SendScore(highscoreName, GameController.score)); 
		}
		else if (input.text.Length == 0)
			{
				Debug.Log("Main Input Empty");
			}
	}


	IEnumerator SendScore(string name, int score) {
		PlayerScore jsonObject = new PlayerScore();
		jsonObject.name = name;
		jsonObject.score = score;
		string json = JsonUtility.ToJson(jsonObject);

		// creates a post request to the website
		var uwr = new UnityWebRequest("https://highscoreapplications.herokuapp.com/newscore", "POST");
		byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
		uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
		uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
		// sets header as json content
		uwr.SetRequestHeader("Content-Type", "application/json");

		yield return uwr.SendWebRequest();

		if (uwr.isNetworkError) {
			Debug.Log("Error while sending" + uwr.error);
		}
		else {
			Debug.Log("Received: " + uwr.downloadHandler.text);
		}
	}

}
	
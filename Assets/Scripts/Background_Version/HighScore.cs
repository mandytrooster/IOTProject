using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{

		public static int newScore;
		private int LeaderboardLength = 10;
		private static HighScore m_instance;

		void Start () {
	
		}

	public static HighScore _instance {
		get {
			if (m_instance == null) {
				m_instance = new GameObject ("HighScoreManager").AddComponent<HighScore> ();                
			}
			return m_instance;
		}
	}

	void Awake ()
	{
		if (m_instance == null) {
			m_instance = this;            
		} else if (m_instance != this)        
			Destroy (gameObject);    

		DontDestroyOnLoad (gameObject);
	}

		public void SubmitScore (string name, int score)
	{
		List<PlayerScore> playerScores = new List<PlayerScore> ();
			
		int i = 1;
		//haalt de highscores op en zet het in de highscores object
		//haalt de highscores op, en zet ze op een tijdelijke highscore lijst
		while (i <= LeaderboardLength && PlayerPrefs.HasKey ("HighScore" + i + "score")) {
			PlayerScore temp = new PlayerScore ();
			temp.score = PlayerPrefs.GetInt ("HighScore" + i + "score");
			temp.name = PlayerPrefs.GetString ("HighScore" + i + "name");
			playerScores.Add (temp);
			i++;
		}

		//Als de highscore lijst leeg is, maak eerst een nieuwe score object aan
		//geef aan die score object de naam en de score mee 
		//deze hoeft niet vergeleken te worden omdat dit de eerste score is in de lijst
		if (playerScores.Count == 0) {                        
			PlayerScore _temp = new PlayerScore ();
			_temp.name = name;
			_temp.score = score;
			playerScores.Add (_temp);
		} else {
			//de score vergelijken met scores die al in de highscorelijst staan
			for (i = 1; i <= playerScores.Count && i <= LeaderboardLength; i++) {
				if (score > playerScores [i - 1].score) {
					PlayerScore _temp = new PlayerScore ();
					_temp.name = name;
					_temp.score = score;
					playerScores.Insert (i - 1, _temp);
					break;    
				}
					
			//voor wanneer de leaderboard nog niet vol is 
			if (i == playerScores.Count && i < LeaderboardLength) {
				PlayerScore _temp = new PlayerScore ();
				_temp.name = name;
				_temp.score = score;
				playerScores.Add (_temp);
				break;
			 }
			}
		   }
			i = 1;

			while (i <= LeaderboardLength && i <= playerScores.Count) {
				PlayerPrefs.SetString ("HighScore" + i + "name", playerScores [i - 1].name);
				PlayerPrefs.SetInt ("HighScore" + i + "score", playerScores [i - 1].score);
				i++;
		}
	}

	public List<PlayerScore>  GetHighScore ()
	{
		List<PlayerScore> HighScores = new List<PlayerScore> ();

		int i = 1;
		while (i<=LeaderboardLength && PlayerPrefs.HasKey("HighScore"+i+"score")) {
			PlayerScore temp = new PlayerScore ();
			temp.score = PlayerPrefs.GetInt ("HighScore" + i + "score");
			temp.name = PlayerPrefs.GetString ("HighScore" + i + "name");
			HighScores.Add (temp);
			i++;
		}
		return HighScores;
	}
	public void ClearLeaderBoard ()
	{
		List<PlayerScore> HighScores = GetHighScore();

		for(int i=1;i<=HighScores.Count;i++)
		{
			PlayerPrefs.DeleteKey("HighScore" + i + "name");
			PlayerPrefs.DeleteKey("HighScore" + i + "score");
		}
	}

	void OnApplicationQuit()
	{
		PlayerPrefs.Save();
	}
}	
	
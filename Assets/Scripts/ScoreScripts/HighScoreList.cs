using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighScoreList {
	public List<Score> ScoreList;
	private const int MAX_LIST_SIZE = 10;
	private int index;

	private static HighScoreList instance;
	
	private HighScoreList() { }
	
	public static HighScoreList Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new HighScoreList();
				instance.ScoreList = new List<Score> (MAX_LIST_SIZE);
				instance.index = 0;
			}
			return instance;
		}
	}
	
	public void InitializeWithDummy() {
		ScoreList.Add (new Score ("Harry", 9000));
		ScoreList.Add (new Score ("Richard", 8600));
		ScoreList.Add (new Score ("John", 8100));
		ScoreList.Add (new Score ("Victor", 7900));
		ScoreList.Add (new Score ("Richard", 6500));
		ScoreList.Add (new Score ("Sean", 1));
	}
	
	public bool CheckIfHighScore(Score yourScore) {
		if (ScoreList.Count < MAX_LIST_SIZE) {
			return true;
		}
		return yourScore.Value >= ScoreList [index].Value && yourScore.Value > 0;
	}

	private void Sort() {
		ScoreList.Sort ();
		ScoreList.Reverse ();
	}
	
	public bool AddNewScore(Score newScore) {
		if (ScoreList.Count >= MAX_LIST_SIZE) {
			return false;
		}
		else {
			ScoreList.Add(newScore);
			Sort ();
			return true;
		}
	}
}
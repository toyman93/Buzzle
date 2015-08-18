using UnityEngine;
using System.Collections;

public class HighScorePopulator : MonoBehaviour {
	
	private GameObject NameColumnTitle;
	private GameObject ScoreColumnTitle;

	private GameObject NameColumnEntry;
	private GameObject ScoreColumnEntry;

	private Vector2 BaseNameCoords = new Vector2((float)-3, (float)4);
	private Vector2 BaseScoreCoords = new Vector2((float)3, (float)4);

	public void InitializeColumns() {
		NameColumnTitle = (GameObject)Instantiate (Resources.Load ("Prefabs/" + "generic_gui_text"));
		NameColumnTitle = new GameObject ();
		NameColumnTitle.AddComponent (typeof(GUIText));
		NameColumnTitle.GetComponent<GUIText>().text = "Name";
		NameColumnTitle.GetComponent<GUIText>().color = Color.blue;
		NameColumnTitle.GetComponent<GUIText>().fontSize = 20;
		NameColumnTitle.transform.position = 
			Camera.main.WorldToViewportPoint(new Vector2(
				BaseNameCoords.x, BaseNameCoords.y));

		ScoreColumnTitle = (GameObject)Instantiate (Resources.Load ("Prefabs/" + "generic_gui_text"));		
		ScoreColumnTitle.GetComponent<GUIText>().text = "Score";
		ScoreColumnTitle.GetComponent<GUIText>().color = Color.blue;
		ScoreColumnTitle.GetComponent<GUIText>().fontSize = 20;
		ScoreColumnTitle.transform.position = 
			Camera.main.WorldToViewportPoint(new Vector2(
				BaseScoreCoords.x, BaseScoreCoords.y));

		NameColumnEntry = (GameObject)Instantiate (Resources.Load ("Prefabs/" + "generic_gui_text"));
		NameColumnEntry.GetComponent<GUIText>().text = string.Empty;
		NameColumnEntry.GetComponent<GUIText>().color = Color.black;
		NameColumnEntry.GetComponent<GUIText>().fontSize = 10;
		NameColumnEntry.transform.position = 
			Camera.main.WorldToViewportPoint(new Vector2(
				BaseNameCoords.x, BaseNameCoords.y-(float)0.5));

		ScoreColumnEntry = (GameObject)Instantiate (Resources.Load ("Prefabs/" + "generic_gui_text"));
		ScoreColumnEntry.GetComponent<GUIText>().text = string.Empty;
		ScoreColumnEntry.GetComponent<GUIText>().color = Color.black;
		ScoreColumnEntry.GetComponent<GUIText>().fontSize = 10;
		ScoreColumnEntry.transform.position = 
			Camera.main.WorldToViewportPoint(new Vector2(
				BaseScoreCoords.x, BaseScoreCoords.y-(float)0.5));

	}

	public void PopulateScores() {
		foreach(Score score in HighScoreList.Instance.ScoreList) {
			Debug.Log(score.Name + " " + score.Value);
			AddEntry(score);
		}
	}

	private void AddEntry(Score score) {
		NameColumnEntry.GetComponent<GUIText>().text = NameColumnEntry.GetComponent<GUIText>().text + "\n" + score.Name;
		ScoreColumnEntry.GetComponent<GUIText>().text = ScoreColumnEntry.GetComponent<GUIText>().text + "\n" + score.Value.ToString();
	}

	// Use this for initialization
	void Start () {
		HighScoreList.Instance.InitializeWithDummy ();

		HighScoreList.Instance.AddNewScore(new Score("TestEntry", 8888));
		HighScoreList.Instance.AddNewScore(new Score("TestEntry2", 234));
		HighScoreList.Instance.AddNewScore(new Score("TestEntry3", 4000));
		HighScoreList.Instance.AddNewScore(new Score("TestEntry4", 5000));
		HighScoreList.Instance.AddNewScore(new Score("TestEntry5", 6000));


		InitializeColumns ();
		PopulateScores ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
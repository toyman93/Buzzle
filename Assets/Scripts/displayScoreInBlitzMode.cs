using UnityEngine;
using System.Collections;

public class displayScoreInBlitzMode : MonoBehaviour {

	GameObject currentScoreText;
	int currentScore;
	GUITextSpawner spawner;
	public string levelName;
	Generator generatorScript;

	// Use this for initialization
	void Start () {

		spawner = new GUITextSpawner ();
		generatorScript = GameObject.Find("Generator").GetComponent<Generator>();
	
	}
	
	// Update is called once per frame
	void Update () {

		currentScore = generatorScript.score;
		currentScoreText = spawner.SpawnNew ("Score: " +currentScore.ToString(), new Vector2(-2,5), 30, null, FontStyle.Bold, Color.black);
	
	}
}

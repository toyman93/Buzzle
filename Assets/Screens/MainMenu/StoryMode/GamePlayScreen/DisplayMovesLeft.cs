using UnityEngine;
using System.Collections;

public class DisplayMovesLeft : MonoBehaviour {

	GameObject movesLeftText;
	int moves;
	GUITextSpawner spawner;
	public string levelName;
	Game gameScript;


	// Use this for initialization
	void Start () {
	
		spawner = new GUITextSpawner ();
		gameScript = GameObject.Find(levelName).GetComponent<Game>();

	}
	
	// Update is called once per frame
	void Update () {
		if (!(movesLeftText == null)) {
				spawner.ClearText (movesLeftText);
		}
		moves = gameScript.moves;
		movesLeftText = spawner.SpawnNew ("Moves Left: " +moves.ToString(), new Vector2(-1,-5), 35, null, FontStyle.Bold, Color.black);

	
	}
}

using UnityEngine;
using System.Collections;

public class TimeRemaining : MonoBehaviour {
	public float startTime = -1.0f;
	public bool started = false; 
	float currentTime;
	public float givenTime;
	public float timeRemaining;
	GameObject timeRemainingText;
	GUITextSpawner spawner;


	// Use this for initialization
	public void StartTimer(){
		startTime = Time.time;
		spawner = new GUITextSpawner ();
	}
	void Start () {

	
	}

	// Update is called once per frame
	void Update () {
		if (started){
		if (!(timeRemainingText == null)) {
						spawner.ClearText (timeRemainingText);
		}
		timeRemaining = startTime - Time.time + givenTime;

		timeRemainingText = spawner.SpawnNew ("Time remaining: " +timeRemaining.ToString("F2"), new Vector2(-2,-5), 30, null, FontStyle.Bold, Color.black);
	
	}
	}
	}

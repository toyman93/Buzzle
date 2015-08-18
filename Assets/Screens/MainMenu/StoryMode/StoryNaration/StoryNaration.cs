using UnityEngine;
using System.Collections;

public class StoryNaration : MonoBehaviour {

	public int currentStory;
	public int nextStory;
	public string levelToLoad;
	public static bool snClicked = false;
	float timeCounter;


	// Use this for initialization
	void Start () {

		timeCounter = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.time-timeCounter > 3) {


			ProgressThroughImages();

		}

	}


	void ProgressThroughImages(){

		snClicked = true;
		Application.LoadLevel(levelToLoad);

	}


	void OnMouseUp(){
		snClicked = true;
		Application.LoadLevel("Period");

	}
}

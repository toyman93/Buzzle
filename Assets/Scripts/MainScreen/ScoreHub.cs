using UnityEngine;
using System.Collections;

/*
 * This script is attached to the "StoryMode" button
 * It detects if the mouse is clicked on the object
 * and adjusts variables if it is clicked.
 **/

public class ScoreHub : MonoBehaviour {
	
	private GameObject scoreHub = null; // Create a game object
	public static float scoreHubClickedTime; // The time when StoryMode is clicked
	public static bool scoreHubClicked = false; // Boolean to determine if Storymode was clicked.
	
	void Start(){
		scoreHub = GameObject.Find ("ScoreHubIcon"); // Set link between null game object to the StoryMode asset.
		scoreHubClicked = false; // Initially, it is not clicked.
	}
	
	// Detects when object is clicked.
	void OnMouseUp(){
		scoreHubClickedTime = Time.time; // Store time when object is clicked.
		scoreHubClicked = true; // Set boolean to true when object is clicked.
	}
	
	void FixedUpdate(){
		if (leftArrow.currentScreenPos != 0) {
			scoreHub.GetComponent<Collider>().enabled = false;     // Disable collider if the screen is not focused on StoryMode
		} else {
			scoreHub.GetComponent<Collider>().enabled = true;      // If it is, enable collider.
		}
		
		// Runs when the object is clicked.
		if (scoreHubClicked == true) {
			// After 1 seconds, load the Period scene
			if (Time.time - scoreHubClickedTime > 1) {
				Application.LoadLevel ("ScoreHub");
				// Set clicked to false after transition is complete.
				scoreHubClicked = false;
			}
		}
	}
}

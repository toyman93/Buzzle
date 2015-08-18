using UnityEngine;
using System.Collections;

/*
 * This script is attached to the "StoryMode" button
 * It detects if the mouse is clicked on the object
 * and adjusts variables if it is clicked.
 **/

public class StoryMode : MonoBehaviour {

	private GameObject sMode = null; // Create a game object
	public static float smClickedTime; // The time when StoryMode is clicked
	public static bool smClicked = false; // Boolean to determine if Storymode was clicked.

	void Start(){
		sMode = GameObject.Find ("StoryMode"); // Set link between null game object to the StoryMode asset.
		smClicked = false; // Initially, it is not clicked.
	}

	// Detects when object is clicked.
	void OnMouseUp(){
		smClickedTime = Time.time; // Store time when object is clicked.
		smClicked = true; // Set boolean to true when object is clicked.
	}

	void FixedUpdate(){
		if (leftArrow.currentScreenPos != 0) {
			sMode.GetComponent<Collider>().enabled = false;     // Disable collider if the screen is not focused on StoryMode
		} else {
			sMode.GetComponent<Collider>().enabled = true;      // If it is, enable collider.
		}

		// Runs when the object is clicked.
		if (smClicked == true) {
			// After 1 seconds, load the Period scene
			if (Time.time - smClickedTime > 1) {
				Application.LoadLevel ("StoryNaration");
				// Set clicked to false after transition is complete.
				smClicked = false;
			}
		}
	}
}

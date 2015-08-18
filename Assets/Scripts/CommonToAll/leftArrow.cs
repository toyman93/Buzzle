using UnityEngine;
using System.Collections;
/*
 * This script is very important. It is linked to the left arrow object.
 **/
public class leftArrow : MonoBehaviour {

	// Declare Variables
	public static bool moveLeft = false;  // Boolean variable to control time of transition to left
	public static float savedTimeLeft;  // Instance when left arrow is clicked
	public static GameObject lArrow = null;  // Game object to be attched to the left arrow
	public static float minScreenPos;  // For each scene, this will vary. This is the min position of the screen(leftmost)
	public static float maxScreenPos;  // This is the max position of the screen (rightmost)
	public static float currentScreenPos; // Current position of the screen

	// Identify variables, objects on Start Up
	void Start(){
		lArrow = GameObject.Find ("leftArrow");  // Attach object to left arrow asset

		// If the current scene is on Main screen
		if (Application.loadedLevelName == "Main") {
				minScreenPos = 0;
				maxScreenPos = 2;
				currentScreenPos = 0;
		}

		// If the current scene is on Period selection screen
		else if (Application.loadedLevelName == "Period") {
				minScreenPos = 0;
				maxScreenPos = 4;
				currentScreenPos = 0;
		} else if (Application.loadedLevelName == "Renaissance") {
				minScreenPos = 0;
				maxScreenPos = 2;
				currentScreenPos = 0;
		}
	}
	
	void FixedUpdate(){

		// While moving left, disable the collider on left arrow
		if (moveLeft == true) {
			// By setting the collider on after 1 second.
			if (Time.time - savedTimeLeft >= 1){
				// After 1 second, no longer moving to left
				moveLeft = false;
				// After 1 second, set the collider on again
				lArrow.GetComponent<Collider>().enabled = true;
			}
		}

		// If the current screen is on the left most side, disable the left arrow
		if (currentScreenPos == minScreenPos) {
			lArrow.GetComponent<Renderer>().enabled = false;
		} else {
			// Otherwise, back on again
			lArrow.GetComponent<Renderer>().enabled = true;		
		}

		// If StoryMode is clicked, set the left arrow invisible, (So it doesnt show up on transition)
		if (StoryMode.smClicked == true) {
			lArrow.GetComponent<Renderer>().enabled = false;
		}
	}
	
	private void OnMouseDown(){

		// Make left arrow big when mouse is clicked
		transform.localScale += new Vector3(0.1f, 0.1f, 0);

		// Save insatnce when the left arrow is clicked
		savedTimeLeft = Time.time;

		//rightArrow.moveRight = false;

		// Only allow click when the screen IS NOT on the left most side.
		if (currentScreenPos > minScreenPos) {
			moveLeft = true;
			lArrow.GetComponent<Collider>().enabled = false; // Disable click after clicked
			currentScreenPos -= 1; // Decrease the current position of the screen
			//Debug.Log (currentScreenPos);
		}
	}

	// Make the arrow smaller again when mouse click is released.
	private void OnMouseUp(){
		transform.localScale += new Vector3(-0.1f, -0.1f, 0);
	}
}

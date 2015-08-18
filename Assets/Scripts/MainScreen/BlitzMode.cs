using UnityEngine;
using System.Collections;
/*
 * This script is attached to the BlitzMode asset.
 **/
public class BlitzMode : MonoBehaviour {

	private GameObject bMode = null;
	public static bool bmClicked = false;
	public static float bmClickedTime;

	void Start(){
		bMode = GameObject.Find ("BlitzMode");
		bmClicked = false;
	}
	void OnMouseDown(){
		bmClickedTime = Time.time;
		bmClicked = true;
	}
	
	void Update(){
		if (leftArrow.currentScreenPos != 1) {
			bMode.GetComponent<Collider>().enabled = false;
		} else {
			bMode.GetComponent<Collider>().enabled = true;
		}

		// Runs when the object is clicked.
		if (bmClicked == true) {
			// After 1 seconds, load the Blitz scene
			if (Time.time - bmClickedTime > 1) {
				Application.LoadLevel ("blitz");
				// Set clicked to false after transition is complete.
				bmClicked = false;
			}
		}

	}
}

using UnityEngine;
using System.Collections;


/* 
 * This script is attached to camera of the main screen.
 * It controls the transition of the camera 
 * including movement along x-axis and zoom.
 **/


public class MenuScroll: MonoBehaviour {
	

	 // Translate the 3 pictures while arrows are true
	void FixedUpdate () {

		// If right arrow clicked is true, move camera in the right direction
		if (rightArrow.moveRight == true) 
		{
			// The value after Vector3.right controls the speed
			transform.Translate(Vector3.right * 0.24f, Space.World);
		}

		// Read above
		else if (leftArrow.moveLeft == true)
		{
			transform.Translate(Vector3.left * 0.24f, Space.World);
		}

		// If story mode is clicked, zoom.
		if (StoryMode.smClicked == true) {
			if (Time.time - StoryMode.smClickedTime < 1) { // Value here controls the duration of zoom
				transform.Translate(Vector3.forward * 0.15f, Space.World); // Value here controls the speed of zoon.
			}
		}
		if (ItemShop.itClicked == true) {
			if (Time.time - ItemShop.itClickedTime < 1) { // Value here controls the duration of zoom
				transform.Translate(Vector3.forward * 0.15f, Space.World); // Value here controls the speed of zoon.
			}
		}

		if (BlitzMode.bmClicked == true) {
			if (Time.time - BlitzMode.bmClickedTime < 1) { // Value here controls the duration of zoom
				transform.Translate(Vector3.forward * 0.15f, Space.World); // Value here controls the speed of zoon.
			}	
		}

	}
}

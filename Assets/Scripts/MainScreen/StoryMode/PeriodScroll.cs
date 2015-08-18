using UnityEngine;
using System.Collections;
/*
 * This script is attached to the camera of the Period Selection Screen.
 * 
 **/
public class PeriodScroll : MonoBehaviour {

	// Same mechanics as MenuScroll. See MenuScroll script
	void FixedUpdate () {

		//Debug.Log (MainScreen.ScreenPos);
		if (rightArrow.moveRight == true) 
		{
			transform.Translate(Vector3.right * 0.18f, Space.World);
		}
		else if (leftArrow.moveLeft == true)
		{
			transform.Translate(Vector3.left * 0.18f, Space.World);
		}
		// If Renaissance is clicked, zoom.
		if (ToRenaissance.rnClicked == true) {
			if (Time.time - ToRenaissance.rnClickedTime < 1) {
				transform.Translate(Vector3.forward * 0.15f, Space.World);
			}
		}
		if (ToModernism.mdClicked == true) {
			if (Time.time - ToModernism.mdClickedTime < 1) {
				transform.Translate(Vector3.forward * 0.15f, Space.World);
			}
		}
	}
}
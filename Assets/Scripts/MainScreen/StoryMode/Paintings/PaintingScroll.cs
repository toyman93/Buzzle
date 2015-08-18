using UnityEngine;
using System.Collections;

/*
 * This script is attached to the camera of the Painting selection screen.
 * See other camera scripts
 * No zoom is implemented here
 **/
public class PaintingScroll : MonoBehaviour {
	
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

	}
}

using UnityEngine;
using System.Collections;
/*
 * This script is attached to the right arrow.
 **/
public class rightArrow : MonoBehaviour {

	// Declare Variables
	public static bool moveRight = false;
	public static float savedTimeRight;  // See leftArrow. Pretty much the same
	private GameObject rArrow = null;

	// Identify object on startup
	void Start(){
		rArrow = GameObject.Find ("rightArrow");
	}

	// Read leftArrow
	void FixedUpdate(){
		if (moveRight == true) {
			if (Time.time - savedTimeRight >= 1){
				moveRight = false;
				rArrow.GetComponent<Collider>().enabled = true;
			}
		}
		// Variables to do with the screen positions are gathered from leftArrow script
		if (leftArrow.currentScreenPos == leftArrow.maxScreenPos) {
			rArrow.GetComponent<Renderer>().enabled = false;		
		}else {
			rArrow.GetComponent<Renderer>().enabled = true;		
		}
		if (StoryMode.smClicked == true) {
			rArrow.GetComponent<Renderer>().enabled = false;
		}
	}

	private void OnMouseDown(){
		transform.localScale += new Vector3(0.1f, 0.1f, 0);
		savedTimeRight = Time.time;
		leftArrow.moveLeft = false;
		if (leftArrow.currentScreenPos < leftArrow.maxScreenPos) {
			moveRight = true;
			rArrow.GetComponent<Collider>().enabled = false;
			leftArrow.currentScreenPos += 1;
			//Debug.Log (leftArrow.currentScreenPos);
		}
	}
	private void OnMouseUp(){
		transform.localScale += new Vector3(-0.1f, -0.1f, 0);
	}
}

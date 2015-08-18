using UnityEngine;
using System.Collections;

/*
 * This script is attached to the Renaissance (the last supper asset)
 * This script is based on the StoryMode script
 **/
public class ToRenaissance: MonoBehaviour {

	public static float rnClickedTime;
	public static bool rnClicked = false;
	private GameObject rn = null;
	public float fadeSpeed = 2f;   // Speed that the screen fades to and from black.
	


	void Start(){
		rn = GameObject.Find ("Renaissance");

	}
	void OnMouseUp(){

		rnClickedTime = Time.time;
		rnClicked = true;


	}



	void FixedUpdate(){

		if (leftArrow.currentScreenPos != 0) {
			rn.GetComponent<Collider>().enabled = false;
		} else {
			rn.GetComponent<Collider>().enabled = true;
		}

		if (rnClicked == true) {
			if (Time.time - rnClickedTime > 1) {
				Application.LoadLevel ("Renaissance");
				rnClicked = false;
			}
		}
	}

}

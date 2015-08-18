using UnityEngine;
using System.Collections;

public class ItemShop : MonoBehaviour {

	private GameObject iMode = null;
	public static bool itClicked = false;
	public static float itClickedTime;
	void Start(){
		iMode = GameObject.Find ("ItemShop");
		itClicked = false;
	}
	void OnMouseDown(){
		itClicked = true;
		itClickedTime = Time.time;
	}

	void FixedUpdate(){
		if (leftArrow.currentScreenPos != 2) {
			iMode.GetComponent<Collider>().enabled = false;
		} else {
			iMode.GetComponent<Collider>().enabled = true;
		}

		// Runs when the object is clicked.
		if (itClicked == true) {
			// After 1 seconds, load the Period scene
			if (Time.time - itClickedTime > 1) {
				Application.LoadLevel ("ShopScreen");
				// Set clicked to false after transition is complete.
				itClicked = false;
			}
		}
	}
}

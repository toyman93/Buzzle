using UnityEngine;
using System.Collections;

public class ToModernism : MonoBehaviour {

	public static float mdClickedTime;
	public static bool mdClicked = false;
	private GameObject md = null;
		
	void Start(){
		md = GameObject.Find ("Modernism");
	}
	void OnMouseUp(){
		mdClickedTime = Time.time;
		mdClicked = true;


	}
	
	void FixedUpdate(){
		
		if (leftArrow.currentScreenPos != 4) {
			md.GetComponent<Collider>().enabled = false;
		} else {
			md.GetComponent<Collider>().enabled = true;
		}
		
		if (mdClicked == true) {
			if (Time.time - mdClickedTime > 1) {
				Application.LoadLevel ("Modernism");
				mdClicked = false;
			}
		}
	}

}

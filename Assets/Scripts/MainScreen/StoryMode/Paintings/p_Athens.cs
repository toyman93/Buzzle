﻿using UnityEngine;
using System.Collections;

public class p_Athens : MonoBehaviour {

	private GameObject athens = null;
	private GameObject frame = null;
	private float savedTime;
	private bool rotate = false;
	public static bool atClicked = false;
	
	// Use this for initialization
	void Start () {
		athens = GameObject.Find ("TheSchoolOfAthens");
		frame = GameObject.Find ("TheSchoolOfAthensFrame");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (leftArrow.currentScreenPos != 2) {
			athens.GetComponent<Collider>().enabled = false;     // Disable collider if the screen is not focused on Mona Lisa
		} else {
			athens.GetComponent<Collider>().enabled = true;      // If it is, enable collider.
		}
		if (rotate == true) {
			if(Time.time - savedTime < 1){
				athens.transform.RotateAround(transform.position, transform.up, Time.deltaTime * 200f);  // rightmost variable is the speed of rotation
				frame.transform.RotateAround(transform.position, transform.up, Time.deltaTime * 200f);
				athens.transform.localScale += new Vector3(0.1f, 0.1f, 0); // Zoom
				frame.transform.localScale += new Vector3(0.3f, 0.3f, 0);
				
			}
			
			// Transition after 1 second
			if(Time.time - savedTime > 1){
				rotate = false;
				athens.GetComponent<Renderer>().enabled = false;
				frame.GetComponent<Renderer>().enabled = false;
				atClicked = false;
				Application.LoadLevel ("Renaissance");
			}
		}
	}
	
	void OnMouseUp(){
		atClicked = true;
		savedTime = Time.time;
		rotate = true;
	}
}

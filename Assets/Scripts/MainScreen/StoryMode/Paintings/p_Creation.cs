using UnityEngine;
using System.Collections;

public class p_Creation : MonoBehaviour {
	private GameObject c = null;
	private GameObject frame = null;
	private float savedTime;
	private bool rotate = false;
	public static bool caClicked = false;
	
	// Use this for initialization
	void Start () {
		c = GameObject.Find ("CreationOfAdam");
		frame = GameObject.Find ("CreationOfAdamFrame");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (leftArrow.currentScreenPos != 1) {
			c.GetComponent<Collider>().enabled = false;     // Disable collider if the screen is not focused on Mona Lisa
		} else {
			c.GetComponent<Collider>().enabled = true;      // If it is, enable collider.
		}
		if (rotate == true) {
			if(Time.time - savedTime < 1){
				c.transform.RotateAround(transform.position, transform.up, Time.deltaTime * 200f);  // rightmost variable is the speed of rotation
				frame.transform.RotateAround(transform.position, transform.up, Time.deltaTime * 200f);
				c.transform.localScale += new Vector3(0.1f, 0.1f, 0); // Zoom
				frame.transform.localScale += new Vector3(0.3f, 0.3f, 0);
				
			}
			
			// Transition after 1 second
			if(Time.time - savedTime > 1){
				rotate = false;
				c.GetComponent<Renderer>().enabled = false;
				frame.GetComponent<Renderer>().enabled = false;
				caClicked = false;
				Application.LoadLevel ("Renaissance");
			}
		}
	}
	
	void OnMouseUp(){
		caClicked = true;
		savedTime = Time.time;
		rotate = true;
	}
}

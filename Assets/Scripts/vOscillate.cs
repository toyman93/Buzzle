using UnityEngine;
using System.Collections;

public class vOscillate : MonoBehaviour {

	float amplitude = 0.001f;       // amount of meters going up and down
	float speed = 3f;      // up and down speed
	//protected float angle  = 0;       // angle to determin the height by using the sinus
	//protected float toDegrees = Mathf.PI/180;    // radians to degrees
	Vector3 temp;

	void Update()
	{
//		angle += speed * Time.deltaTime;
//		if (angle > 360)
//		{
//			angle -= 360;
//		}

		// Save the y position prior to start floating (maybe in the Start function):
		
		float y0 = transform.position.y;
		
		// Put the floating movement in the Update function:

		float temp = amplitude*Mathf.Sin(speed*Time.time); 

		Vector3 position = new Vector3(transform.position.x,(y0+temp),transform.position.z);
		transform.position = position; 

	}
}
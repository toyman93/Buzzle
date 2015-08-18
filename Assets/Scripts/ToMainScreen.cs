using UnityEngine;
using System.Collections;

public class ToMainScreen : MonoBehaviour {

	void OnMouseDown(){
		Application.LoadLevel ("Main");
	}
}

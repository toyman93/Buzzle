using UnityEngine;
using System.Collections;

public class HelpBtn : MonoBehaviour {
	private GameObject helpBtn = null;
	
	void Start(){
		helpBtn = GameObject.Find ("help_icon");
	}
	// Update is called once per frame
	void Update () {
		if (StoryMode.smClicked == true) {
			helpBtn.GetComponent<Renderer>().enabled = false;
		}
	}
}

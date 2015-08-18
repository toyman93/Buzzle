using UnityEngine;
using System.Collections;

public class SoundBtn : MonoBehaviour {
	private GameObject soundBtn = null;

	void Start(){
		soundBtn = GameObject.Find ("sound_icon");
	}
	// Update is called once per frame
	void Update () {
		if (StoryMode.smClicked == true) {
			soundBtn.GetComponent<Renderer>().enabled = false;
		}
	}
}

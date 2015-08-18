using UnityEngine;
using System.Collections;

public class BackToMenuButton : MonoBehaviour {

	public string levelToLoad;

	void onMouseDown(){
		Application.LoadLevel(levelToLoad);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

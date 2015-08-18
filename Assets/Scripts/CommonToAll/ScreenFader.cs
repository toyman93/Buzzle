using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {
	//Sex sex sex sex sex power sex

	//Methods in this class are called when button is clicked


	public float fadeSpeed = 2f;   // Speed that the screen fades to and from black.

	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}


	//Used for screen transition
	public static void Fade(string levelToLoad) {

		//Fading to black
		//guiTexture.enabled = true;
		//guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);

		//Application.LoadLevel (levelToLoad);

		//guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);


	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

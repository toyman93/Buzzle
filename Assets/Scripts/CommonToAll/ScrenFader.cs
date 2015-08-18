using UnityEngine;
using System.Collections;

public class ScrenFader : MonoBehaviour {

	public float fadeSpeed = 1f;   // Speed that the screen fades to and from black.
	
	// Set an invisible texture above the whole screen
	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}


	// Have to manually enter every screen transition.
	void Update ()
	{
		if (StoryMode.smClicked == true) { // When StoryMode is clicked
						EndScene ();

		} else if (StoryNaration.snClicked == true){
			EndScene();
			StoryNaration.snClicked = false;

									//Debug.Log ("blackening");
		} else if (ToRenaissance.rnClicked == true) {
			EndScene ();
		} else if (p_Monalisa.Clicked == true) { //why did you do this i don't even
			EndScene ();
	
		} else if (BlitzMode.bmClicked == true) {
			EndScene ();
		} else if (ItemShop.itClicked == true) {
			EndScene ();		
			//------------------------------------------------------
		} else if (ToModernism.mdClicked == true) {
			EndScene ();		
		} else if (p_Creation.caClicked == true) {
			EndScene ();		
		}else if (p_Athens.atClicked == true){
			EndScene ();
		}

		else {
			StartScene ();	// When a screen is loaded.
		}
	}
	

	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();
	}
	
	
	public void EndScene ()
	{
		// Make sure the texture is enabled.
		GetComponent<GUITexture>().enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
	}
}

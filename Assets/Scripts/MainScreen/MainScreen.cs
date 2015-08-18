using UnityEngine;
using System.Collections;

public class MainScreen : MonoBehaviour {
	public static int volumeControl = 1;
	
	private void OnMouseDown(){
		if (volumeControl == 1){
			volumeControl = 0;
		}else if (volumeControl == 0) {
			volumeControl = 1;		
		}
		AudioListener.volume = volumeControl;
	}
}

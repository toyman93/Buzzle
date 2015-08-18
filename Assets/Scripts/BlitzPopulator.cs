using UnityEngine;
using System.Collections;

public class BlitzPopulator : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

	void OnMouseDown() {
		//Transform startButton = (transform.FindChild ("itemWindow_start") as Transform);
		GameObject generatorObj = GameObject.Find ("Generator");
		Generator generator = (Generator)generatorObj.GetComponent ("Generator");
		generator.started = true;
		generator.Populate ();
		generator.loopGenerate();
		GameObject Timer = GameObject.Find("TimeRemaining");
		
		Timer.gameObject.GetComponent<TimeRemaining>().started = true; 
		Timer.gameObject.GetComponent<TimeRemaining>().StartTimer(); 
		GameObject itemPopupWindow = GameObject.Find ("itemPopupWindow(Clone)");
		Debug.Log (itemPopupWindow == null);
		Destroy (itemPopupWindow);
	}

}


using UnityEngine;

using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class Palette : MonoBehaviour
{
	int runTwice = 0; 
	public string colour; 

	void Start(){
		Vector3 cur = transform.position; 
		Vector3 offset = new Vector3(0,0,0);
		GameObject smallColour;
		smallColour = Instantiate(Resources.Load("prefabs/small"+colour)) as GameObject;
		smallColour.transform.position = cur+offset;
		smallColour.GetComponent<Renderer>().enabled= false;
		runTwice++; 
	}
	
	public void OnMouseDown() 
	{ 
		if (runTwice==1){
			runTwice++; 
		}
		else if(runTwice==2){
			Vector3 cur = transform.position; 
			Vector3 offset = new Vector3(0,0,0);
			GameObject smallColour;
			smallColour = Instantiate(Resources.Load("prefabs/small"+colour)) as GameObject;
			smallColour.transform.position = cur+offset;
			smallColour.GetComponent<Renderer>().enabled= false; 
			runTwice++; 

		}
	}

	public void create(){
		Vector3 cur = transform.position; 
		Vector3 offset = new Vector3(0,0,0);
		GameObject smallColour;
		smallColour = Instantiate(Resources.Load("prefabs/small"+colour)) as GameObject;
		smallColour.transform.position = cur+offset;
		smallColour.GetComponent<Renderer>().enabled= false; 
	}
}
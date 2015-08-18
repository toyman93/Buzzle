using UnityEngine;
using System.Collections;

public class SkipPuzzle : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		GameObject generator = GameObject.Find ("Generator");
		generator.gameObject.GetComponent<Generator>().win = true;
	}
}

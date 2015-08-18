using UnityEngine;
using System.Collections;

public class Age : MonoBehaviour {
	public float startTime;
	public float age; 

	void Awake(){
		startTime = Time.time;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		age = Time.time - startTime;
	
	}
}

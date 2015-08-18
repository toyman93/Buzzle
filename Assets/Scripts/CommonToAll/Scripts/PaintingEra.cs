using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PaintingEra : MonoBehaviour {

	public string EraName;
	public int StartYear;
	public int EndYear;
	public bool IsComplete;
	public bool IsLocked;
	public List<Painting> PaintingsList;

	public void DeclareAsComplete() {
		this.IsComplete = true;
		//TODO
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
//		switch (EraName) {
//		case "Renaissance":
//			Application.LoadLevel("EraScene1");
//			break;
//		case "Romanticism":
//			Application.LoadLevel("EraSecene2");
//			break;
//		case "Impressionism":
//			Application.LoadLevel("EraScene3");
//			break;
//		case "Post-Impressionism":
//			Application.LoadLevel("EraScene4");
//			break;
//		case "Modernism":			
//			Application.LoadLevel("EraScene5");
//			break;
//		default:
//			return;
//		}
//		return;

		Player.Instance.CurrentEraName = this.EraName;
	}
}

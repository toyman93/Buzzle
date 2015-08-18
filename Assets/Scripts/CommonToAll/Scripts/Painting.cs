using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Painting : MonoBehaviour{

	public string PaintingName;
	public string ArtistName;
	public string EraName;
	public int StartYear;
	public int EndYear;
	public bool IsComplete;
	public bool IsLastPainting;
	public bool IsLocked;
	public List<Stage> StagesList;
	public int NumberOfStages;
	public int CompletionState;
	public string AssetBaseName;
	public string PaintingGameObjectName;
	public string FrameGameObjectName;

	private GameObject PaintingGameObject = null;
	private GameObject FrameGameObject = null;
	private float savedTime;
	private bool rotate = false;
	public static bool Clicked = false;
	public string levelToLoad;
	
	// Use this for initialization
	void Start () {
		PaintingGameObject = GameObject.Find (PaintingGameObjectName);
		FrameGameObject = GameObject.Find (FrameGameObjectName);
		//DontDestroyOnLoad (this);

		CompletionState = 0;
		
		//Debug.Log (Player.Instance.Progress.CurrentPainting.CompletionState);
		if (!Player.Instance.ProgressDictionary.ContainsKey (PaintingName)) {
			CompletionState = 0;
		} else {
			this.CompletionState = Player.Instance.ProgressDictionary[PaintingName];
		}
		UpdatePicture ();
		
		//		SpriteRenderer renderer = (SpriteRenderer)this.gameObject.GetComponent (typeof(SpriteRenderer));
		//		renderer.sprite = Resources.Load<Sprite> ("Materials/Reneissance/" + AssetBaseName + CompletionState.ToString());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		if (leftArrow.currentScreenPos != 0) {
//			PaintingGameObject.collider.enabled = false;     // Disable collider if the screen is not focused on Mona Lisa
//		} else {
//			PaintingGameObject.collider.enabled = true;      // If it is, enable collider.
//		}
		
		if (rotate == true) {
			if(Time.time - savedTime < 1){
				PaintingGameObject.transform.RotateAround(transform.position, transform.up, Time.deltaTime * 200f);  // rightmost variable is the speed of rotation
				FrameGameObject.transform.RotateAround(transform.position, transform.up, Time.deltaTime * 200f);
				PaintingGameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0); // Zoom
				FrameGameObject.transform.localScale += new Vector3(0.3f, 0.3f, 0);
				
			}
			
			// Transition after 1 second
			if(Time.time - savedTime > 1){
				rotate = false;
				PaintingGameObject.GetComponent<Renderer>().enabled = false;
				FrameGameObject.GetComponent<Renderer>().enabled = false;
				Clicked = false;
				Debug.Log("trying to load attempt 1");
				Application.LoadLevel (levelToLoad);
			}

		}
		//SEAN HALP YOUR TRANSITION ONLY WORKS SOMTIMES
		// im just str8 up going to next level cos urs is buggy
//		if (Time.time - savedTime > 1) {
//			Application.LoadLevel (levelToLoad);
//
//		}

	}
	
	void OnMouseUp(){
		//		Player.Instance.Progress.CurrentPainting = this;
		//		Player.Instance.Progress.CurrentPaintingGameObj = this.gameObject;
		//		Debug.Log ("OnMouseUp");

		Clicked = true;
		savedTime = Time.time;
		rotate = true;
	}
		
	void OnMouseDown() {
//		Player.Instance.Progress.CurrentPainting = Instantiate(this) as Painting; 
//		Player.Instance.Progress.CurrentPaintingGameObj = Instantiate(this.gameObject) as GameObject;
		//DontDestroyOnLoad (this);
		//DontDestroyOnLoad (Player.Instance.Progress.CurrentPainting);

		if (!Player.Instance.ProgressDictionary.ContainsKey (PaintingName)) {
			Player.Instance.ProgressDictionary.Add(PaintingName, CompletionState);
		} else {
			Player.Instance.ProgressDictionary[PaintingName] = CompletionState;
		}

		Player.Instance.CurrentPaintingName = this.PaintingName;
		Player.Instance.CurrentPaintingAssetBaseName = this.AssetBaseName;

		Debug.Log ("OnMouseDown");
	}

	public void DeclareAsComplete() {
		this.IsComplete = true;
		//TODO
	}

	public void UpdatePaintingCompletionState(int completionState) {
		this.CompletionState = completionState;
		if (IsLastPainting) {
			Player.Instance.Progress.CurrentEra.DeclareAsComplete();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void UpdatePicture() {
		SpriteRenderer renderer = (SpriteRenderer)this.gameObject.GetComponent (typeof(SpriteRenderer));
		renderer.sprite = Resources.Load<Sprite> ("Materials/" 
        	+ EraName + "/" + AssetBaseName + CompletionState.ToString());
//		Debug.Log ("Materials/" 
//		           + EraName + "/" + AssetBaseName + CompletionState.ToString ());
	}
}

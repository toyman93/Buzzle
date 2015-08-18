using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {

	public int StageNumber;
	public bool IsComplete;
	public bool IsLastLevel;
	public bool IsLocked;
	public int NoOfStars;

	public void DeclareAsComplete() {
		this.IsComplete = true;
		//TODO
		Player.Instance.Progress.CurrentPainting.UpdatePaintingCompletionState (StageNumber);
		if (IsLastLevel) {
			Player.Instance.Progress.CurrentPainting.DeclareAsComplete();
		}
	}

	//Im not sure whether this method should be here
	private void NavigateToNextStage() {
		if(Application.CanStreamedLevelBeLoaded("StageScene" + StageNumber.ToString())) {
			Application.LoadLevel("StageScene" + StageNumber.ToString());
		}
		else {
			Debug.Log("End of painting stage pack");
		}
	}

	void OnMouseDown() {
		//TODO
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

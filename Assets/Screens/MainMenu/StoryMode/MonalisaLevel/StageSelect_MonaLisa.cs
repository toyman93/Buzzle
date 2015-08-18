using UnityEngine;
using System.Collections;

public class StageSelect_MonaLisa : MonoBehaviour {

	public string PaintingEra;
	public int paintingNumber;
	public int stageNumber;
	public string levelToLoad=null;

	// Use this for initialization
	void Start () {
		if (PaintingEra == "Renaissance") {
			if (paintingNumber==1){
				if(stageNumber==1){
					levelToLoad="1_1";
				}
				if(stageNumber==2){
					levelToLoad="1_2";
				}
				if(stageNumber==3){
					levelToLoad="1_3";
				}
				if(stageNumber==4){
					levelToLoad="1_4";
				}
				if(stageNumber==5){
					levelToLoad="1_5";
				}
			}
			if (paintingNumber==2){
				if(stageNumber==1){
					levelToLoad="2_1";
				}
				if(stageNumber==2){
					levelToLoad="2_2";
				}
				if(stageNumber==3){
					levelToLoad="2_3";
				}
				if(stageNumber==4){
					levelToLoad="2_4";
				}
				if(stageNumber==5){
					levelToLoad="2_5";
				}
			}
			if (paintingNumber==3){
				if(stageNumber==1){
					levelToLoad="3_1";
				}
				if(stageNumber==2){
					levelToLoad="3_2";
				}
				if(stageNumber==3){
					levelToLoad="3_3";
				}
				if(stageNumber==4){
					levelToLoad="3_4";
				}
				if(stageNumber==5){
					levelToLoad="3_5";
				}
			}

		
		}

		if (PaintingEra == "Romanticism") {

		}

		if (PaintingEra == "Impressionism") {

		}

		if (PaintingEra == "PostImpressionism") {
		
		}

		if (PaintingEra == "Modernism") {
			if (paintingNumber==13){
				if(stageNumber==1){
					levelToLoad="13_1";
				}
				if(stageNumber==2){
					levelToLoad="13_2";
				}
				if(stageNumber==3){
					levelToLoad="13_3";
				}
				if(stageNumber==4){
					levelToLoad="13_4";
				}
				if(stageNumber==5){
					levelToLoad="13_5";
				}
			}
			if (paintingNumber==14){
				if(stageNumber==1){
					levelToLoad="14_1";
				}
				if(stageNumber==2){
					levelToLoad="14_2";
				}
				if(stageNumber==3){
					levelToLoad="14_3";
				}
				if(stageNumber==4){
					levelToLoad="14_4";
				}
				if(stageNumber==5){
					levelToLoad="14_5";
				}
			}
			if (paintingNumber==15){
				if(stageNumber==1){
					levelToLoad="15_1";
				}
				if(stageNumber==2){
					levelToLoad="15_2";
				}
				if(stageNumber==3){
					levelToLoad="15_3";
				}
				if(stageNumber==4){
					levelToLoad="15_4";
				}
				if(stageNumber==5){
					levelToLoad="15_5";
				}
			}

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
	
		Application.LoadLevel (levelToLoad);
		Player.Instance.CurrentStageNumber = this.stageNumber;
	}
}

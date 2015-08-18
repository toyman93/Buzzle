using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	//public class Level
	//{
	public int x;
	public int y;
	public int givenMoves; 
	public int moves; 
	public int minMoves; 
	public int level;
	bool win=false; 
	int count; 
	int index; 
	//	public Level(int x, int y){
	//		this.x = x;
	//		this.y = y; 
	//	}
	//}
	int complete = 0; 

	// Use this for initialization
	void Start () {
		Populate();  
		setLevel(level); 

		//hFill(x,0,"red");  
		//hFill(x,1,"blue");  
		DisplayProgressArt ();
	}

//	void awake() {
//		DontDestroyOnLoad (Player.Instance.Progress.CurrentPainting);
//		DontDestroyOnLoad (Player.Instance.Progress.CurrentPaintingGameObj);
//	}
	
	// Update is called once per frame
	void Update () { 
		if((win == false)&&(moves>=0))
		{
			count = 0; 
			for(int i = 0; i<x; i++){
				for(int j = 0; j<y; j++){
					//if not empty pos
					
					//string array of objectName
					string[] names = new string[200]; 
					//array of objects
					int noObjects = GameObject.FindGameObjectsWithTag(i+"."+j).Length;
					GameObject[] colourObjects = GameObject.FindGameObjectsWithTag(i+"."+j);
					
					
					if(noObjects > 2){
						int index=0;
						foreach (GameObject colourObject in colourObjects)
						{
							//check that it has parent
							//then store into string array 
							if(colourObject.transform.parent != null){
//								print(colourObject.transform.root.name);
								names[index] = colourObject.transform.root.name; 
								index++;
							}
							
						}
						if(names[0] == names[1]){//compare strings in string array and if equal increment
							count++;
						}
					}
//					print("COUNTTTTTTTTTTTTTTTTTTTTTTT = "+count); 
					//compare with same pos in parallel
				}
			}
			//print("COUNTTTTTTTTTTTTTTTTTTTTTTT = "+count); 
			if(count == (x*y)){
				win = true;
			}
		}

		else if(win){
			//p.UpdatePicture();
			//painting.UpdatePicture();
			//Player.Instance.Progress.CurrentPainting.UpdatePicture();
			playerController.state = 2; 
			if(complete==0){
				GameObject Complete = Instantiate(Resources.Load("prefabs/Complete")) as GameObject;
				if(givenMoves-moves <= minMoves){
					GameObject goldStar= Instantiate(Resources.Load("prefabs/goldstar")) as GameObject;
				}
				else{
					GameObject whiteStar= Instantiate(Resources.Load("prefabs/whitestar")) as GameObject;
				}
				complete++; 

				if (Player.Instance.ProgressDictionary[Player.Instance.CurrentPaintingName]
				    < Player.Instance.CurrentStageNumber) {
					Player.Instance.ProgressDictionary[Player.Instance.CurrentPaintingName]
					= Player.Instance.CurrentStageNumber;
				}
				DisplayUpdatedArt();
			}
			//show screen
			//check moves for score 
		}
		if((moves<=0) && (win ==false)){
			playerController.state = 3; 
			//moves--;
			if(complete==0){
				GameObject Complete = Instantiate(Resources.Load("prefabs/Failed")) as GameObject;
				complete++;
			}
		}
	}

	void DisplayUpdatedArt() {
		GameObject updatedArt = new GameObject ();
		SpriteRenderer renderer = (SpriteRenderer)updatedArt.AddComponent (typeof(SpriteRenderer));
		renderer.sprite = Resources.Load<Sprite> ("Materials/" + Player.Instance.CurrentEraName + "/" 
						+ Player.Instance.CurrentPaintingAssetBaseName
						+ Player.Instance.CurrentStageNumber);
		renderer.sortingOrder = 0;
		renderer.sortingLayerName = "Top";
		updatedArt.transform.localScale = new Vector3 (0.33F, 0.31F, 0);
		updatedArt.transform.position = new Vector2 (0,-0.74F);
	}

	void DisplayProgressArt() {
		GameObject updatedArt = new GameObject ();
		SpriteRenderer renderer = (SpriteRenderer)updatedArt.AddComponent (typeof(SpriteRenderer));
		renderer.sprite = Resources.Load<Sprite> ("Materials/" + Player.Instance.CurrentEraName + "/" 
		                                          + Player.Instance.CurrentPaintingAssetBaseName
		                                          + Player.Instance.ProgressDictionary[
		                                     Player.Instance.CurrentPaintingName]);
		renderer.sortingOrder = -1;
//		renderer.sortingLayerName = "Top";
		updatedArt.transform.localScale = new Vector3 (0.23F, 0.2F, 0);
		updatedArt.transform.position = new Vector2 (7.25F,3.24F);
	}

	void Place(int x, int y, string colour){
		//for pre placing colours in the puzzle 
		//place 1 z value ahead of initial grid
		GameObject colourobject;
		colourobject = Instantiate(Resources.Load("prefabs/"+colour)) as GameObject;
		Vector3 temp = new Vector3(x*2+6.2f,y*2-3,0);
		if((this.x==3)&&(this.y==3)){
			temp = new Vector3(x*1.2f+6.2f,y*1.2f-3.0f,0);
			Vector3 scale = new Vector3(0.15f,0.15f,0.15f);
			colourobject.transform.localScale = scale; 
		}
		string tag = x.ToString() + "." + y.ToString(); 
		GameObject position = colourobject.transform.FindChild("position").gameObject;
		position.gameObject.tag = tag;
		colourobject.transform.position = temp; 
	}
	
	void hFill(int x, int pos, string colourName)
	{
		for(int i=0; i<x; i++)
		{
			Vector3 temp;
			temp = GameObject.FindWithTag(i.ToString()+"."+pos.ToString()).transform.position;
			//get colour name
			//			print(gameObject.name);
			//			print(colourName); 
			GameObject colourobject;
			colourobject = Instantiate(Resources.Load("prefabs/"+colourName)) as GameObject;
			
			string tag = i.ToString() + "." + pos.ToString(); 
			GameObject position = colourobject.transform.FindChild("position").gameObject;
			position.gameObject.tag = tag;
			
			Vector3 offset = new Vector3(0,0,0);
			//			checkIfPosEmpty(temp+offset); 

			colourobject.transform.position = temp + offset;
			//playerController.state = 1; 
			//Destroy(colourobject.GetComponent<Colour>());
			//get grid (0,1), (1,1)... (i,1)
			//on top of each position place colour
		}

	}
	
	void vFill(int y, int pos, string colourName)
	{
		for(int i=0; i<y; i++)
		{
			Vector3 temp;
			temp = GameObject.FindWithTag(pos.ToString()+"."+i.ToString()).transform.position;
			//			print(colourName); 
			GameObject colourobject;
			colourobject = Instantiate(Resources.Load("prefabs/"+colourName)) as GameObject;
			
			
			string tag = pos.ToString() + "." + i.ToString(); 
			GameObject position = colourobject.transform.FindChild("position").gameObject;
			position.gameObject.tag = tag;
			
			Vector3 offset = new Vector3(0,0,0);
			//			checkIfPosEmpty(temp+offset); 
			colourobject.transform.position = temp + offset; 
			//playerController.state = 1; 
			//Destroy(colourobject.GetComponent<Colour>());
			//get grid (0,1), (1,1)... (i,1)
			//on top of each position place colour
		}
	}
	

	void Populate(){
		//originally creating grid both for puzzle and for the player
		
		GameObject grid;
		
		//instantiating the grid 
		//place coordinate based on size of box in relation to number of grids
		//and based on the i,j 
		for(int i=0; i<(x+1); i++){
			for(int j=0; j<(y+1); j++){
				if(i==0 && j==y){
				}
				else if(i==0){
					grid = Instantiate(Resources.Load("prefabs/hArrow")) as GameObject;
					Vector3 temp = new Vector3(i*2-3,j*2-3,0);
					grid.gameObject.tag = "h."+j.ToString();
					if((x==3) &&( y ==3)){
						temp = new Vector3(i*2-3.5f,j*2-3.5f,0);
						Vector3 scale = new Vector3(0.25f,0.25f,0.25f);
						grid.transform.localScale = scale; 
					}
					grid.transform.position = temp; 
				}
				else if(j==y){
					grid = Instantiate(Resources.Load("prefabs/vArrow")) as GameObject;
					grid.gameObject.tag = "v."+(i-1).ToString();
					Vector3 temp = new Vector3(i*2-3,j*2-3,0);
					if((x==3) &&( y ==3)){
						temp = new Vector3(i*2-3.5f,j*2-3.5f,0);
						Vector3 scale = new Vector3(0.25f,0.25f,0.25f);
						grid.transform.localScale = scale; 
					}
					grid.transform.position = temp; 
				}
				else{
					grid = Instantiate(Resources.Load("prefabs/grid")) as GameObject;
					Vector3 temp = new Vector3(i*2-3,j*2-3,0);
					grid.gameObject.tag = (i-1).ToString()+"."+j.ToString();
					if((x==3) &&( y ==3)){
						temp = new Vector3(i*2-3.5f,j*2-3.5f,0);
						Vector3 scale = new Vector3(0.2f,0.2f,0.2f);
						grid.transform.localScale = scale; 
					}
					grid.transform.position = temp; 
				}
			}
		}
			
		//
		for(int i=0; i<x; i++){
			for(int j=0; j<y; j++){
				//if int i=0
				//
				grid = Instantiate(Resources.Load("prefabs/grid")) as GameObject;
				Vector3 temp = new Vector3(i*2+6.2f,j*2-3,0);

				if((x==3) &&( y ==3)){
					temp = new Vector3(i*1.2f+6.2f,j*1.2f-3.0f,0);
					Vector3 scale = new Vector3(0.2f,0.2f,0.2f);
					grid.transform.localScale = scale; 
				}
				grid.transform.position = temp;
			}
		}
	}

	void setLevel(int level){

		switch(level)
		{
		case 1:
			Place(0,0, "red");
			Place(1,0, "red");
			Place(0,1, "blue");
			Place(1,1, "blue");
			break;
		case 2:
			Place(0,0, "purple");
			Place(1,0, "green");
			Place(0,1, "purple");
			Place(1,1, "green");
			break; 
		case 3:
			Place(0,0, "green");
			Place(1,0, "purple");
			Place(0,1, "yellow");
			Place(1,1, "orange");
			break; 
		case 4:
			Place(0,0, "green");
			Place(1,0, "purple");
			Place(0,1, "yellow");
			Place(1,1, "orange");
			break; 
		case 5:
			Place(0,0, "purple");
			Place(0,1, "orange");
			Place(0,2, "red");
			Place(1,0, "green");
			Place(1,1, "yellow");
			Place(1,2, "orange");
			Place(2,0, "blue");
			Place(2,1, "green");
			Place(2,2, "purple");
			break; 
		default:
			Place(0,0, "red");
			Place(1,0, "red");
			Place(0,1, "blue");
			Place(1,1, "blue");
			break; 
		}

	}
}

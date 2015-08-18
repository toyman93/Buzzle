using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	//public class Level
	//{
	public int x;
	public int y;
	public int givenMoves; 
	public int moves; 
	public int minMoves; 
	public int loops;
	public int score = 0; 
	bool locked = false; 
	object lockObject = new object(); 
	static public bool generating = true; 
	public bool win=false; 
	public bool started = true; 
	int count; 
	int index; 
	int noPuzzles = 0; 
	//	public Level(int x, int y){
	//		this.x = x;
	//		this.y = y; 
	//	}
	//}
	int complete = 0; 
	string[] colours = new string[] {"red", "yellow", "blue"};
	
	// Use this for initialization
	void Start () {
		//		Place(0,0, "red");
		//		Place(1,0, "red");
		//		Place(0,1, "blue");
		//		Place(1,1, "blue");		
		ShowItemPopupWindow(); 
		
		//hFill(x,1,"blue");  
	}
	
	
	public void loopGenerate()
	{
		StartCoroutine(DoMoving());
		generating = false; 
	}
	
	IEnumerator DoMoving()
	{	
		lock(lockObject){
			locked = true; 
			yield return new WaitForSeconds(.1f);
			Generate(); 
			yield return new WaitForSeconds(.01f);
			Generate(); 
			yield return new WaitForSeconds(.01f);
			Generate(); 
			yield return new WaitForSeconds(.01f);
			locked = false; 
		}
		
		// ... other sequential actions here?
	}
	// Update is called once per frame
	void Update () { 
		if(started==false){
			return; 
		}
		GameObject timer = GameObject.Find ("TimeRemaining"); 


		if((win == false))
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
					
					
					if(noObjects > 0){
						foreach (GameObject colourObject in colourObjects)
						{
							//check that it has parent
							//then store into string array 
							if(colourObject.transform.parent != null){
								//								print(colourObject.transform.root.name);
								count++;
							}
						}
					}
					if((noObjects > 1)){
						int index=0;
						string nameOfParent = "temp";
						foreach (GameObject colourObject in colourObjects)
						{
							//check that it has parent
							//then store into string array 
							if(colourObject.transform.parent != null){
								//								print(colourObject.transform.root.name);
								//print(colourObject.transform.root.name);
								if (index>1 || ((colourObject.transform.root.name == "orange(Clone)")  && (index>=1))|| ((colourObject.transform.root.name == "green(Clone)")  && (index>=1)) || ((colourObject.transform.root.name == "purple(Clone)")  && (index>=1)) ){
									//if(nameOfParent == colourObject.transform.root.name){
									Destroy(colourObject.transform.root.gameObject);
									
									//}
								}
								index++;
								//nameOfParent = colourObject.transform.root.name; 
							}
							
						}
					}
					
					
					//					print("COUNTTTTTTTTTTTTTTTTTTTTTTT = "+count); 
					//compare with same pos in parallel
				}
			}
			//print("COUNTTTTTTTTTTTTTTTTTTTTTTT = "+count); 
			if((count == 0) && (locked==false)){
				win = true;
				timer.gameObject.GetComponent<TimeRemaining>().startTime += 2f; 
			}
		}
		
		else if(win){
			//			playerController.state = 2; 
			//			if(complete==0){
			//				GameObject Complete = Instantiate(Resources.Load("prefabs/Complete")) as GameObject;
			//				if(givenMoves-moves <= minMoves){
			//					GameObject goldStar= Instantiate(Resources.Load("prefabs/goldstar")) as GameObject;
			//				}
			//				else{
			//					GameObject whiteStar= Instantiate(Resources.Load("prefabs/whitestar")) as GameObject;
			//				}
			//				complete++; 
			//			}
			
			//increase score
			//show speech bubble
			GameObject[] colours = GameObject.FindGameObjectsWithTag("colour");
			foreach (GameObject colour in colours)
			{
				Destroy(colour.gameObject); 
			}
			score += 100; 
			noPuzzles ++; 
			win = false; 
			loopGenerate();
			generating = false; 
			print ("win"); 
		}
		
		if((timer.gameObject.GetComponent<TimeRemaining>().timeRemaining <= 0.01f) && (win ==false)){
			timer.gameObject.GetComponent<TimeRemaining>().enabled = false; 
			playerController.state = 2; 
			if(complete==0){
				GameObject Complete = Instantiate(Resources.Load("prefabs/BlitzEnd")) as GameObject;
				complete++;
			}
		}
	}
	
	void Place(int x, int y, string colour){
		//for pre placing colours in the puzzle 
		//place 1 z value ahead of initial grid
		GameObject colourobject;
		colourobject = Instantiate(Resources.Load("prefabs/"+colour)) as GameObject;
		Vector3 temp = new Vector3(x*2+6.2f,y*2-3,0);
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
			
			//			Component[] allComponents = new Component[50];
			//			allComponents = gameObject.GetComponents (Component);
			//
			int noObjects = GameObject.FindGameObjectsWithTag(i+"."+pos).Length;
			GameObject[] sameObjects = GameObject.FindGameObjectsWithTag(i+"."+pos);
			
			
			if(noObjects > 0){
				foreach (GameObject sameObject in sameObjects)
				{
					//check that it has parent
					//then store into string array 
					if(sameObject.transform.parent != null){
						//								print(colourObject.transform.root.name);
						if(sameObject.transform.root.name==colourobject.gameObject.name){
							print("destroyed=====" + sameObject.transform.parent.gameObject); 
							Destroy (sameObject.transform.parent.gameObject); 
							print("destroyed=====" + colourobject); 
							Destroy(colourobject.gameObject);
						}
					}
				}
			}
			string tag = i.ToString() + "." + pos.ToString(); 
			
			//if same name colour object exists there destroy it 
			
			
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
			
			int noObjects = GameObject.FindGameObjectsWithTag(pos+"."+i).Length;
			GameObject[] sameObjects = GameObject.FindGameObjectsWithTag(pos+"."+i);
			
			
			if(noObjects > 0){
				foreach (GameObject sameObject in sameObjects)
				{
					//check that it has parent
					//then store into string array 
					if(sameObject.transform.parent != null){
						//								print(colourObject.transform.root.name);
						if(sameObject.transform.root.name==colourobject.gameObject.name){
							print("destroyed=====" + sameObject.transform.parent.gameObject); 
							Destroy (sameObject.transform.parent.gameObject); 
							print("destroyed=====" + colourobject); 
							Destroy(colourobject.gameObject);
						}
					}
				}
			}
			
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
	
	void Generate(){
		int pos;
		string colour; 
		generating = true; 
		//choose h fill 
		//choose (x/y), number from 0 to (x,y), colour 
		
		int choice = Random.Range(0,2);
		colour = colours[Random.Range(0,3)];
		
		switch(choice)
		{
		case 0:
			pos = Random.Range(0,x);
			hFill(x, pos, colour);
			print("x "+pos + " "+ colour);  
			break;
			
		case 1:
			pos = Random.Range(0,y);
			vFill(y, pos, colour);
			print("y "+pos + " "+ colour);  
			break; 
			
		default:
			break; 
		}
	}
	
	//hFill(x,1,"blue");  
	//	hFill (x,1,"yellow");
	//vFill (y,1,"blue");
	
	public void Populate(){
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
					grid.transform.position = temp; 
				}
				else if(j==y){
					grid = Instantiate(Resources.Load("prefabs/vArrow")) as GameObject;
					grid.gameObject.tag = "v."+(i-1).ToString();
					Vector3 temp = new Vector3(i*2-3,j*2-3,0);
					grid.transform.position = temp; 
				}
				else{
					grid = Instantiate(Resources.Load("prefabs/grid")) as GameObject;
					Vector3 temp = new Vector3(i*2-3,j*2-3,0);
					grid.gameObject.tag = (i-1).ToString()+"."+j.ToString();
					grid.transform.position = temp; 
				}
			}
		}
		
		
	}
	void ShowItemPopupWindow() {
		GameObject popup = Instantiate(Resources.Load("prefabs/itemPopupWindow")) as GameObject;
		Transform startButton = (transform.FindChild ("itemWindow_start") as Transform);
	}
}

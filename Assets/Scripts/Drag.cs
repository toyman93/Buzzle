using UnityEngine;

using System.Collections;

//[RequireComponent(typeof(BoxCollider))]

public class Drag : MonoBehaviour
{
	private Vector3 screenPoint;
	private Vector3 offset;
	GameObject[] objects;
	string contact = "none"; 
	int contactPos = -1;
	Generator generator;
	Game game; 




	void OnMouseDown() 
	{ 
		if (playerController.state <=1)
		{
			GetComponent<Renderer>().enabled = true; 

			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
			
			Cursor.visible = false;
		}
	}

	void Start(){
		if (GameObject.Find("Level1") != null)
		{
			game = GameObject.Find("Level1").GetComponent<Game>(); 
		}
		else
		{
			generator = GameObject.Find("Generator").GetComponent<Generator>(); 	
		}
	}

	void Update(){
		//objects = GameObject.FindGameObjectsWithTag("small");
	}

	void OnMouseDrag() 
	{ 
		if (playerController.state <=1)
		{
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			
			transform.position = curPosition;
		}
		
	}

	void OnCollisionEnter(Collision collision) 
	{


		//WHILE paint is overlapping arrow HIGHLIGHT PAINT SO USERS KNOW TO DROP IT
		//CALL FILL 
		if(collision.gameObject.tag.Contains(".")){
			string[] tag = collision.gameObject.tag.Split(new char[] {'.'});  

			if(tag[0]=="h"){
//				print("hArrow"); 
				//tag?
				contact = "h";
				contactPos = int.Parse(tag[1]); 
//				print(contact+contactPos); 
				//hFill(game.x, game.y, int.Parse(tag[1])); 

				//set tag to hArrow_01 or something for e.g. co ordinate 0,1 when instantiating based on x,y
				//set some value to h and its co ordinates and check when mouse up 
				//reset value on collision exit and destroy paint, since its not on box
				//using onMouseUp and Fill
			}
			
			if(tag[0]=="v"){
//				print("vArrow"); 
				contact = "v";
				contactPos = int.Parse(tag[1]); 
//				print(contact+contactPos); 
				//vFill(game.x, game.y, int.Parse(tag[1])); 
			}

		}


//		//if collision not == tag small
//		if(collision.gameObject.CompareTag("small"))
//		{
//			print("small hit");
//		}
//
//		else{
//			Destroy(gameObject);
//			for(int i=0; i<objects.Length; i++){
//				Destroy(objects[i]); 
//			}
//			refillPalette("red"); 
//			refillPalette("yellow");
//			refillPalette("blue");
//		}
	}

	void OnCollisionExit(Collision collisionInfo)
	{
//		print ("No longer in contact with " +collisionInfo.transform.name);
		contact = "none";
		contactPos = -1;
//		print(contact); 
	}



	void refillPalette(string colour)
	{
		GameObject colourObject = GameObject.Find(colour);
		Palette other = (Palette)colourObject.GetComponent(typeof(Palette));
		other.create();
	}

	void hFill(int x, int pos)
	{
		for(int i=0; i<x; i++)
		{
			Vector3 temp;
			temp = GameObject.FindWithTag(i.ToString()+"."+pos.ToString()).transform.position;
			//get colour name
//			print(gameObject.name);
			string colourName = gameObject.name;
			colourName = colourName.Substring(5,colourName.Length-12); 
//			print(colourName); 
			GameObject colourobject;
			colourobject = Instantiate(Resources.Load("prefabs/"+colourName)) as GameObject;

			string tag = i.ToString() + "." + pos.ToString(); 
			GameObject position = colourobject.transform.FindChild("position").gameObject;
			position.gameObject.tag = tag;

			Vector3 offset = new Vector3(0,0,0);
//			checkIfPosEmpty(temp+offset); 
			colourobject.transform.position = temp + offset;
			playerController.state = 1; 
			//Destroy(colourobject.GetComponent<Colour>());
			//get grid (0,1), (1,1)... (i,1)
			//on top of each position place colour
		}
		
		moveDecrement();
		//find level object
		//decrement moves
	}

	void vFill(int y, int pos)
	{
		for(int i=0; i<y; i++)
		{
			print ("hello"); 
			Vector3 temp;
			temp = GameObject.FindWithTag(pos.ToString()+"."+i.ToString()).transform.position;
			string colourName = gameObject.name;
			colourName = colourName.Substring(5,colourName.Length-12); 
//			print(colourName); 
			GameObject colourobject;
			colourobject = Instantiate(Resources.Load("prefabs/"+colourName)) as GameObject;
			print (colourobject.name); 
			
			
			string tag = pos.ToString() + "." + i.ToString(); 
			GameObject position = colourobject.transform.FindChild("position").gameObject;
			position.gameObject.tag = tag;
			print (colourobject.name); 
			Vector3 offset = new Vector3(0,0,0);
//			checkIfPosEmpty(temp+offset); 
			colourobject.transform.position = temp + offset; 
			playerController.state = 1; 
			//Destroy(colourobject.GetComponent<Colour>());
			//get grid (0,1), (1,1)... (i,1)
			//on top of each position place colour
		}

		moveDecrement();
	}

	void moveDecrement(){
		if (GameObject.Find("Level1") != null)
		{
			Game moves = GameObject.Find("Level1").GetComponent<Game>();
			moves.moves--; 
		}

	}
	
	//	public void checkIfPosEmpty(Vector3 targetPos)
//	{
//		GameObject[] allColours = GameObject.FindGameObjectsWithTag("colour");
//		foreach(GameObject current in allColours)
//		{
//			//string position = current.transform.position.ToString
//			print(current.name + current.transform.position.ToString());
//			if(current.transform.position == targetPos){
//				Destroy(current.gameObject); 
//			}
//		}
//	}


	void OnMouseUp()
	{
		Cursor.visible = true;
		objects = GameObject.FindGameObjectsWithTag("small");
		for (int i=0; i<objects.Length; i++){
			Destroy(objects[i]);
		}
		refillPalette("red"); 
		refillPalette("yellow");
		refillPalette("blue");

		switch(contact)
		{
		case "h":
//			print(contact);
//			print(contactPos);
			if (GameObject.Find("Level1") != null)
			{
				hFill(game.x, contactPos); 
			}else{
				hFill(generator.x, contactPos); 
			}
			//run fill
			break;
		case "v":
//			print(contact);
//			print(contactPos);
			if (GameObject.Find("Level1") != null)
			{
				vFill(game.y, contactPos); 
			}else{
				vFill(generator.y, contactPos); 
			}
			//run fill
			break; 
		default:
//			print(contact);
//			print(contactPos);
			break; 
		}
		
		// on collision with arrow button 
		//run fill otherwise nothin (e.g. when dropped in space)
	}
}
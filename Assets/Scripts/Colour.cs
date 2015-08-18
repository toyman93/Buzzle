using UnityEngine;
using System.Collections;

public class Colour : MonoBehaviour {
	void Start(){

		if (GameObject.Find("Generator") != null){
			Destroy(gameObject.GetComponent<Colour>()); 
		}
	}

	void Update(){
		//print("===========NAME=============="+ gameObject.name.ToString());

	}

	string mixedColour;
	private Age age;
	
	void OnCollisionEnter(Collision collision) 
	{
		if(collision.gameObject.tag == "colour")
		{
			if(((gameObject.name == "yellow(Clone)") && (collision.gameObject.name == "red(Clone)")) || ((gameObject.name =="red(Clone)") && (collision.gameObject.name =="yellow(Clone)"))){
				colourLogic("orange", collision); 
			}

			else if(((gameObject.name == "blue(Clone)") && (collision.gameObject.name == "red(Clone)")) || ((gameObject.name =="red(Clone)") && (collision.gameObject.name =="blue(Clone)"))){
				colourLogic("purple", collision); 
			}

			else if(((gameObject.name == "blue(Clone)") && (collision.gameObject.name == "yellow(Clone)")) || ((gameObject.name =="yellow(Clone)") && (collision.gameObject.name =="blue(Clone)"))){
				colourLogic("green", collision); 
			}



//			switch(mixedColour){
//			case "h":
//				print(contact);
//				print(contactPos);
//				hFill(game.x, contactPos); 
//				//run fill
//				break;
//			case "v":
//				print(contact);
//				print(contactPos);
//				vFill(game.y, contactPos); 
//				//run fill
//				break; 
//			default:
//				print(contact);
//				print(contactPos);
//				break; 
//			}

			//Destroy(collision.gameObject);
		}
	}

	void colourLogic (string colour, Collision collision){
		
		Destroy(collision.gameObject);
		print ("destroyed "+collision.gameObject.name);
		GameObject colourObject;
		colourObject = Instantiate(Resources.Load("prefabs/"+colour)) as GameObject;
		print  ("spawned "+colour); 
		GameObject position = collision.gameObject.transform.FindChild("position").gameObject;
		string tag = position.gameObject.tag;

		GameObject colourObjectPosition = colourObject.transform.FindChild("position").gameObject;
		colourObjectPosition.tag = tag; 
		
		//Vector3 offset = new Vector3(0,0,-1);
		Vector3 temp = gameObject.transform.position; 
		colourObject.transform.position = temp; //+ offset;
		print("positioned "+colour); 
		print("=================================================================="); 
	}

}

using UnityEngine;
using System.Collections;

public class BlitzColour : MonoBehaviour {
	bool once = true; 

	void Start(){
		if (GameObject.Find("Generator") == null ){
			Destroy(gameObject.GetComponent<BlitzColour>()); 
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
			if((gameObject.name =="red(Clone)")&&(collision.gameObject.name=="red(Clone)")){ //&& once){
				age = collision.gameObject.GetComponent<Age>();
				if(age.age >.1){ 
					
					Destroy(collision.gameObject); 
					Destroy(gameObject); 
				}
//				}else{
//					if(Generator.generating==false){
//						once = false; 
//					}
//				}
			}
			else if((gameObject.name =="blue(Clone)")&& (collision.gameObject.name=="blue(Clone)")){//&& once){
				age = collision.gameObject.GetComponent<Age>();
				if(age.age >.1){
					
					Destroy(collision.gameObject); 
					Destroy(gameObject); 
					}
//				}else{
//					if(Generator.generating==false){
//						once = false; 
//					}
//				}
			}
			else if((gameObject.name =="yellow(Clone)")&& (collision.gameObject.name=="yellow(Clone)")){//&& once){
				age = collision.gameObject.GetComponent<Age>();
				if(age.age >.1){
					
					Destroy(collision.gameObject); 
					Destroy(gameObject); 
				}
//				}else{
//					if(Generator.generating==false){
//						once = false; 
//					}				
//				}
			}



			else if((gameObject.name =="blue(Clone)") && (collision.gameObject.name == "purple(Clone)")){
				Destroy(gameObject); 
				print ("destroyed " + gameObject.name);
				colourLogic("red", collision); 
			}

			else if((gameObject.name =="red(Clone)") && (collision.gameObject.name == "purple(Clone)")){
				Destroy(gameObject); 
				print ("destroyed " + gameObject.name);
				colourLogic("blue", collision); 
			}

			else if((gameObject.name =="blue(Clone)") && (collision.gameObject.name == "green(Clone)")){
				Destroy(gameObject); 
				print (" BLUEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
				colourLogic("yellow", collision); 
			}

			else if((gameObject.name =="yellow(Clone)") && (collision.gameObject.name == "green(Clone)")){
				Destroy(gameObject); 
				colourLogic("blue", collision); 
			}

			else if((gameObject.name =="red(Clone)") && (collision.gameObject.name =="orange(Clone)")){
				Destroy(gameObject); 
				colourLogic("yellow", collision); 
			}

			else if((gameObject.name =="yellow(Clone)") && (collision.gameObject.name =="orange(Clone)")){
				Destroy(gameObject); 
				colourLogic("red", collision); 
			}



			else if(((gameObject.name == "yellow(Clone)") && (collision.gameObject.name == "red(Clone)")) || ((gameObject.name =="red(Clone)") && (collision.gameObject.name =="yellow(Clone)"))){
				colourLogic("orange", collision); 
			}

			else if(((gameObject.name == "blue(Clone)") && (collision.gameObject.name == "red(Clone)")) || ((gameObject.name =="red(Clone)") && (collision.gameObject.name =="blue(Clone)"))){
				colourLogic("purple", collision); 
			}

			else if(((gameObject.name == "blue(Clone)") && (collision.gameObject.name == "yellow(Clone)")) || ((gameObject.name =="yellow(Clone)") && (collision.gameObject.name =="blue(Clone)"))){
				colourLogic("green", collision); 
			}


			else if((gameObject.name == "green(Clone)") && (collision.gameObject.name == "red(Clone)")){
				Destroy(collision.gameObject);
			}

			else if((gameObject.name == "purple(Clone)") && (collision.gameObject.name == "yellow(Clone)")){
				Destroy(collision.gameObject); 
			}

			else if((gameObject.name == "orange(Clone)") && (collision.gameObject.name == "blue(Clone)")){
				Destroy(collision.gameObject);
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
		GameObject colourObject;
		colourObject = Instantiate(Resources.Load("prefabs/"+colour)) as GameObject;

		GameObject position = collision.gameObject.transform.FindChild("position").gameObject;
		string tag = position.gameObject.tag;

		GameObject colourObjectPosition = colourObject.transform.FindChild("position").gameObject;
		colourObjectPosition.tag = tag; 
		
		//Vector3 offset = new Vector3(0,0,-1);
		Vector3 temp = gameObject.transform.position; 
		colourObject.transform.position = temp; //+ offset;
	}

}

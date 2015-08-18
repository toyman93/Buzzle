using UnityEngine;
using System.Collections;

public class PurchaseButton : ScriptableObject {

	private string refItemId;
	private GameObject gameObjectInstance;
	private float xPos;
	private float yPos;

	public void init(string referenceItemId) 
	{
		this.refItemId = referenceItemId;
	}
	
	public void InstantiateGameObject()
	{
		GameObjectInstance = (GameObject)Instantiate (Resources.Load ("Prefabs/" + "buyButton"));
		GameObjectInstance.AddComponent <BoxCollider2D>();
		GameObjectInstance.AddComponent <PurchaseEventHandler>();
		XPos = GameObjectInstance.transform.position.x;
		YPos = GameObjectInstance.transform.position.y;
	}

	public void SetButtonPosition(float x, float y) {
		GameObjectInstance.transform.position = new Vector2 (x, y);
	}

	public void HideButton() {
		gameObjectInstance.GetComponent<Renderer>().enabled = false;
	}

	/* Exposed getters and setters, modify as needed */
	public string RefItemId { get { return refItemId; } set { refItemId = value; } }
	public GameObject GameObjectInstance { get { return gameObjectInstance; } set { gameObjectInstance = value; } }
	public float XPos { get { return xPos; } set { xPos = value; } }
	public float YPos { get { return yPos; } set { yPos = value; } }

}

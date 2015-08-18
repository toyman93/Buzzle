using UnityEngine;
using System.Collections;

public class ItemUIControl : MonoBehaviour, Purchase
{
	public PurchaseButton purchaseButton;

	public GameObject ItemFrame;
	public GameObject ItemPreview;

	public GameObject TextItemName;
	public GameObject TextItemDescription;
	public GameObject TextPrice;


	private Vector2 baseCoords;
	private Vector2 rectCoords;

	private string itemId, itemName, itemDescription;
	private double price;

	private Vector2 screenPointCoords;

	public void Init(string itemId, string itemName, string itemDescription, double price, Vector2 basePos)
	{	
		this.itemId = itemId;
		this.itemName = itemName;
		this.itemDescription = itemDescription;
		this.price = price;

		baseCoords = basePos;

		ItemFrame = (GameObject)Instantiate (Resources.Load ("Prefabs/" + "itemFrame"));
		ItemFrame.transform.position = baseCoords;

		ItemPreview = (GameObject)Instantiate (Resources.Load ("Prefabs/" + itemId));
		//Need to change to Indexing way of positioning
		ItemPreview.transform.position = baseCoords;

		purchaseButton = (PurchaseButton)ScriptableObject.CreateInstance ("PurchaseButton");
		purchaseButton.init (itemId);
		purchaseButton.InstantiateGameObject ();
		//Need to change to Indexing way of positioning
		purchaseButton.SetButtonPosition (baseCoords.x + (float)2.5, baseCoords.y - (float)1.2);

		/* Text */
		TextItemName = (GameObject)Instantiate (Resources.Load ("Prefabs/" + "generic_gui_text"));
		TextItemName.GetComponent<GUIText>().text = itemName;
		TextItemName.GetComponent<GUIText>().fontSize = 16;
		TextItemName.GetComponent<GUIText>().fontStyle = FontStyle.Bold;
		TextItemName.transform.position = 
			Camera.main.WorldToViewportPoint(new Vector2(
				baseCoords.x + (float)1.75, baseCoords.y + (float)1.65));

//		TextItemDescription = (GameObject)Instantiate (Resources.Load ("Prefabs/" + "generic_gui_text"));
//		TextItemDescription.guiText.text = itemDescription;
//		TextItemDescription.guiText.fontSize = 10;
//		TextItemDescription.transform.position = 
//			Camera.main.WorldToViewportPoint(new Vector2(baseCoords.x + 2, baseCoords.y + (float)0.5));

//		TextPrice = (GameObject)Instantiate (Resources.Load ("Prefabs/" + "generic_gui_text"));
//		TextPrice.guiText.text = "price: $" + price.ToString ("F");
//		TextPrice.guiText.fontSize = 10;
//		TextPrice.guiText.fontStyle = FontStyle.Bold;
//		TextPrice.transform.position = 
//			Camera.main.WorldToViewportPoint(new Vector2(baseCoords.x + (float)2, baseCoords.y));


		screenPointCoords = Camera.main.WorldToScreenPoint(
			new Vector2(baseCoords.x, baseCoords.y));
	}

	public void OnGUI() {
		DisplayPriceLabel ();
		DisplayItemDescription ();
	}

	private void DisplayPriceLabel() {
		GUIStyle style = new GUIStyle ();
		//style.normal.textColor = Color.red;
		style.wordWrap = true;
		style.fontSize = 12;	
		style.fontStyle = FontStyle.Bold;
		GUI.Label (new Rect(screenPointCoords.x + 92, Screen.height - screenPointCoords.y + 15,110,10), 
		           "Price: $" + price.ToString("F"), style);

	}

	private void DisplayItemDescription() {
		GUIStyle style = new GUIStyle ();
		style.wordWrap = true;
		style.fontSize = 12;	
		GUI.Label (new Rect(screenPointCoords.x + 92, Screen.height - screenPointCoords.y - 60,110,10), 
		           itemDescription, style);
	}

	public void OnPurchased()
	{
		//TODO
		Debug.Log ("OnPurchased in ItemUIControl");

		purchaseButton.HideButton ();
	}

}


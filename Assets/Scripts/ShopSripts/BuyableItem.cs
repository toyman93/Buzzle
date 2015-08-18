using UnityEngine;
using System.Collections;

/**
 * Pure Model describing a buyable item
 */
public class BuyableItem : Purchase {

	private string itemId { get; set; }
	private string itemName;
	private double price { get; set; }
	private string description { get; set; }
	private float xPos { get; set; }
	private float yPos { get; set; }

	private bool isPurchased = false;

	public BuyableItem() {
	}

	public BuyableItem(string itemId, double price, string description) 
	{
		this.itemId = itemId;
		this.price = price;
		this.description = description;
	}

	public void OnPurchased()
	{
		//TODO
		isPurchased = true;
		Debug.Log ("Item " + itemId + " was purchased at price " + price + "!");
		Player.Instance.AddPurchasedItem (this);
	}
	
	/* Exposed getters and setters, modify as needed */
	public string ItemId { get { return itemId; } set { itemId = value; } }
	public string ItemName { get { return itemName; } set { itemName = value; } }
	public double Price { get { return price; } set { price = value; } }
	public string Description { get { return description; } set { description = value; } }
	public float XPos { get { return xPos; } set { xPos = value; } }
	public float YPos { get { return yPos; } set { yPos = value; } }
}

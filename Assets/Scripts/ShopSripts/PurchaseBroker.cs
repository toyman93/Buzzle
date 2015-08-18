using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Command Design pattern, but as singleton
 */
public class PurchaseBroker {

	private Dictionary<GameObject, BuyableItem> ButtonToItemModel;

	private Dictionary<BuyableItem, ItemUIControl> ItemModelToUIControl;

	private static PurchaseBroker instance;

	private PurchaseBroker() { }

	public static PurchaseBroker Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new PurchaseBroker();
				instance.ButtonToItemModel = new Dictionary<GameObject, BuyableItem>();
				instance.ItemModelToUIControl = new Dictionary<BuyableItem, ItemUIControl>();
			}
			return instance;
		}
	}

	public void Add(BuyableItem buyableItem, ItemUIControl itemUIControl)
	{
		ButtonToItemModel.Add (itemUIControl.purchaseButton.GameObjectInstance, buyableItem);
		ItemModelToUIControl.Add (buyableItem, itemUIControl);
	}

	public void MakePurchase(GameObject pButtonGameObject)
	{
		BuyableItem item = ButtonToItemModel [pButtonGameObject];
		ItemUIControl itemUIControl = ItemModelToUIControl [item];

		item.OnPurchased ();
		itemUIControl.OnPurchased ();
	}

	public bool ContainsKey(GameObject gObj)
	{
		return ButtonToItemModel.ContainsKey(	gObj);
	}
}

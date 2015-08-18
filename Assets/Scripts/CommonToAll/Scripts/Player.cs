using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player {
	public string Name;
	public GameProgress Progress;
	public List<BuyableItem> PurchasedItems;
	public UsableItem CurrentUsableItem;

	public Dictionary<string, int> ProgressDictionary;
	public string CurrentEraName;
	public string CurrentPaintingName;
	public string CurrentPaintingAssetBaseName;
	public int CurrentStageNumber;

	private static Player instance;

	private Player() {
		this.Name = "Player";
		this.Progress = new GameProgress ();
		this.PurchasedItems = new List<BuyableItem> ();
		this.CurrentUsableItem = null;
		this.ProgressDictionary = new Dictionary<string, int> ();
	}

	public bool AddPurchasedItem(BuyableItem item) {
		foreach (BuyableItem currentItem in PurchasedItems) {
			if (currentItem.ItemId == item.ItemId) {
				Debug.Log("Can't purchase again! Item already purchased");
				return false;
			}
		}
		PurchasedItems.Add(item);
		return true;
	}	

//	public bool AddUsableItem(UsableItem item) {
//		foreach (UsableItem currentItem in UsableItems) {
//			if (currentItem.ItemId == item.ItemId) {
//				Debug.Log("Can't purchase again! Item already purchased");
//				return false;
//			}
//		}
//		UsableItems.Add(item);
//		return true;
//	}


	
	public static Player Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new Player();
			}
			return instance;
		}
	}
}

using UnityEngine;
using System.Collections;

public class UsableItem : BuyableItem, Purchase
{
	public UsableItem(string name) {
		this.ItemName = name;
	}

	new void OnPurchased() {
		Player.Instance.CurrentUsableItem = this;

	}
}


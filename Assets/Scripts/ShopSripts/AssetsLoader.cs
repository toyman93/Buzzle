using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Coordinates
{
	public float x;
	public float y;

	public Coordinates(float x, float y) {
		this.x = x;
		this.y = y;
	}
}

/* Kind of like the Controller in MVC */
public class AssetsLoader : MonoBehaviour
{
	public static float[] YCOORDS = { (float)0.52, (float)-3.26 };
	public static float[] XCOORDS = { (float)-7.17, (float)-1.24, (float)4.5 };
	public static List<Vector2> ITEMINDEX;

	//Dictionary[item prefab name, BuyableItem instance]
	private Dictionary<string, BuyableItem> ItemDictionary;

	private void InitializeIndex() {
		ITEMINDEX = new List<Vector2> ();

		foreach(float y in YCOORDS) {
			foreach(float x in XCOORDS) {
				ITEMINDEX.Add(new Vector2(x, y));
			}
		}
	}

	void Start () 
	{
		InitializeIndex ();
		InitializeItemDictionary ();
		LoadAllAssets ();
	}

	private void InitializeItemDictionary()
	{
		ItemDictionary = new Dictionary<string, BuyableItem> ();
		BuyableItem item;


		item = new BuyableItem ();
		item.ItemId = "heart_facepaint";
		item.ItemName = "Heart Facepaint";
//		item.Price = 5.00;
//		item.Description = "Paint your face with this cute heart and enhace your swag!";
		ItemDictionary.Add ("heart_facepaint", item);

		item = new BuyableItem ();
		item.ItemId = "green_sunglasses";
		item.ItemName = "Sunglasses";
//		item.Price = 1.00;
//		item.Description = "These are actually a pair of very rare swag glasses.";
		ItemDictionary.Add ("green_sunglasses", item);


//		item = new BuyableItem ();
//		item.ItemId = "jetpack";
//		item.Price = 5.00;
//		item.Description = "fly and shit";
//		ItemDictionary.Add ("jetpack", item);

		item = new BuyableItem ();
		item.ItemId = "mustache";
		item.ItemName = "Mustache";
//		item.Price = 5.00;
//		item.Description = "With this pedo stache, you can disguise yourself as a pedophile.";
		ItemDictionary.Add ("mustache", item);

		item = new BuyableItem ();
		item.ItemId = "orange_wings";
		item.ItemName = "Fairy Wings";
//		item.Price = 5.00;
//		item.Description = "I believe I can fly with these swag wings! Also makes you look like a fag.";
		ItemDictionary.Add ("orange_wings", item);

		item = new BuyableItem ();
		item.ItemId = "scroll60";
		item.ItemName = "Magic Scroll";
//		item.Price = 5.00;
//		item.Description = "This scroll increases weapon attack of your brush. Success rate: 60%";
		ItemDictionary.Add ("scroll60", item);

		item = new BuyableItem ();
		item.ItemId = "witch_hat";
		item.ItemName = "Witch Hat";
//		item.Price = 5.30;
//		item.Description = "This witch hat is from the ghetto yo whatcha know about swag.";
		ItemDictionary.Add ("witch_hat", item);
	}
	
	private void LoadAllAssets()
	{
		int index = 0;
		foreach (BuyableItem item in ItemDictionary.Values) {
			//This piece of code is fucking genius
			GameObject obj = new GameObject();
			obj.AddComponent(typeof(ItemUIControl));
			ItemUIControl itemUIControl = (ItemUIControl)obj.GetComponent(typeof(ItemUIControl));

			itemUIControl.Init (item.ItemId, item.ItemName, item.Description, item.Price, 
			                    ITEMINDEX[index]);

			RegisterInBroker(item, itemUIControl);

			index++;
		}
	}
	
	private void RegisterInBroker(BuyableItem b, ItemUIControl p) 
	{
		PurchaseBroker.Instance.Add(b, p);
	}

	public void OnGUI() {

		}
}
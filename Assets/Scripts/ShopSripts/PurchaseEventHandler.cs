using UnityEngine;
using System.Collections;

public class PurchaseEventHandler : MonoBehaviour, MouseListener
{
	public void OnMouseUp()
	{
		Debug.Log ("A button was clicked! Invoking PurchaseBroker");
		PurchaseBroker.Instance.MakePurchase (this.gameObject);
	}	
	public void OnMouseDown()
	{
	}

	void Start ()
	{
	}
	
	void Update ()
	{

	}
}


using UnityEngine;
using System.Collections;

public class BlitzItemChoose : MonoBehaviour
{
	public string ItemName;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

	void OnMouseDown() {
		Player.Instance.CurrentUsableItem =  new UsableItem (ItemName);
	}
}


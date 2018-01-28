using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGrab : MonoBehaviour {
	public Item item;
	// Use this for initialization
	void Start () {
		
	}
	
	 /// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button while
	/// over the GUIElement or Collider.
	/// </summary>
	void OnMouseDown()
	{
		InventoryManager.Instance.AddInventoryItem(item);
		gameObject.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		
	}
}

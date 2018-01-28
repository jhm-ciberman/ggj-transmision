using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorItem : MonoBehaviour {

	public Item item;	// Use this for initialization
	public Shadow shadow;
	
	void Start()
	{
		GetComponent<Image>().sprite = item.sprite;
		shadow.effectDistance = new Vector2(0,0);
	}

	void OnMouseEnter()
	{
		if (InventoryManager.Draggin){
			shadow.effectDistance = new Vector2(0.2f,0.2f);
		}
	}

	/// <summary>
	/// Called when the mouse is not any longer over the GUIElement or Collider.
	/// </summary>
	void OnMouseExit()
	{
		if (InventoryManager.Draggin){
			shadow.effectDistance = new Vector2(0,0);
		}
	}


	public void CheckDrag()
	{
		if (InventoryManager.Draggin){
				Debug.Log("Combinaste item " + item.itemName + " con " + InventoryManager.Instance.itemDragged.GetComponent<DraggedItem>().item.itemName );
				InventoryManager.Instance.CombineItems(this.item);
		} else {
			Debug.Log("Apreto");
			InventoryManager.Instance.DragItem(item);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}

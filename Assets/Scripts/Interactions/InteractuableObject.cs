using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableObject : MonoBehaviour {

	public List<string> interaccionIncorrecta;

	public List<string> agarrarFrases;

	public List<string> observarFrases;

	public bool InZone = false;

	public bool dragAble = false;

	public bool grabAble = false;

	public List<Item> items;


	public List<ItemNames> itemToUse;
	// Use this for initialization
	void Start () {
		GetComponent<Collider>().isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 /// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)	{
		if (other.tag.Equals("Player")){
				InZone = true;
		}
	}

	 /// <summary>
	/// OnTriggerExit is called when the Collider other has stopped touching the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerExit(Collider other)
	{
		if (other.tag.Equals("Player")){
			InZone = false;
		}
	}

 /// <summary>
/// OnMouseDown is called when the user has pressed the mouse button while
/// over the GUIElement or Collider.
/// </summary>
	void OnMouseDown()
	{
		if (InZone)
		{			
			if (dragAble)
			{
				if (InventoryManager.Instance.draggin)
				{
					Item aux = InventoryManager.Instance.itemDragged.GetComponent<DraggedItem>().item;
					if (itemToUse.Contains(aux.itemName))
					{
						switch(aux.itemName) {
							case ItemNames.Alicate:
								InventoryManager.Instance.AddInventoryItem(items[0]);
								DialogManager.Instance.ClearDialogs();
								DialogManager.Instance.AddDialog("ALTO CABLE!!!");
								gameObject.SetActive(false);
								break;
							case ItemNames.Balde:
								InventoryManager.Instance.RemoveInventoryItem(aux.itemName);
								InventoryManager.Instance.AddInventoryItem(items[0]);
								DialogManager.Instance.ClearDialogs();
								DialogManager.Instance.AddDialog("FRESHHH WATEEEEER");
								gameObject.SetActive(false);
								break;
							case ItemNames.BaldeAgua:
								GetComponent<EnableGameObject>().Enable();
								gameObject.SetActive(false);
								break;
							case ItemNames.TroncoLianaCable:
								DialogManager.Instance.ClearDialogs();
								DialogManager.Instance.AddDialog("WACHO QUE LINDA LIANA CON TRONCO CON CABLE");
								GetComponent<RopeFall>().Fall();
								break;
							default: 
								Debug.Log("Unknown Item");
								break;
						} 
						InventoryManager.Instance.StopDraggin();
					} else 
					{
						DialogManager.Instance.ClearDialogs();
						foreach(string a in interaccionIncorrecta) 
						{
							DialogManager.Instance.AddDialog(a);
						}
					}
				}
				else
				{
					DialogManager.Instance.ClearDialogs();
					foreach (string a in observarFrases)
					{
						DialogManager.Instance.AddDialog(a);
					}				}
			} else { // Not draggable
				if (grabAble){
						foreach (Item item in items) {
							InventoryManager.Instance.AddInventoryItem(item);
						}
						DialogManager.Instance.ClearDialogs();
						foreach(string a in agarrarFrases){
							DialogManager.Instance.AddDialog(a);
						}

						gameObject.SetActive (false);
				}
			}			
		}
	}
}


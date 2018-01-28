using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableObject : MonoBehaviour {

	public List<string> interaccionIncorrecta;

	public List<string> agarrarFrases;
	public bool InZone = false;

	public bool dragAble = false;

	public bool grabAble = false;

	public Item item;
	public List<ItemNames> itemToUse;
	// Use this for initialization
	void Start () {
		
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
		if (InZone){
			
			if (dragAble && InventoryManager.Instance.draggin){
				Item aux = InventoryManager.Instance.itemDragged.GetComponent<DraggedItem>().item;
				if (itemToUse.Contains(aux.itemName))
				{
					switch(aux.itemName){
						case ItemNames.Bateria:
						break;
						case ItemNames.Cuchillo:
						break;
						case ItemNames.Balde:
						break;
						case ItemNames.BaldeAgua:
						break;
						case ItemNames.Pinza:
						break;
						case ItemNames.Tronco:
						break;
						case ItemNames.Alicate:
						break;
						case ItemNames.Cable:
						break;
						case ItemNames.Destornillador:
						break;
						case ItemNames.Manual:
						break;
						case ItemNames.Modulo:
						break;
						case ItemNames.Cuerda:
						break;
					} 
				} else {
					foreach(string a in interaccionIncorrecta) {
						DialogManager.Instance.AddDialog(a);
					}
				}
			
		} else {
			if (grabAble){
					InventoryManager.Instance.AddInventoryItem(item);

					foreach(string a in agarrarFrases){
						DialogManager.Instance.AddDialog(a);
					}

					gameObject.SetActive (false);
			}
		}

			
		}
	}
}


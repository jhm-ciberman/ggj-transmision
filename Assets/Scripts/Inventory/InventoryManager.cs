﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    public bool draggin;

	public Camera inventoryCamera;
	public GameObject InventoryGrid;
    public GameObject itemDragged;

	public List<GameObject> itemsInInventory;
	public static InventoryManager Instance;

	public GameObject inventoryPrefab;

	public GameObject dragPrefab;

    public static bool Draggin { 

		get { return Instance.draggin;} 

		set { Instance.draggin = value; }
	}

    public void AddInventoryItem(Item toAdd){
		
		GameObject aux = Instantiate(inventoryPrefab,new Vector3(0,0,0),Quaternion.identity, InventoryGrid.transform);
		
		aux.GetComponentInChildren<InventorItem>().item = toAdd;
		
		}

	public void RemoveInventoryItem(ItemNames toRemove){
		foreach(GameObject a in itemsInInventory){
			if (a.GetComponentInChildren<InventorItem>().item.itemName == toRemove){
				Destroy(a);
				break;
			}
		}
	}

	public void AddInventoryItem(Item toAdd,bool DestroyItem)
	{

		GameObject aux = Instantiate(inventoryPrefab, new Vector3(0, 0, 0), Quaternion.identity, InventoryGrid.transform);

		aux.GetComponentInChildren<InventorItem>().item = toAdd;

		StopDraggin();

	}
	public void StopDraggin(){
		if (draggin)
		{
			Destroy(itemDragged);
			draggin = false;
		}
	}
	// Use this for initialization
	void Start () {
		
		if (Instance == null)
		
			Instance = this;

		itemsInInventory = new List<GameObject>();

		// InventoryGrid.SetActive(false);
	}
	
	public void DragItem(Item toDrag){
		if (!Draggin){
			
			Debug.Log("Start to Drag");
			
			Draggin = true;

			itemDragged = Instantiate(dragPrefab, inventoryCamera.ScreenToWorldPoint(Input.mousePosition),Quaternion.identity);

			itemDragged.GetComponent<DraggedItem>().item = toDrag;

			itemDragged.GetComponent<DraggedItem>().inventoryCamera = inventoryCamera;
			
			itemDragged.GetComponent<SpriteRenderer>().sprite = toDrag.sprite;
		}
	}
	
	public void CombineItems(Item a){
		if (a.itemName == ItemNames.Liana && GetOtherItem() == ItemNames.BaldeAgua){
			
		}
		else
		{
			Debug.Log("No podes unir a esos objetos !");
		}
	}

	private ItemNames GetOtherItem() {
		return itemDragged.GetComponent<DraggedItem>().item.itemName; 
	}
	// Update is called once per frame
	void Update () {
		//if (Draggin = false && itemDragged != null){
		//	Destroy(itemDragged);
//		}

		// if (Input.GetKeyUp(KeyCode.Mouse0)){
		// 	Draggin = false;
		// }
		// if (Input.GetKeyDown(KeyCode.Escape)){
			
		// 	if (InventoryGrid.activeSelf)
		// 		InventoryGrid.SetActive(false);
		// 	else
		// 		InventoryGrid.SetActive (true);

		// }
		if (Input.GetKeyDown(KeyCode.Mouse1)){
			if (Draggin){
				Destroy(itemDragged);
				Draggin = false;
			}
		}
	}
}
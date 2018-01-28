using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggedItem : MonoBehaviour {
	public Item item;
	
	public Camera inventoryCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (inventoryCamera.ScreenToWorldPoint(Input.mousePosition).x,inventoryCamera.ScreenToWorldPoint(Input.mousePosition).y,0);
	}
}

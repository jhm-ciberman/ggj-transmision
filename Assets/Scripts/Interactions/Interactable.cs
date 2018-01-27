using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public Transform interactionPoint; 
	
	public virtual void Interact() {
		Debug.Log("No interaction");
	}


}

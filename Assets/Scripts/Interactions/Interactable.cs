using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	[SerializeField]
	private Interaction interaction; 

	public void Interact() {
		if (interaction) {
			interaction.Interact();
		} else {
			Debug.LogError("No item defined for the interactable");
		}
		
	}


}

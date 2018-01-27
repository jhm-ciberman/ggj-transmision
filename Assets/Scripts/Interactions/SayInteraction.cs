using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class SayInteraction : Interactable
{

	public List<String> dialogs;
	
	public override void Interact()
	{
		foreach (String dialog in dialogs) {
			DialogManager.Instance.AddDialog(dialog);
		}
		
	}


}

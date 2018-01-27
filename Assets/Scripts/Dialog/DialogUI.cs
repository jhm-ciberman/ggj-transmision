using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogUI: MonoBehaviour {

	public Text dialogText; 

	void Start() {

	}

	public void SetText(string text) {
		this.dialogText.text = text;
	}
}
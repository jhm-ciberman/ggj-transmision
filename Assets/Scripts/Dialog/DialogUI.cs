using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogUI: MonoBehaviour {

	public Text dialogText; 

	private float _charsNumb; 

	private string _text = ""; 

	public float charsPerSecond = 10f; 

	public GameObject portrait; 

	void Start() {
		_charsNumb = 0; 
		dialogText.text = "";
	}

	void Update()
	{
		if (_text != "") {
			portrait.SetActive(true);
		 	if (_charsNumb < _text.Length) {
				_charsNumb += Time.deltaTime * charsPerSecond;
				dialogText.text = _text.Substring(0, Mathf.RoundToInt(_charsNumb));
			}
		} else {
			portrait.SetActive(false);
		}

	}

	public void SetText(string text) {
		_text = text; 
		dialogText.text = "";
		_charsNumb = 0; 
	}
}
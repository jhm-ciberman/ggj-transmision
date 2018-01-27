using UnityEngine;
using System;
using System.Collections.Generic;

public class DialogManager: MonoBehaviour {

	public float timePerCharacter = 0.05f;
	public float baseTime = 1f;
	
	[SerializeField]
	private DialogUI _dialogUI;

	private Queue<String> _dialogs = new Queue<String>(); 

	private float _timer = 0f;

	private static DialogManager _instance;

	public static DialogManager Instance
	{
		get
		{
			return _instance;
		}
	}

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
		}
		else
		{
			Destroy(this);
		}
	}

	private void Update() {
		if (_timer > 0f) 
		{
			_timer -= Time.deltaTime;
		} 
		else if (_dialogs.Count > 0)
		{
			String str = _dialogs.Dequeue();
			_dialogUI.SetText(str);
			_timer = baseTime + str.Length * timePerCharacter;
		} else {
			_dialogUI.SetText("");
		}
	}

	public void AddDialog(string str) {
		_dialogs.Enqueue(str);
	}

	public void ClearDialogs(string str)
	{
		_dialogs.Clear();
	}
}
using UnityEngine;
using System;
using System.Collections.Generic;

public class DialogManager: MonoBehaviour {
	[SerializeField]
	public float timePerCharacter = 0.05f;
	
	[SerializeField]
	public float baseTime = 1f;
	
	[SerializeField]
	private DialogUI _dialogUI;

	[SerializeField]
	private Actor _currentActor = null;

	private Queue<String> _dialogs = new Queue<String>(); 
	private Queue<Actor> _actors = new Queue<Actor>(); 

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
			Actor actor = _actors.Dequeue();
			_dialogUI.SetText(str);
			_dialogUI.SetPortraitSprite(actor.sprite);
			_timer = baseTime + str.Length * timePerCharacter;
		} else {
			_dialogUI.SetText("");
		}
	}

	public void AddDialog(string str) {
		if (_currentActor == null) {
			throw new Exception("Current actor is null");
		}
		_dialogs.Enqueue(str);
		_actors.Enqueue(_currentActor);
	}

	public void ChangeCurrentActor(Actor actor) {
		_currentActor = actor;
	}

	public void ClearDialogs()
	{
		_dialogs.Clear();
		_actors.Clear();
	}
}
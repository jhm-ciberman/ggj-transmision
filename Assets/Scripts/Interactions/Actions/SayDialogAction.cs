using UnityEditor;
using Inventory;
using System;
using UnityEngine;

namespace Actions {

	[Serializable]
	public class SayDialogAction : Action
	{
		[SerializeField]
		public String text = "";

		[SerializeField]
		public bool clearPreviousDialogs = false;

		public override void DoAction()
		{
			DialogManager.Instance.AddDialog(text);
			if (clearPreviousDialogs) {
				DialogManager.Instance.ClearDialogs(text);
			}
		}

		public override void OnGUI()
		{
			EditorGUILayout.LabelField("Say Dialog");
			text = EditorGUILayout.TextArea(text);
			EditorGUILayout.LabelField("Clear Previous Dialogs");
			clearPreviousDialogs = EditorGUILayout.Toggle(clearPreviousDialogs);
		}
	}
}
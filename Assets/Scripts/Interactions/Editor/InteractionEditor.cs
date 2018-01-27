using UnityEngine;
using UnityEditor;
using Actions;
using Conditions;
using System.Collections.Generic;
using System; 

[CustomEditor(typeof(Interaction))]
public class InteractionEditor: Editor {

	private ConditionType conditionType; 
	private ActionType actionType; 
	private ActionType elseActionType; 


	public override void OnInspectorGUI()
	{
		Interaction t = (Interaction) target;

		// =======================================================

		EditorGUILayout.LabelField("If");
		foreach (var condition in t.conditions)
		{
			EditorGUILayout.BeginVertical();
			condition.OnGUI();
			EditorGUILayout.EndVertical();
		}
		
		conditionType = (ConditionType) EditorGUILayout.EnumPopup(conditionType);
		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("Add If Condition"))
		{
			t.conditions.Add(MakeCondition(conditionType));
		}
		if (GUILayout.Button("Remove If Condition"))
		{
			t.conditions.RemoveAt(t.conditions.Count - 1);
		}
		EditorGUILayout.EndHorizontal();

		// =======================================================

		EditorGUILayout.LabelField("Then");
		foreach (var action in t.actions)
		{
			EditorGUILayout.BeginVertical();
			action.OnGUI();
			EditorGUILayout.EndVertical();
		}
		
		actionType = (ActionType)EditorGUILayout.EnumPopup(actionType);
		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("Add Then Condition"))
		{
			t.actions.Add(MakeAction(actionType));
		}
		if (GUILayout.Button("Remove Then Condition"))
		{
			t.actions.RemoveAt(t.actions.Count - 1);
		}
		EditorGUILayout.EndHorizontal();

		// =======================================================

		EditorGUILayout.LabelField("Else");
		foreach (var action in t.elseActions)
		{
			EditorGUILayout.BeginVertical();
			action.OnGUI();
			EditorGUILayout.EndVertical();
		}
		
		elseActionType = (ActionType) EditorGUILayout.EnumPopup(elseActionType);
		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("Add Else Condition"))
		{
			t.elseActions.Add(MakeAction(elseActionType));
		}
		if (GUILayout.Button("Remove Else Condition"))
		{
			t.elseActions.RemoveAt(t.elseActions.Count - 1);
		}
		EditorGUILayout.EndHorizontal();
	}


	public ICondition MakeCondition(ConditionType type)
	{
		switch (type)
		{
			case ConditionType.NoCondition:
				return new NoCondition();
			default:
				throw new System.Exception("Invalid condition type");
		}
	}

	public IAction MakeAction(ActionType type)
	{
		switch (type)
		{
			case ActionType.NoAction:
				return new NoAction();
			case ActionType.AddItem:
				return new AddItemAction();
			default:
				throw new System.Exception("Invalid action type");
		}
	}
}
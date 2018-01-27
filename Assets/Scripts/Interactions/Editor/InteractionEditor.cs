using UnityEngine;
using UnityEditor;
using Actions;
using Conditions;
using System.Collections.Generic;
using System; 

[Serializable]
[CustomEditor(typeof(Interaction))]
public class InteractionEditor: Editor {

	[SerializeField]
	private ConditionType conditionType; 

	[SerializeField]
	private ActionType actionType; 

	[SerializeField]
	private ActionType elseActionType; 

    void OnEnable ()
    {
		hideFlags = HideFlags.HideAndDontSave;

		Interaction t = (Interaction) target;
        
        if (t.conditions == null)
            t.conditions = new List<Condition>();
		if (t.actions == null)
            t.actions = new List<Actions.Action>();
		if (t.elseActions == null)
            t.elseActions = new List<Actions.Action>();
    }

	public override void OnInspectorGUI()
	{
		Interaction t = (Interaction) target;

		// =======================================================
		
		EditorGUILayout.LabelField("If");
		foreach (Condition condition in t.conditions)
		{
			EditorGUILayout.BeginVertical();
			condition.OnGUI();
			EditorGUILayout.EndVertical();
			EditorGUILayout.Separator();
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
			EditorGUILayout.Separator();
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
		
		Debug.Log("Set dirty");
		EditorUtility.SetDirty(t);
		AssetDatabase.SaveAssets();
		/*if(EditorGUI.EndChangeCheck()) {
			//serObj.ApplyModifiedProperties();
			//
			
		}*/
	}


	public Condition MakeCondition(ConditionType type)
	{
		switch (type)
		{
			case ConditionType.NoCondition:
				return CreateInstance<NoCondition>();
			case ConditionType.HasItem: 
				return CreateInstance<HasItemCondition>();
			default:
				throw new System.Exception("Invalid condition type");
		}
	}

	public Actions.Action MakeAction(ActionType type)
	{
		switch (type)
		{
			case ActionType.NoAction:
				return CreateInstance<NoAction>();
			case ActionType.AddItem:
				return CreateInstance<AddItemAction>();
			case ActionType.SayDialog:
				return CreateInstance<SayDialogAction>();
			default:
				throw new System.Exception("Invalid action type");
		}
	}
}
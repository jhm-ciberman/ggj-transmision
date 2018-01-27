using UnityEngine;
using UnityEditor;
using Actions;
using Conditions;

[CustomEditor(typeof(Interaction))]
public class InteractionEditor: Editor {

	private ConditionType conditionType; 
	private ActionType actionType; 
	private ActionType elseActionType; 


	public override void OnInspectorGUI()
	{
		Interaction t = (target as Interaction);

		EditorGUILayout.LabelField("If");
		foreach (var condition in t.conditions) {
			condition.OnGUI();
		}

		this.conditionType = (ConditionType) EditorGUILayout.EnumPopup(this.conditionType);
		if (GUILayout.Button("Add If Condition"))
		{
			t.conditions.Add(MakeCondition(this.conditionType));
		}
			
		EditorGUILayout.LabelField("Then");
		foreach (var action in t.actions)
		{
			action.OnGUI();
		}

		this.actionType = (ActionType) EditorGUILayout.EnumPopup(this.actionType);
		if (GUILayout.Button("Add Then Action"))
		{
			t.actions.Add(MakeAction(this.actionType));
		}

		
		EditorGUILayout.LabelField("Else");
		foreach (var elseAction in t.elseActions)
		{
			elseAction.OnGUI();
		}

		this.elseActionType = (ActionType) EditorGUILayout.EnumPopup(this.elseActionType);
		if (GUILayout.Button("Add Else Action"))
		{
			t.elseActions.Add(MakeAction(this.elseActionType));
		}
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
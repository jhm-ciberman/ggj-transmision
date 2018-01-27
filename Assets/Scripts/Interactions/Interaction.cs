using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Actions;
using Conditions;


public enum ActionType
{
	NoAction,
	AddItem,
	SayDialog,
}
public enum ConditionType
{
	NoCondition,
	HasItem

}

[System.Serializable]
[CreateAssetMenu(fileName = "Interaction", menuName = "PointAndClick/Interaction", order = 1)]
public class Interaction : ScriptableObject {

	[SerializeField]
	public List<Condition> conditions;

	[SerializeField]
	public List<Action> actions;

	[SerializeField]
	public List<Action> elseActions;


	public void Interact() {
		if (CheckConditions(this.conditions)) {
			DoActions(this.actions);
		} else {
			DoActions(this.elseActions);
		}
	}

	private bool CheckConditions(List<Condition> conditions) 
	{
		foreach (var condition in conditions) 
		{
			if (!condition.Check()) 
			{
				return false;
			}
		}
		return true;
	}

	private void DoActions(List<Action> actions)
	{
		foreach (var action in actions)
		{
			action.DoAction();
		}
	}

}

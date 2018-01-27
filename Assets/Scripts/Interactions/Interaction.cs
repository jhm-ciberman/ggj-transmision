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
}
public enum ConditionType
{
	NoCondition,

}

[CreateAssetMenu(fileName = "Interaction", menuName = "PointAndClick/Interaction", order = 1)]
public class Interaction : ScriptableObject {

	public List<ICondition> conditions = new List<ICondition>();

	public List<IAction> actions = new List<IAction>();

	public List<IAction> elseActions = new List<IAction>();

	public void Interact() {
		if (CheckConditions(this.conditions)) {
			DoActions(this.actions);
		} else {
			DoActions(this.elseActions);
		}
	}

	private bool CheckConditions(List<ICondition> conditions) 
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

	private void DoActions(List<IAction> actions)
	{
		foreach (var action in actions)
		{
			action.DoAction();
		}
	}

}

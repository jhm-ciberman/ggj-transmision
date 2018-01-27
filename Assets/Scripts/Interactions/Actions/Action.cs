using UnityEngine;

namespace Actions
{
	[System.Serializable]
	public abstract class Action: ScriptableObject
	{
		[SerializeField]
		public abstract void DoAction();
		[SerializeField]
		public abstract void OnGUI();
	}
}
using UnityEngine;

namespace Conditions {
	[System.Serializable]
	public abstract class Condition: ScriptableObject
	{
		[SerializeField]
		public abstract bool Check();
		[SerializeField]
		public abstract void OnGUI();
	}
}
using UnityEditor;

namespace Conditions {
	public class NoCondition : ICondition
	{
		public bool Check()
		{
			return true;
		}

		public void OnGUI()
		{
			EditorGUILayout.LabelField("No Condition");
		}
	}
}


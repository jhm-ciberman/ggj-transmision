using UnityEditor;
using UnityEngine;

namespace Conditions {

	[System.Serializable]
	public class NoCondition : Condition
	{
		public override bool Check()
		{
			return true;
		}

		public override void OnGUI()
		{
			EditorGUILayout.LabelField("No Condition");
		}
	}
}


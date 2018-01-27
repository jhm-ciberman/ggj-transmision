using UnityEditor;
using UnityEngine;

namespace Actions {

	[System.Serializable]
	public class NoAction : Action
	{
		public override void DoAction()
		{
			// Nothing
		}

		public override void OnGUI()
		{
			EditorGUILayout.LabelField("No action");
		}
	}
}
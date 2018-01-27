using UnityEditor;

namespace Actions {
	public class NoAction : IAction
	{
		public void DoAction()
		{
			// Nothing
		}

		public void OnGUI()
		{
			EditorGUILayout.LabelField("No action");
		}
	}
}
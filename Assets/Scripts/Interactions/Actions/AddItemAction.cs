using UnityEditor;
using Inventory;

namespace Actions {
	public class AddItemAction : IAction
	{
		public Item item;
		public void DoAction()
		{
			// Nothing
		}

		public void OnGUI()
		{
			EditorGUILayout.LabelField("Add Item");
			item = (Item) EditorGUILayout.ObjectField(item, typeof(Item), true);
		}
	}
}
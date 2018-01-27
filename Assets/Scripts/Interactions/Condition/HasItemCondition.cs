using UnityEditor;
using Inventory; 

namespace Conditions {
	public class HasItemCondition : ICondition
	{
		public Item item;
		public bool Check()
		{
			return InventoryManager.Instance.HasItem(item);
		}

		public void OnGUI()
		{
			EditorGUILayout.LabelField("No Condition");
		}
	}
}


using UnityEditor;
using Inventory;
using UnityEngine;

namespace Conditions {

	[System.Serializable]
	public class HasItemCondition : Condition
	{
		public Item item;
		public override bool Check()
		{
			return InventoryManager.Instance.HasItem(item);
		}

		public override void OnGUI()
		{
			EditorGUILayout.LabelField("Has Item");
			item = (Item)EditorGUILayout.ObjectField(item, typeof(Item), true);
		}
	}
}


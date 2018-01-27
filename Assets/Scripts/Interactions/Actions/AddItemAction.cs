using UnityEditor;
using Inventory;
using UnityEngine;

namespace Actions {

	[System.Serializable]
	public class AddItemAction : Action
	{
		[SerializeField]
		public Item item;
		
		public override void DoAction()
		{
			InventoryManager.Instance.AddItem(item);
		}

		public override void OnGUI()
		{
			EditorGUILayout.LabelField("Add Item");
			item = (Item) EditorGUILayout.ObjectField(item, typeof(Item), true);
		}
	}
}
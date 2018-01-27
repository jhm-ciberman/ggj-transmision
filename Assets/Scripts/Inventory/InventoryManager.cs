using UnityEngine;
using System.Collections.Generic;

namespace Inventory {
	public class InventoryManager : MonoBehaviour
	{

		private List<Item> items = new List<Item>();

		public void AddItem(Item item) {
			items.Add(item);
		}

		public bool RemoveItem(Item item)
		{
			return items.Remove(item);
		}

		public void HasItem(Item item)
		{
			items.Contains(item);
		}

		
	}
}

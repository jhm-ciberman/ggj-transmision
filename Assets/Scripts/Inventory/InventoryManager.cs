using UnityEngine;
using System.Collections.Generic;

namespace Inventory {
	public class InventoryManager : MonoBehaviour
	{

		private List<Item> _items;

		private static InventoryManager _instance; 


		public static InventoryManager Instance
		{
			get
			{
				return _instance;
			}
		}

		private void Awake() {
			if (_instance == null) {
				_instance = this;
			} else {
				Destroy(this);
			}
		}

		public void AddItem(Item item) {
			_items.Add(item);
		}

		public bool RemoveItem(Item item)
		{
			return _items.Remove(item);
		}

		public bool HasItem(Item item)
		{
			return _items.Contains(item);
		}

		
	}
}

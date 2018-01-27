using UnityEngine;
namespace Inventory {
	[CreateAssetMenu(fileName = "Item", menuName = "PointAndClick/Item", order = 1)]
	public class Item: ScriptableObject
	{
		public string itemName = "Item Name"; 
		public Sprite sprite; 

	}
}

using UnityEngine;
	[CreateAssetMenu(fileName = "Item", menuName = "PointAndClick/Item", order = 1)]
	public class Item: ScriptableObject
	{
		public Sprite sprite; 
		
		public ItemNames itemName;
	}


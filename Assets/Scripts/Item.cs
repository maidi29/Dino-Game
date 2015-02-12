using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	public string itemName;
	public int itemID;
	public string itemDesc;
	public Texture2D itemIcon;
	public float itemHeat;
	//public int itemSpeed;
	public ItemType itemType;

	public enum ItemType {
		burnable,
		meltable,
		notBurnable,
	}

	public Item(string name, int id, string desc, float heat, ItemType type) {
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemIcon = Resources.Load<Texture2D> ("Item Icons/" + name);
		itemHeat = heat;
		itemType = type;
	}

	public Item (){
	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, slotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item>();
	private bool showInventory;
	private ItemDatabase database;
	private bool showTooltip;
	private string tooltip;
	
	private bool draggingItem;
	private Item draggedItem;
	private int prevIndex;


	public GameObject feuerzeug;
	public GameObject kessel;
	public GameObject holz;

	public GameObject eimer;

	public GameObject foen;
	public GameObject hammer;
	public GameObject eisblock;



	GUIText tipp;

	
	// Use this for initialization
	void Start () {
		for (int i = 0; i < (slotsX * slotsY); i++){
			slots.Add(new Item());
			inventory.Add (new Item());

		}
		tipp = GameObject.Find("Tipp").guiText;
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();

	}
		
	void Update () {
		if (Input.GetButtonDown ("Inventory")) {
			showInventory = !showInventory;
		}
		if (showInventory) {
			tipp.text = "Drücke I um das Inventar zu schließen.";
		}
		else if (!showInventory) {
			tipp.text = "Drücke I um das Inventar zu öffnen.";
		}

				
		
	}
	
	void OnGUI () {
		tooltip = "";
		GUI.skin = skin;
		if (showInventory) {
			DrawInventory ();
			if (GUI.Button (new Rect (10, 190, 100, 40), "Save", skin.GetStyle("Slot"))) {
				SaveInventory ();
			}
			if (GUI.Button (new Rect (120, 190, 100, 40), "Load", skin.GetStyle("Slot"))) {
				LoadInventory();
			}
			if (showTooltip) {
				GUI.Box (new Rect(Event.current.mousePosition.x + 15f, Event.current.mousePosition.y, 150, 150), tooltip, skin.GetStyle("Tooltip"));
			}
			if (draggingItem) {
				GUI.DrawTexture (new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);
			}
		}
	}
	
	void DrawInventory () {
		Event e = Event.current;
		int i = 0;
		for (int y = 0; y < slotsY; y++){
			for (int x = 0; x < slotsX; x++) {
				Rect slotRect = new Rect (x*55 + 10, y*55 + 10, 50, 50);
				GUI.Box (slotRect, "", skin.GetStyle("Slot"));
				slots[i] = inventory[i];
				if(slots[i].itemName != null){
					GUI.DrawTexture(slotRect, slots[i].itemIcon);
					if (slotRect.Contains(e.mousePosition)){
						tooltip = CreateTooltip (slots[i]);
						showTooltip = true;
						if(e.button == 0 && e.type == EventType.mouseDrag && !draggingItem) {
							draggingItem = true;
							prevIndex = i;
							draggedItem = slots[i];
							inventory[i] = new Item();
						}
						if (e.type == EventType.mouseUp && draggingItem) {
							inventory[prevIndex] = inventory[i];
							inventory [i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
						if (e.isMouse && e.type == EventType.mouseDown && e.button == 1){
							UseItem();
							RemoveItem(slots[i].itemID);
						}
					}
				}
				else {
					if (slotRect.Contains(e.mousePosition)) {
						if(e.type == EventType.mouseUp && draggingItem) {
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
					}
				}
				if (tooltip == "") {
					showTooltip = false;
				}
				i++;
			}
		}
	}
	string CreateTooltip (Item item) {
		tooltip = item.itemName + "\n\n" + item.itemDesc + "\n\n Rechtsklick um zu benutzen";
		return tooltip;
	}
	
	void RemoveItem (int id) {
		for (int i = 0; i < inventory.Count; i++) {
			if (inventory [i].itemID == id) {
				inventory[i] = new Item();
				break;
			}
		}
	}
	
	public void AddItem (int id) {
		for (int i = 0; i < inventory.Count; i++) {
			if (inventory[i].itemName == null) {
				for(int j = 0; j < database.items.Count; j++){
					if(database.items[j].itemID == id) {
						inventory[i] = database.items[j];
					}
				}
				break;
			}
		}
	}
	
	//Check if Object with Certain ID is in the inventory:
	bool InventoryContains (int id) {
		bool result = false;
		for (int i = 0; i < inventory.Count; i++) {
			result = inventory [i].itemID == id;
			if(result) {
				break;
			}
		}
		return result;
	}

	void UseItem() {
		int i = 0;


		if (slots[i].itemID == 1){
			holz.transform.parent = null;
			holz.SetActive (true);
		}
		else if (slots[i].itemID == 2){
			feuerzeug.transform.parent = null;
			feuerzeug.SetActive (true);
		}
		else if (slots[i].itemID == 3){
			hammer.transform.parent = null;
			hammer.SetActive (true);
		}
		else if (slots[i].itemID == 4){
			foen.transform.parent = null;
			foen.SetActive (true);
		}			
		else if (slots [i].itemID == 5) {
			eimer.transform.parent = null;
			eimer.SetActive (true);
		}
		else if (slots[i].itemID == 6){
			kessel.transform.parent = null;
			kessel.SetActive (true);
		}
		
	}

	void SaveInventory () {
		for(int i = 0; i < inventory.Count; i++) {
			PlayerPrefs.SetInt ("Inventory "+ i, inventory[i].itemID);
		}
	}
	void LoadInventory () {
		for(int i = 0; i < inventory.Count; i++) {
			inventory[i] = PlayerPrefs.GetInt ("Inventory " + i, -1) >= 0 ? database.items[PlayerPrefs.GetInt ("Inventory " + i)] : new Item() ;
		}
	}
}

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

	GameObject objects;
	GameObject dino;
	Transform hands;
	
	Vector3 dinoposition;
	Vector3 placevec;
	Vector3 holdvec;
	
	GUIText tipp;

	public bool use = false;
	
	
	// Use this for initialization
	void Start () {
		for (int i = 0; i < (slotsX * slotsY); i++){
			slots.Add(new Item());
			inventory.Add (new Item());
		}
		tipp = GameObject.Find("Tipp").guiText;
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
		dino = GameObject.FindGameObjectWithTag ("Player");
		hands = dino.transform.FindChild ("Krallen3");



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
		dinoposition = dino.transform.position;
		placevec = dino.transform.forward * 3;
		holdvec = dino.transform.forward * 1.5f;
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
						if(e.button == 2 && e.type == EventType.mouseDrag && !draggingItem) {
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
							PlaceItem(slots[i].itemID,i);
							RemoveItem(slots[i].itemID);
						}
						if (e.isMouse && e.type == EventType.mouseDown && e.button == 0) {
							if (use == false){
							UseItem(slots[i].itemID,i);
							RemoveItem (slots[i].itemID);
							}
							else if (use == true) {
								return;
							}
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
		tooltip = item.itemName + "\n\n" + item.itemDesc + "\n\n Linksklick um zu benutzen \n\n Rechtsklick um abzulegen";
		return tooltip;
	}
	
	void RemoveItem (int id) {
		for (int i = 0; i < inventory.Count; i++) {
			if (inventory[i].itemID == id) {
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
	
	void UseItem (int id, int slot) {
		use = true;
		switch (id){
		case 1: {
			//holz.GetComponent<ItemBounce>().enabled = false;
			holz.transform.position = dinoposition + holdvec;
			holz.transform.parent = hands;
			holz.SetActive (true);
			break;
		}
		
		case 2: {
			feuerzeug.transform.position = dinoposition + holdvec;
			feuerzeug.transform.parent = hands;
			feuerzeug.SetActive (true);
			break;
		}
		case 3: {
			hammer.transform.position = dinoposition + holdvec;
			hammer.transform.parent = hands;
			hammer.SetActive (true);
			break;
		}
		case 4: {
			foen.transform.position = dinoposition + holdvec;
			foen.transform.parent = hands;
			foen.SetActive (true);
			break;
		}			
		case 5: {
			eimer.transform.position = dinoposition + holdvec;
			eimer.transform.parent = hands;
			eimer.SetActive (true);
			break;
		}
		case 6: {
			kessel.transform.position = dinoposition + holdvec;
			kessel.transform.parent = hands;
			kessel.SetActive (true);
			break;
		}
		}
	}
	
	void PlaceItem(int id, int slot) {
		switch (id) {
		case 1: {
			holz.transform.parent = null;
			holz.transform.position = dinoposition + placevec;
			//holz.transform.position += vec;
			holz.SetActive (true);
			break;
		}
		case 2: {
			feuerzeug.transform.parent = null;
			feuerzeug.transform.position = dinoposition + placevec;
			feuerzeug.SetActive (true);
			break;
		}
		case 3: {
			hammer.transform.parent = null;
			hammer.transform.position = dinoposition + placevec;
			hammer.SetActive (true);
			break;
		}
		case 4: {
			foen.transform.parent = null;
			foen.transform.position = dinoposition + placevec;
			foen.SetActive (true);
			break;
		}			
		case 5:  {
			eimer.transform.parent = null;
			eimer.transform.position = dinoposition + placevec;
			eimer.SetActive (true);
			break;
		}
		case 6:{
			kessel.transform.parent = null;
			kessel.transform.position = dinoposition + placevec;
			kessel.SetActive (true);
			break;
		}	
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

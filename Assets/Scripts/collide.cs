using UnityEngine;
using System.Collections;

public class collide : MonoBehaviour {
	//public GameObject parentGameObject;
	public GameObject InventoryGO;
	private Index indexScript;
	private Inventory inventoryScript;
	GUIText tipp;
	GameObject eisblock;
	string meldung;
	bool showmeldung = false;
	public GUISkin skin;

	// Use this for initialization
	void Start () {
		inventoryScript = InventoryGO.GetComponent<Inventory> ();
		tipp = GameObject.Find("Tipp2").guiText;
		eisblock = GameObject.Find ("Eisblock");
	}
	void OnGUI() {
		if (showmeldung) {
			GUI.Box (new Rect (300, 20, 300, 100), meldung, skin.GetStyle ("Slot"));
		}
	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter (Collider other) {
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Item") {
			if (Input.GetKey (KeyCode.E)) {
				inventoryScript.use = false;
				other.gameObject.SetActive (false);
				other.gameObject.GetComponent<ItemBounce>().enabled = false;
				indexScript = other.gameObject.GetComponent<Index> ();
				inventoryScript.AddItem (indexScript.index);
				tipp.text = "";
			}
			if (other.gameObject.activeSelf) {
				tipp.text = "Drücke E um das Objekt aufzusammeln.";
			}
		}
		if (other.gameObject == eisblock) {
			meldung = "Mein Baby! Ich muss einen Weg\n\nfinden um es zu befreien.";
			showmeldung = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		tipp.text = "";
	}
}

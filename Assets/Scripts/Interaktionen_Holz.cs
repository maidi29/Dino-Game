using UnityEngine;
using System.Collections;

public class Interaktionen_Holz : MonoBehaviour {

	GameObject eisblock;
	GameObject feuerzeug;
	string meldung;
	bool showmeldung = false;
	public ItemDatabase database;
	public GUISkin skin;

	// Use this for initialization
	void Start () {
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
		eisblock = GameObject.Find ("Eisblock");
		feuerzeug = GameObject.Find ("Feuerzeug");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI() {
		if (showmeldung) {
			GUI.Box (new Rect (300, 20, 300, 100), meldung, skin.GetStyle ("Slot"));
		}
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject == eisblock) {
			meldung = "Das nützt nichts.";
			if (database.items[1].itemHeat == 800) {
				meldung = "Achtung! Ich könnte mein Baby\n\nmit dem offenen Feuer verletzen.";
			}
			showmeldung = true;
		}
		if (collider.gameObject == feuerzeug && audio.isPlaying == false) {
			audio.Play ();
		}
	}

	void OnTriggerExit (Collider collider) {
		showmeldung = false;
		meldung = "";
	}
}
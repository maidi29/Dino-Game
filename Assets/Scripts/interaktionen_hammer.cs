using UnityEngine;
using System.Collections;

public class interaktionen_hammer : MonoBehaviour {

	public ItemDatabase database;
	public GUISkin skin;

	GameObject holz;
	GameObject kessel;
	GameObject fön;
	GameObject feuerzeug;
	GameObject eimer;
	GameObject eisblock;


	string meldung;
	bool showmeldung = false;


	// Use this for initialization
	void Start () {
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
		holz = GameObject.Find ("Holz");
		kessel = GameObject.Find ("Kessel");
		fön = GameObject.Find ("Fön");
		feuerzeug = GameObject.Find ("Feuerzeug");
		eimer = GameObject.Find ("Eimer");
		eisblock = GameObject.Find ("Eisblock");
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

		if (collider.gameObject == holz) {
			meldung = "Das nützt nichts.";
			showmeldung = true;
		}
		if (collider.gameObject == kessel) {
			meldung = "Das nützt nichts.";
			showmeldung = true;
		}
			if (collider.gameObject == fön) {
			meldung = "Das nützt nichts.";
			showmeldung = true;
		}
		if (collider.gameObject == feuerzeug) {
			meldung = "Das nützt nichts.";
			showmeldung = true;
		}
		if (collider.gameObject == eimer) {
			meldung = "Das nützt nichts";
			showmeldung = true;
		}
		if (collider.gameObject == eisblock) {
			meldung = "Das ist zu gefährlich für das Baby!";
			showmeldung = true;
		}
	}

	void OnTriggerExit (Collider collider) {
		showmeldung = false;
		meldung = "";
	}
}
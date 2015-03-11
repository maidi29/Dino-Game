using UnityEngine;
using System.Collections;

public class Interaktionen_Feuerzeug : MonoBehaviour {

	public ItemDatabase database;
	public GUISkin skin;

	GameObject holz;
	GameObject kessel;
	GameObject hammer;
	GameObject fön;
	GameObject eimer;
	GameObject eisblock;

	Animator animator;

	string meldung;
	bool showmeldung = false;

	public ParticleSystem feuer;
	public ParticleSystem rauch;
	public ParticleSystem wasserkessel;
	
	void Start () {
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
		holz = GameObject.Find ("Holz");
		kessel = GameObject.Find ("Kessel");
		hammer = GameObject.Find ("Hammer");
		fön = GameObject.Find ("Fön");
		eimer = GameObject.Find ("Eimer");
		eisblock = GameObject.Find ("Eisblock");

		feuer.enableEmission = false;
		rauch.enableEmission = false;

		animator = eimer.GetComponent<Animator> ();

	}

	void Update () {
	}

	void OnGUI() {
		if (showmeldung) {
			GUI.Box (new Rect (300, 20, 300, 100), meldung, skin.GetStyle ("Slot"));
		}
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject == holz) {
			feuer.enableEmission = true;
			rauch.enableEmission = true;
			database.items[1].itemHeat = 800;
			meldung = "Juhu, das Holz brennt!";
			showmeldung = true;
		}
		if (collider.gameObject == kessel) {
			meldung = "Das nützt nichts.";
			if (wasserkessel.enableEmission==true) {
				meldung = "Das Wasser wird zu langsam warm.\n\nIch brauche ein größeres Feuer.";
			}
			showmeldung = true;
		}
		if (collider.gameObject == hammer) {
			meldung = "Das nützt nichts.";
			showmeldung = true;
		}
		if (collider.gameObject == fön) {
			meldung = "Das nützt nichts.";
			showmeldung = true;
		}
		if (collider.gameObject == eimer) {
			meldung = "Der Eimer schmilzt!";
			showmeldung = true;
			animator.SetTrigger("Melt");
			Destroy(collider.gameObject, 5f);
		}
		if (collider.gameObject == eisblock) {
			meldung = "Das Eis schmilzt zu langsam,\n\nich muss einen anderen Weg finden!";
			showmeldung = true;
		}
	}

	void OnTriggerExit (Collider collider) {
		showmeldung = false;
		meldung = "";
	}
}

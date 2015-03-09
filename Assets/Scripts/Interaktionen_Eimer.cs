using UnityEngine;
using System.Collections;

public class Interaktionen_Eimer: MonoBehaviour {
	
	public ItemDatabase database;
	public GUISkin skin;
	

	GameObject hammer;
	GameObject fön;
	GameObject eisblock;
	GameObject see;
	GameObject kessel;
	GameObject holz;
	
	Animator animator;
	
	string meldung;
	bool showmeldung = false;
	
	public ParticleSystem wasser;
	public ParticleSystem wasser2;
	
	
	void Start () {
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
		hammer = GameObject.Find ("Hammer");
		fön = GameObject.Find ("Fön");
		kessel = GameObject.Find ("Kessel");
		holz = GameObject.Find ("Holz");
		eisblock = GameObject.Find ("Eisblock");
		see = GameObject.Find ("Daylight Water");

		animator = gameObject.GetComponent<Animator> ();
		wasser.enableEmission = false;
		wasser2.enableEmission = false;

		
	}
	
	void Update () {
	}
	
	void OnGUI() {
		if (showmeldung) {
			GUI.Box (new Rect (300, 20, 300, 100), meldung, skin.GetStyle ("Slot"));
		}
	}
	
	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject == see) {
			wasser2.enableEmission = true;
			meldung = "Du hast erfolgreich \n\nWasser geschöpft.";
			showmeldung = true;
		}
		
		if ((collider.gameObject == kessel)&(wasser2.enableEmission==true)) {
		
			wasser.enableEmission = true;
			meldung = "Das Wasser aus dem Eimer \n\nist jetzt im Kessel.";
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

		if (collider.gameObject == holz) {
			if(database.items[1].itemHeat == 800) {
				meldung = "Der Eimer schmilzt!";
				animator.SetTrigger("Melt");
				Destroy(gameObject, 5f);
			}
			else {
				meldung = "Das nützt nichts.";
			}
			showmeldung = true;
		}
			
		if (collider.gameObject == eisblock) {
			meldung = "Das nützt nichts.";
			showmeldung = true;
		}
	}
	
	void OnTriggerExit (Collider collider) {
		showmeldung = false;
		meldung = "";
	}
}

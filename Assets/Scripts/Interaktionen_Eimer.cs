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
		eisblock = GameObject.Find ("Eisblock");
		see = GameObject.Find ("Daylight Water");

		
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
		}
		
		if ((collider.gameObject == kessel)&(wasser2.enableEmission==true)) {
		
			wasser.enableEmission = true;
		}
		
		if (collider.gameObject == hammer) {
			meldung = "Das nützt nichts.";
			showmeldung = true;
		}
		if (collider.gameObject == fön) {
			meldung = "Das nützt nichts.";
			showmeldung = true;
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

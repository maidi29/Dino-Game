﻿using UnityEngine;
using System.Collections;

public class Interaktionen_Kessel : MonoBehaviour {
	
	public ItemDatabase database;
	public GUISkin skin;
	
	GameObject holz;
	GameObject hammer;
	GameObject fön;
	GameObject eimer;
	GameObject eisblock;
	GameObject see;
	
	Animator animator;
	
	string meldung;
	bool showmeldung = false;
	
	public ParticleSystem wasser;
	public ParticleSystem rauch2;

	
	void Start () {
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
		hammer = GameObject.Find ("Hammer");
		fön = GameObject.Find ("Fön");
		eimer = GameObject.Find ("Eimer");
		eisblock = GameObject.Find ("Eisblock");
		see = GameObject.Find ("Daylight Water");
		holz = GameObject.Find ("Holz");
		
		wasser.enableEmission = false;
		rauch2.enableEmission = false;

		
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
		if (collider.gameObject == see) {
						wasser.enableEmission = true;
				}
										
		if ((collider.gameObject == holz)&(database.items [1].itemHeat == 800)&(wasser.enableEmission==true)) {
						database.items [6].itemHeat = 800;
						rauch2.enableEmission = true;
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
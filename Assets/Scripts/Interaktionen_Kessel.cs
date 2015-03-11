using UnityEngine;
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
	

	Animator anim2;
	
	string meldung;
	bool showmeldung = false;
	bool ende = false; 
	public float cooldown;
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

		anim2 = eisblock.GetComponent <Animator> ();
		cooldown = 13f;
	
		
	}
	
	void FixedUpdate () {
		if (ende == true) {
			cooldown -= Time.deltaTime;
			if (cooldown <= 0) {
				Application.LoadLevel("Ende");
			}
		}
	}

	

	
	void OnGUI() {
		if (showmeldung) {
			GUI.Box (new Rect (300, 20, 300, 100), meldung, skin.GetStyle ("Slot"));
		}
	}
	
	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject == see) {
			wasser.enableEmission = true;
			meldung = "Super, du hast \n\nerfolgreich Wasser geschöpft!";
			showmeldung = true;
				}
										
		if (collider.gameObject == holz){
			meldung = "Das nützt nichts.";
			if (database.items [1].itemHeat == 800) {
				meldung = "Der Kessel wird heiß.";
				if(wasser.enableEmission==true) {
					database.items [6].itemHeat = 800;
					rauch2.enableEmission = true;
					meldung = "Sehr gut, \n\ndas Wasser ist jetzt heiß.";
				}
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

		
		if (collider.gameObject == eisblock) {
			if (database.items [6].itemHeat == 800) {
				anim2.SetTrigger("schmelzen");
				meldung = "Super, das Eis schmilzt!\n\nSo kann ich mein Baby befreien!";
				ende = true;
			}
			else {
			meldung = "Das nützt nichts.";
			}

			showmeldung = true;
		}

	}
	
	void OnTriggerExit (Collider collider) {
		showmeldung = false;
		meldung = "";
	}
}

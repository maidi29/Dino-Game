using UnityEngine;
using System.Collections;

public class Interaktionen_Feuerzeug : MonoBehaviour {
	public ParticleSystem feuer;
	public ParticleSystem rauch;
	public GameObject inventoryGO;
	public GUISkin skin;
	GameObject holz;
	private Inventory inventoryScript;
	public ItemDatabase database;
	float dist;
	GameObject target;
	// Use this for initialization
	void Start () {
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
		inventoryScript = inventoryGO.GetComponent<Inventory> ();
		holz = GameObject.Find ("Holz");
		feuer.enableEmission = false;
		rauch.enableEmission = false;

	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] items = GameObject.FindGameObjectsWithTag ("Item");
		foreach(GameObject target in items) {
				dist = Vector3.Distance(target.transform.position, transform.position);
				print (dist);

		}
		if (dist <= 1 && gameObject.activeInHierarchy) {
			for(int j = 0; j < database.items.Count; j++){
				if (database.items[j].itemID == 1) {
					if(holz.activeInHierarchy) {
						print ("Angezündet");
						feuer.enableEmission = true;
						rauch.enableEmission = true;
						database.items[1].itemHeat = 800;
					}
				}
				if (database.items[j].itemID == 3) {
					print ("do something");
					//Rect meldung = new Rect (500, 200, 300, 60);
					//GUI.Box (meldung, "Der Hammer wird heiß, aber wozu soll das gut sein?", skin.GetStyle("Slot"));
				}
			}
		}
	}
}

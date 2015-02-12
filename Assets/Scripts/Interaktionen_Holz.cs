using UnityEngine;
using System.Collections;

public class Interaktionen_Holz : MonoBehaviour {
	//GameObject feuerzeug;
	public ParticleSystem feuer;
	public ParticleSystem rauch;
	public GameObject inventoryGO;
	GameObject feuerzeug;
	private Inventory inventoryScript;
	public ItemDatabase database;
	Animator animator;
	public Transform other;
	float dist;

	// Use this for initialization
	void Start () {
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
		inventoryScript = inventoryGO.GetComponent<Inventory> ();
		feuerzeug = GameObject.Find ("Feuerzeug");
		feuer.enableEmission = false;
		rauch.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (other) {
			dist = Vector3.Distance(other.position, transform.position);
		}
		if (dist <= 0.8) {
			if (other.gameObject == feuerzeug) {
			//if (other.gameObject.tag = Item && database.items[j].itemHeat >= 800) {
				feuer.enableEmission = true;
				rauch.enableEmission = true;
			}
		}
	}

	/*void OnCollisionEnter (Collision col) {
		if (col.gameObject.name == "Feuerzeug") {
			Debug.Log("Angezündet");
			//if (inventoryScript.holz.activeInHierarchy) {
				feuer.enableEmission = true;
				rauch.enableEmission = true;
			//}
		}
	}*/
}
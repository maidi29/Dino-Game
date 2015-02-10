using UnityEngine;
using System.Collections;

public class Interaktionen_Holz : MonoBehaviour {
	//GameObject feuerzeug;
	public ParticleSystem feuer;
	public ParticleSystem rauch;
	public GameObject inventoryGO;
	private Inventory inventoryScript;
	Animator animator;

	// Use this for initialization
	void Start () {
		inventoryScript = inventoryGO.GetComponent<Inventory> ();
		//feuerzeug = GameObject.Find ("Feuerzeug");
		feuer.enableEmission = false;
		rauch.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.name == "Feuerzeug") {
			Debug.Log("Angezündet");
			//if (inventoryScript.holz.activeInHierarchy) {
				feuer.enableEmission = true;
				rauch.enableEmission = true;
			//}
		}
	}
}
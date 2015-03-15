using UnityEngine;
using System.Collections;

public class walkingwatersound : MonoBehaviour {

	GameObject dino;
	bool dinocol;

	// Use this for initialization
	void Start () {

		dino = GameObject.Find ("Dino");
		dinocol = false;

	
	}
	
	// Update is called once per frame
	void Update () {
		if (dinocol == true)
			audio.Play ();
	
	}
	void OnTrigger (Collider collid)
	{
		if (collid.gameObject == dino)
		{
			dinocol = true;
 }
}
}
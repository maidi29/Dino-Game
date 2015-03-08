using UnityEngine;
using System.Collections;

public class schmelzen : MonoBehaviour {

	

	GameObject eisblock;
	GameObject Kessel;
	bool animationSwitch = false;


	// Use this for initialization
	void Start () {
		Kessel = GameObject.Find ("Kessel");
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider collider) {

		if (collider.gameObject == Kessel) {
			animationSwitch = true;
			eisblock.animation.CrossFade ("schmelzen");
				} 
	}
}

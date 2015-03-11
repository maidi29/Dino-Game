using UnityEngine;
using System.Collections;

public class Entführung : MonoBehaviour {

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("escape")){
			Application.Quit ();
		}
	}
	
	void OnMouseDown () {
		Application.LoadLevel ("Start");
	}
}

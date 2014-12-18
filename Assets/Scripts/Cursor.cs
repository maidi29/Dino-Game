using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour

{
	   bool isLocked;


		// Use this for initialization
		void Start ()
		{
		  SetCursorLock (true);
	
		}
	void SetCursorLock(bool isLocked)
	{
				this.isLocked = isLocked;
				Screen.lockCursor = isLocked;
				Screen.showCursor = !isLocked;

		}
	
		// Update is called once per frame
		void Update ()
		{
		if (Input.GetKey (KeyCode.I))
						SetCursorLock (!isLocked);
	
		}
}


using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ItemBounce : MonoBehaviour {
	bool goDown = true;
	bool goUp;
	float speed = 0.02f;
	public float minPosition;
	public float maxPosition;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (goDown == true)
		{
			transform.Translate (Vector3.down * speed);
			if(transform.position.y <= minPosition)
			{
				goDown = false;
				goUp = true;
			}
		}
		if (goUp == true)
		{
			transform.Translate (Vector3.up * speed);
			if(transform.position.y >= maxPosition)
			{
				goUp = false;
				goDown = true;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class UnitPlayer : Unit
{
	float cameraRotX = 0f;
	
	public float cameraPitchMax = 45f;

	Animator anim;
	
	// Use this for initialization
	public override void Start ()
	{
		base.Start ();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public override void Update ()
	{
		anim.SetFloat ("Speed", 0f);

		// rotation

		transform.Rotate (0f, Input.GetAxis ("Mouse X") * turnSpeed * Time.deltaTime, 0f);
		
		cameraRotX -= Input.GetAxis ("Mouse Y");
		
		cameraRotX = Mathf.Clamp (cameraRotX, -cameraPitchMax, cameraPitchMax);
		
		Camera.main.transform.forward = transform.forward;
		Camera.main.transform.Rotate (cameraRotX, 0f, 0f);
		
		// movement
		
		move = new Vector3(Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));
		
		move.Normalize();
		
		move = transform.TransformDirection (move);

		walk = Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow);
		if (walk) {
						anim.SetFloat ("Speed", walkSpeed);
				}

		if (Input.GetKey(KeyCode.Space) && control.isGrounded)
		{
			jump = true;
			anim.SetTrigger("Jump");
		}
		
		running = Input.GetKey (KeyCode.LeftShift)  || Input.GetKey (KeyCode.RightShift);

		if (running) {
						anim.SetFloat ("Speed", runSpeed);
				}
		grab = Input.GetKey (KeyCode.E);
		if (grab) {
						anim.SetTrigger ("Grab");
				}
		base.Update ();
	}
}

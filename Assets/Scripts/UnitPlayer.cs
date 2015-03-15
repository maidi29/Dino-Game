using UnityEngine;
using System.Collections;

public class UnitPlayer : Unit
{
	float cameraRotX = 0f;
	
	public float cameraPitchMax = 45f;

	public AudioSource footstep;
	public AudioSource waterfootstep;
	bool inwater = false;

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
		if(inwater) {
			footstep.mute = true;
		}

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
		if (walk == true && footstep.isPlaying ==false) {
			anim.SetFloat ("Speed", walkSpeed);
			footstep.volume = Random.Range (0.4f,0.6f);
			footstep.pitch = 1f;
			footstep.Play ();
			footstep.mute = false;
		}

		if (Input.GetKey(KeyCode.Space) && control.isGrounded)
		{
			jump = true;
			anim.SetTrigger("Jump");
			footstep.mute = true;
			waterfootstep.mute = true;
		}
		
		running = Input.GetKey (KeyCode.LeftShift)  || Input.GetKey (KeyCode.RightShift);

		if (running) {
			anim.SetFloat ("Speed", runSpeed);
			footstep.pitch = 1.5f;
			waterfootstep.pitch = 1.5f;
				}
		grab = Input.GetKey (KeyCode.E);
		if (grab) {
						anim.SetTrigger ("Grab");
				}
		base.Update ();
	}
	void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "Water") {
			if (walk == true && waterfootstep.isPlaying ==false) {
				inwater = true;
				waterfootstep.volume = Random.Range (0.4f,0.6f);
				waterfootstep.pitch = 1f;
				waterfootstep.mute = false;
				waterfootstep.Play ();
			}
		}
	}
}

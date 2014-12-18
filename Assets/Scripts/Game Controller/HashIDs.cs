using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {
	public int locomotionState;
	public int grabState;
	public int jumpState;
	public int speedFloat;

	void Awake()
	{
		locomotionState = Animator.StringToHash ("Base Layer.Locomotion");
		grabState = Animator.StringToHash ("Base Layer.Grab");
		jumpState = Animator.StringToHash ("Base Layer.Jump");
		speedFloat = Animator.StringToHash ("Speed");
	}

}

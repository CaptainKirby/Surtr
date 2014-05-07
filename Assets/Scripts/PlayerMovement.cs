﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[HideInInspector]
	public bool activeMovement = true;
	private CharacterMotor motor;
	public float pushPower = 2.0f;
	public float weight = 6.0f;

	public bool movingRight;
	public bool movingLeft;
	public bool idle;
	private bool movedRight;
	private bool movedLeft;

	private bool sprinting;
	public float sprintSpeed = 5;
	private float sprintValue= 1;
	public Transform charGfx;
	private Animator charAnim;
	public bool spiritActive;
	public bool jumping;
	public bool inSpirit;
	private FloatChar floatC;
	void Start () 
	{
		floatC = GetComponent<FloatChar>();
		charAnim = GetComponentInChildren<Animator>(); 
		charGfx = transform.GetChild(0);
		activeMovement = true;
		motor = GetComponent<CharacterMotor>();

	}
	

	void Update () 
	{

		charAnim.SetBool("walkRight", movingRight);
		charAnim.SetBool("walkLeft", movingLeft);
		charAnim.SetBool("idle", idle);
		charAnim.SetBool ("jumping", jumping);
		charAnim.SetBool ("inSpirit", inSpirit);
//		Debug.Log (Input.GetAxis("RTrigger"));
		if(Input.GetAxis("RTrigger") > 0.8f && !sprinting)
		{
			sprinting = true;
			sprintValue = sprintSpeed;
		}
		if(Input.GetAxis("RTrigger") < 0.8f && sprinting)
		{
			sprinting = false;
			sprintValue = 1;
		}
		// til hoppet skal jeg finde input dir retning(venstre el. højre).
		// i meget kort tid skal jeg checke om hop knappen er hold inde i kort eller længere tid for at finde ud af hvor langt hopet skal være(ddete skal ske undervejs i hoppet)
		// der skal være en smule styring iblandet kraften fra hoppet

//		Debug.Log (motor.movement.velocity.x);
//		if(motor.movement.velocity.x > 0.1f && !movingRight)
//		{
//
//			movingRight = true;
//			movingLeft = false;
//			idle = false;
//
//		}
//		if(motor.movement.velocity.x < -0.1f && !movingLeft)
//		{
//			movingLeft = true;
//			movingRight = false;
//			idle = false;
//		}
//
//		if(motor.movement.velocity.x > -0.1f && motor.movement.velocity.x < 0.1f && !idle)
//		{
//			idle = true;
//			movingLeft = false;
//			movingRight = false;
//		}
		if(!inSpirit)
		{
		if(activeMovement && !floatC.floating)
		{
		if(Input.GetAxis("Horizontal") > 0.1f && !movingRight)
		{
			charGfx.eulerAngles = new Vector3(0,90,0);
			movingRight = true;
			movingLeft = false;
			idle = false;
			movedRight = true;
			movedLeft = true;
			
		}

		if(Input.GetAxis("Horizontal") < -0.1f && !movingLeft)
		{
			charGfx.eulerAngles = new Vector3(0,-90,0);

			movingLeft = true;
			movingRight = false;
			idle = false;
			movedRight = false;
			movedLeft = true;
		}
		
		if(Input.GetAxis("Horizontal") > -0.1f && Input.GetAxis("Horizontal") < 0.1f && !idle)
		{
			idle = true;
			movingLeft = false;
			movingRight = false;

		}

			motor.inputMoveDirection = Vector3.right * Input.GetAxis("Horizontal") * sprintValue;
			motor.inputJump = Input.GetKey(KeyCode.JoystickButton0);
			}

			if(motor.jumping.jumping)
			{
				jumping = true;
			}
			else
			{
				jumping = false;
			}

		}
		else
		{
			motor.inputMoveDirection = Vector3.zero;
		}



	}

//	void OnControllerColliderHit (ControllerColliderHit hit)
//	{
//		Rigidbody body = hit.collider.attachedRigidbody;
//		
//		Vector3 force = Vector3.zero;
//		
//		// no rigidbody
//		if (body == null || body.isKinematic) { return; }
//		
//		// We use gravity and weight to push things down, we use
//		// our velocity and push power to push things other directions
////		if (hit.moveDirection.y > -0.3f) {
//////			force = new Vector3 (0, -0.5f, 0) * motor.movement.gravity * weight;
////		} else {
////			force = hit.controller.velocity * pushPower - body.velocity;
////		}
//		
//		// Apply the push
////		body.AddForceAtPosition(force, hit.point);
////		if (hit.moveDirection.y < -1.0F){
////			Debug.Log ("return");
////			return;
//
////		Debug.Log (hit.point.y);
////		if(!motor.grounded)
////			return;
////		}
//		if (Vector3.Dot(this.transform.position - hit.transform.position, hit.transform.up) > 0.5f) {
//
//			return;
////			return true; // object B is above object A
//			
//		}
//		else{
//
//
//		Vector3 pushDir = motor.movement.velocity;
////		Vector3 pushDir = new Vector3(hit.moveDirection.x, hit.moveDirection.y, hit.moveDirection.z);
//		body.velocity =  new Vector3(pushDir.x * pushPower, 0, body.velocity.z);
//		}
//	}
//
	void LateUpdate()
	{
		transform.position = new Vector3(transform.position.x, transform.position.y, 0 );
	}
	
}





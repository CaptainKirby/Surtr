﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (ActionHandler))]

public class FloatChar : MonoBehaviour {
	public Animator anim;
	private Transform charGfx;
	private CharacterMotor pMotor;
	private PlayerMovement pMove;
	private ActionHandler actionHandler;
	private PlayerSwitch pSwitch;
	private Transform spirit;
	public bool floating;
	private bool on;

	public bool turnOnFloat;
	public bool turnOffFloat;
	private float startFallspeed;
	public Vignetting vig;
	void Start () 
	{
		vig = Camera.main.GetComponent<Vignetting>();
		spirit = Transform.FindObjectOfType<SpiritMovement>().gameObject.transform;

		anim = GetComponentInChildren<Animator>();
		charGfx = anim.gameObject.transform;
		pMotor = GetComponent<CharacterMotor>();
		pMove = GetComponent<PlayerMovement>();
		startFallspeed = pMotor.movement.maxFallSpeed;
		pSwitch = GetComponent<PlayerSwitch>();
		actionHandler =  GetComponent<ActionHandler>();
		if(actionHandler)
		{
			actionHandler.TakeAction += Floater;
		}
	}
	
	void Update () 
	{
		anim.SetBool("floating", floating);
	}

	void Floater(GameObject gObj, bool stop)
	{
		if(!on)
		{			
			on = true;

			StartCoroutine(FloatCR());


		}
	}

	IEnumerator FloatCR()
	{

		if(turnOnFloat)
		{
		yield return new WaitForSeconds(1.3f);

			floating = true;
			pMotor.movement.maxFallSpeed = 0.2f;
			charGfx.eulerAngles = new Vector3(0, 180,0);
//			pMove.activeMovement = false;
			turnOnFloat =false;
			turnOffFloat = true;
			on = false;
			vig.enabled = true;
		}
		else
		{

			floating = false;
			pMotor.movement.maxFallSpeed = startFallspeed;
			charGfx.eulerAngles = new Vector3(0, 90,0);
			turnOnFloat = false;
			turnOffFloat = false;
			transform.position = new Vector3(spirit.position.x, spirit.position.y +0.2f, spirit.position.z);
			pSwitch.curState = !pSwitch.curState;
			vig.enabled = false;

		}
	}
}
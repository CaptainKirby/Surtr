﻿using UnityEngine;
using System.Collections;

public class PlayerSwitch : MonoBehaviour {

	public GameObject playerObj;
	public GameObject spiritObj;
	public bool switchFreely;
	private CharacterController playerController;
	private PlayerMovement playerMove;
	private Vector3 playerVelocity;

	private SpiritMovement spiritMove;
	private Vector3 spiritVelocity;

	public KeyCode switchKey= KeyCode.JoystickButton3;
	[HideInInspector]
	public bool curState; //false = player true = spirit
	[HideInInspector]
	public static bool fadeFromForm;

//	public delegate void FadeFromFormDelegate();
//	public event FadeFromFormDelegate FadeFromForm;
	private Vector3 curVel;

	private int dir = -1; //-1 == left 1 == right
	void Start () 
	{
		playerController = playerObj.GetComponent<CharacterController>();
		playerVelocity = playerController.velocity;
		playerMove = playerObj.GetComponent<PlayerMovement>();

		spiritMove = spiritObj.GetComponent<SpiritMovement>();
		spiritMove.activeMovement = false;
		spiritObj.renderer.enabled = false;
		spiritObj.collider.enabled = false;
		dir = -1;
	}
	

	void Update () 
	{
		if(Input.GetAxis("Horizontal") >0.2f)
		{
			dir = 1;
		}
		if(Input.GetAxis("Horizontal") <-0.2f)
		{
			dir = -1;
		}

//		Debug.Log(dir);
		if(!curState)
		{
			//player is shown and moved
			if(spiritMove.activeMovement)
			{
				spiritObj.collider.enabled = false;
				spiritMove.activeMovement = false;
				playerMove.activeMovement = true;
				spiritObj.renderer.enabled = false; // skal være fade ud
			}

//			spiritObj.transform.position = Vector3.SmoothDamp(spiritObj.transform.position, playerObj.transform.position, ref curVel, Time.deltaTime * 5f);
			spiritObj.transform.position = playerObj.transform.position;
		}

		if(curState && playerMove.activeMovement)
		{
			//spirit is shown and moved
			playerMove.activeMovement = false;
			spiritMove.activeMovement = true;
			spiritObj.renderer.enabled = true;
			spiritObj.collider.enabled = true;
			spiritMove.rigidbody.AddForce(new Vector3(dir,0,0) * Mathf.Clamp(playerVelocity.magnitude, 0.3f, 10f) * 2,ForceMode.Impulse);


		}




		if(Input.GetKeyDown(switchKey))
		{
//			Debug.Log ("wat22222");
			curState = !curState;
//			StartCoroutine(ClickOnce());
			fadeFromForm = true;
//			curState = true;
//			fadeFromForm = !fadeFromForm;
		}
		else if(switchFreely && Input.GetKeyDown(KeyCode.JoystickButton2) && spiritMove.grounded)
		{
			playerObj.transform.position = new Vector3(spiritObj.transform.position.x, spiritObj.transform.position.y +0.2f, spiritObj.transform.position.z);
			curState = !curState;
			fadeFromForm = true;

		}
		else
		{
////			Debug.Log (fadeFromForm);
			fadeFromForm = false;
//
		}
//		if(fadeFromForm)
//		{
//			fadeFromForm = false;
//		}
//		if(Input.GetKeyDown(switchKey) && curState && !fadeFromForm)
//		{
//			curState = false;
//			fadeFromForm = !fadeFromForm;
//		}
//		if(fadeFromForm)
//		{
//			fadeFromForm = false;
//		}
//		if(Input.GetKeyUp(switchKey))
//		{
//			fadeFromForm = false;
//		}

//		Debug.Log (fadeFromForm);
		playerVelocity = playerController.velocity;
//		Debug.Log (playerVelocity.x);

	}

	// spirit skal kunne 1. fade ud.
	// 1. player skal kunne komme hen til spirit.

	IEnumerator SpiritFadeout()
	{
		yield return null;
	}

//	void ChangeState()
//	{
//		curState = !curState;
//	}
//	IEnumerator ClickOnce()
//	{
//		curState = !curState;
//		fadeFromForm = !fadeFromForm;
//		yield return new WaitForEndOfFrame();
//		fadeFromForm = !fadeFromForm;
//	}

}

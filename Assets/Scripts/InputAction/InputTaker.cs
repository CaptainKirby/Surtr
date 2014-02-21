﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputTaker : MonoBehaviour {
	public enum InputType {clickInput, trigger, pikogpatter}; //ontriggerenter on trigger exit, on collision, keyinput
	public InputType inputType = InputType.clickInput;

	public GameObject attatchedObj;
	public  List<GameObject> attatchedObjs ;
	private ActionDoer actionDo;

	void Start () 
	{
		actionDo = attatchedObj.GetComponent<ActionDoer>();
	}

	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider col)
	{
		if(inputType == InputType.trigger)
		{
			actionDo.DoThing();
		}
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Click"))
		{
//			if(OnClicked != null) 
//				OnClicked(); 
		}
	}

	void OnDrawGizmos()
	{
		if(attatchedObjs.Count > 0)
		{

			foreach(GameObject gObj in attatchedObjs)
			{
				Gizmos.DrawLine(this.transform.position, gObj.transform.position);
//				Gizmos.DrawIcon(this.transform.position /2, "arrowIcon.png");
			}
		}
	}
}
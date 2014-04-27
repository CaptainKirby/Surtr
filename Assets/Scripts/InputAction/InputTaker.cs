using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//[ExecuteInEditMode()]  
[System.Serializable]

public class InputTaker : MonoBehaviour {
	public enum InputType {clickInput, trigger, spiritShift, pressurePlate}; //ontriggerenter on trigger exit, on collision, keyinput
	public InputType inputType = InputType.clickInput;
	public bool causeStop;
	public GameObject attatchedObj;
	public  List<GameObject> attatchedObjs  = new List<GameObject>();
	[SerializeField]
	public List<ActionHandler> actionDoers = new List<ActionHandler>();
	[SerializeField]
	private ActionHandler actionDo;
	private bool oneTime;

	private PlayerSwitch pS;

	private bool inside;

	void Start () 
	{
		pS = GameObject.Find("Player").GetComponent<PlayerSwitch>();
		foreach(GameObject g in attatchedObjs)
		{

			if(g.GetComponent<ActionHandler>())
			{
//				if(actionDoers.Contains(g.GetComponent<ActionHandler>()))
//				{
					actionDoers.Add(g.GetComponent<ActionHandler>());
//				}
			}
		}
//		actionDo = attatchedObj.GetComponent<ActionDoer>();
	}

	void Update () 
	{
		if(inside)
		{
			if(inputType == InputType.clickInput)
			{
				if(Input.GetKeyDown(KeyCode.JoystickButton2))
				{
					foreach(ActionHandler aD in actionDoers)
					{
						if(causeStop)
						{
							aD.DoThing(aD.gameObject, true);
						}
						else
						{
						aD.DoThing(aD.gameObject, false);
						}
					}
				}
			}
		}
//		if(pS.fadeFromForm)
//		{
//			Debug.Log ("HNUIGBEI");
//		}
		if(inputType == InputType.spiritShift)
		{
			if(PlayerSwitch.fadeFromForm)
			{
				Debug.Log ("!?!");
				oneTime = true;
				foreach(ActionHandler aD in actionDoers)
				{
					if(causeStop)
					{
						aD.DoThing(aD.gameObject, true);
					}
					else
					{
						aD.DoThing(aD.gameObject, false);
					}

				}
			}



		}
	}

	void ControllerColliderHit(Collider col)
	{
		if(inputType == InputType.trigger)
		{
			foreach(ActionHandler aD in actionDoers)
			{
				if(causeStop)
				{
					aD.DoThing(col.gameObject, true);
				}
				else
				{
					aD.DoThing(col.gameObject, false);
				}
//				if(aD.callFunction)
//				{
//					aD.collidingObject = col.gameObject;
//					//					aD.Invoke(aD.dynFunctionName, 0);
//				}
			}
			//			actionDo.DoThing();
		}
		
		if(inputType == InputType.clickInput)
		{
			inside = true;
		}
	}

	void OnTriggerEnter(Collider col)
	{
//		Debug.Log (actionDoers.Count);
		if(inputType == InputType.pressurePlate)
		{
				foreach(ActionHandler aD in actionDoers)
				{
	//				Debug.Log (aD.gameObject);

				if(causeStop)
				{
					aD.DoThing(col.gameObject, true);
				}
				else
				{
					aD.DoThing(col.gameObject, false);
				}
				}
		}

		if(inputType == InputType.trigger)
		{
			foreach(ActionHandler aD in actionDoers)
			{
				if(causeStop)
				{
					aD.DoThing(col.gameObject, true);
				}
				else
				{
					aD.DoThing(col.gameObject, false);
				}
//				if(aD.callFunction)
//				{
//					aD.collidingObject = col.gameObject;
////					aD.Invoke(aD.dynFunctionName, 0);
//				}
			}
//			actionDo.DoThing();
		}
//		
		if(inputType == InputType.clickInput)
		{
			inside = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(inputType == InputType.clickInput)
		{
			inside = false;
		}
		if(inputType == InputType.pressurePlate)
		{
//			if(!col.CompareTag("Spirit"))
//			{
				foreach(ActionHandler aD in actionDoers)
				{
				if(causeStop)
				{
					aD.DoThing(col.gameObject, true);
				}
				else
				{
					aD.DoThing(col.gameObject, false);
				}
				}
//			}
		}
	}
//
//	void OnGUI()
//	{
//		if(GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Click"))
//		{
////			if(OnClicked != null) 
////				OnClicked(); 
//		}
//	}

	void OnDrawGizmos()
	{
		if(attatchedObjs.Count > 0)
		{

			foreach(GameObject gObj in attatchedObjs)
			{
				Gizmos.DrawLine(this.transform.position, gObj.transform.position);
//				Gizmos.DrawLine((this.transform.position + gObj.transform.position) * 0.5f, new Vector3((this.transform.position.x + gObj.transform.position.x) * 0.5f , (this.transform.position.y + gObj.transform.position.y) * 0.5f, (this.transform.position.z + gObj.transform.position.z) * 0.5f));
//				Gizmos.DrawIcon(this.transform.position /2, "arrowIcon.png");
			}
		}
	}
                
		                 
 }
   
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//[ExecuteInEditMode()]  
[System.Serializable]

public class InputTaker : MonoBehaviour {
	public enum InputType {clickInput, trigger, pikogpatter}; //ontriggerenter on trigger exit, on collision, keyinput
	public InputType inputType = InputType.clickInput;

	public GameObject attatchedObj;
	public  List<GameObject> attatchedObjs  = new List<GameObject>();
	[SerializeField]
	public List<ActionDoer> actionDoers = new List<ActionDoer>();
	[SerializeField]
	private ActionDoer actionDo;


	void Start () 
	{
		foreach(GameObject g in attatchedObjs)
		{
			if(g.GetComponent<ActionDoer>())
			{
				 actionDoers.Add(g.GetComponent<ActionDoer>());
			}
		}
//		actionDo = attatchedObj.GetComponent<ActionDoer>();
	}

	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider col)
	{
		if(inputType == InputType.trigger)
		{
			foreach(ActionDoer aD in actionDoers)
			{
				aD.DoThing();
			}
//			actionDo.DoThing();
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
//				Gizmos.DrawLine((this.transform.position + gObj.transform.position) * 0.5f, new Vector3((this.transform.position.x + gObj.transform.position.x) * 0.5f , (this.transform.position.y + gObj.transform.position.y) * 0.5f, (this.transform.position.z + gObj.transform.position.z) * 0.5f));
//				Gizmos.DrawIcon(this.transform.position /2, "arrowIcon.png");
			}
		}
	}
                
		                 
 }
   
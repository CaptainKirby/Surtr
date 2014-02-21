using UnityEngine;
using System.Collections;

public class InputTaker : MonoBehaviour {
	public enum InputType {clickInput, trigger};
	public InputType inputType = InputType.clickInput;

	public GameObject attatchedObj;
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
}

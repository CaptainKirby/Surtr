using UnityEngine;
using System.Collections;
[RequireComponent (typeof (ActionHandler))]

public class FadeOutAndIn : MonoBehaviour {
	bool faded = false;
	private ActionHandler actionHandler;
	// Use this for initialization
	void Awake () {
		actionHandler =  GetComponent<ActionHandler>();
		if(actionHandler)
		{
			actionHandler.TakeAction += Fade;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void Fade(GameObject gObj, bool stop)
	{
		if(!faded)
		{
			this.renderer.enabled = false;
			faded = true;
		}
		else
		{
			this.renderer.enabled = true;
			faded = false;
		}
	}
}

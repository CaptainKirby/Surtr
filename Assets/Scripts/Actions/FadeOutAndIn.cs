using UnityEngine;
using System.Collections;
[RequireComponent (typeof (ActionHandler))]

public class FadeOutAndIn : MonoBehaviour {
	public bool faded = false;
	private ActionHandler actionHandler;
//	private PlayerSwitch pSwitch;
	// Use this for initialization
	void Awake () {
//		pSwitch = GameObject.Find("Player").GetComponent<PlayerSwitch>();
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
		if(gObj.CompareTag("Player"))
		{
		if(!faded)
		{
			this.GetComponent<Renderer>().enabled = false;
			faded = true;
		}
		else
		{
			this.GetComponent<Renderer>().enabled = true;
			faded = false;
		}
		}
	}
}

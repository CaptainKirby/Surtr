using UnityEngine;
using System.Collections;

public class Stop : MonoBehaviour {

	public float triggerTimesBeforeStop;
	public bool resume;
	public float stopDuration;
	private ActionHandler actionHandler;
	private MonoBehaviour[] allComps;
	void Start () 
	{
		allComps = gameObject.GetComponents<MonoBehaviour>();
		actionHandler =  GetComponent<ActionHandler>();
		if(actionHandler)
		{
			actionHandler.TakeAction += StopCheck;
		}
	}

	void StopCheck(GameObject gObj, bool stop)
	{
		if(stop)
		{
			if(triggerTimesBeforeStop > 0)
			{
				triggerTimesBeforeStop -= 1;

			}
			else
			{
				//STOP
				Debug.Log ("STOP");
				foreach(MonoBehaviour comp in allComps)
				{
					if(comp != this)
					{
						comp.enabled = false;

					}
				}
			}
		}
	}
}

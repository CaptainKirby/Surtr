using UnityEngine;
using System.Collections;

[RequireComponent (typeof (ActionHandler))]


public class EnableGravity : MonoBehaviour {
	private ActionHandler actionHandler;
	private MeshCollider mCol;
	private bool onOff;
	void Start () {
		mCol = GetComponent<MeshCollider>();
		actionHandler =  GetComponent<ActionHandler>();
		if(actionHandler)
		{
			actionHandler.TakeAction += EnableG;
		}
	}
	

	void Update () {
	
	}

	void EnableG(GameObject gObj,bool stop)
	{
		rigidbody.useGravity = true;
		mCol.enabled = false;
		rigidbody.AddTorque(100,100,100);
	}
}

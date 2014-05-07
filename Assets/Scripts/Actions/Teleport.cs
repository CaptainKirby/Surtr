using UnityEngine;
using System.Collections;
[RequireComponent (typeof (ActionHandler))]

public class Teleport : MonoBehaviour {

	private bool teleported;
	private ActionHandler actionHandler;
	public Vector3 teleportTo;
//	public bool axisx;
//	public bool axisY;
//	public bool axisZ;
	void Start () 
	{
		actionHandler =  GetComponent<ActionHandler>();
		if(actionHandler)
		{
			actionHandler.TakeAction += Teleporter;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Teleporter(GameObject gObj, bool stop)
	{
		if(!teleported)
		{
			teleported = true;
			StartCoroutine(TeleportCR());
		}
	}

	IEnumerator TeleportCR()
	{
		yield return new WaitForSeconds(5f);
		transform.position = new Vector3(teleportTo.x, transform.position.y, transform.position.z);

	}
}

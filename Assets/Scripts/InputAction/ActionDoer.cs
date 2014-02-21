using UnityEngine;
using System.Collections;

[System.Serializable]
public class ActionDoer : MonoBehaviour {

	//transform pos, rot, scale, ping-pong, color
	public bool listen;
	public bool listenEnable;
	public bool on;
	[SerializeField]
	public GameObject attatchedObj;

	void Start () 
	{
	
	}


	void Update () 
	{

	}


	void OnDrawGizmos()
	{
		if(attatchedObj != null)
		{
			Gizmos.DrawLine(this.transform.position, attatchedObj.transform.position);
		}
	}

	public void DoThing()
	{

	}
}

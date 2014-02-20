using UnityEngine;
using System.Collections;

[System.Serializable]
public class ActionDoer : MonoBehaviour {
	public bool listen;
	public bool listenEnable;
	public bool on;
	[SerializeField]
	public GameObject attatchedObj;

//	void OnEnable()
//	{
//		InputTaker.OnClicked += On;
//	}
//	
//	
//	void OnDisable()
//	{
//		InputTaker.OnClicked -= On;
//	}

	void Start () 
	{
	
	}


	void Update () 
	{

	}

	public void On()
	{
		if(!on)	on = true;
		else on = false;
	}

	void OnDrawGizmos()
	{
		if(attatchedObj != null)
		{
			Gizmos.DrawLine(this.transform.position, attatchedObj.transform.position);
		}
	}
}

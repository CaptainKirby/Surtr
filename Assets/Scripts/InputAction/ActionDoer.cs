using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ActionDoer : MonoBehaviour {

	//transform pos, rot, scale, ping-pong, color 
	public bool listen;
	public bool listenEnable;
	public bool on;
	[SerializeField]
	public GameObject attatchedObj;
	public List<GameObject> attatchedObjs = new List<GameObject>();

	void Start () 
	{
	
	}


	void Update () 
	{

	}




	public void DoThing()
	{

	}
}

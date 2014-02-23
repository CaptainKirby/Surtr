using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
//[ExecuteInEditMode()]  
public class ActionDoer : MonoBehaviour {
//	[System.Serializable]
	//transform pos, rot, scale, ping-pong, color 
	public bool takeInput = true;

	public bool listen;
	public bool listenEnable;
	public bool on;
	[SerializeField]
	public GameObject attatchedObj;
	[SerializeField]
	public List<GameObject> attatchedObjs = new List<GameObject>();
	private bool doit;
	public bool playOnce;


	//transform move
	[SerializeField]
	public bool transformMove;
	[SerializeField]
	public bool resetMove;
	[SerializeField]
	public Vector3 moveToPos = Vector3.zero;

	void Start () 
	{
	
	}


	void Update () 
	{

	}




	public void DoThing()
	{
		if(!doit)
		{
			doit = true;
//			Debug.Log ("DOINGTHING");
			if(!playOnce)
			{

			}

		}
	}

	IEnumerator TransformPosition()
	{
		yield return null;
	}


	//play on awake(no input required)
	//smooth or lerp
	//start delay
	//transform position, rotation, scale: pingpong, onetime // cranking start and end med animation curves
	//play (child) particle once or loop
	// color fade
}

using UnityEngine;
using System.Collections;

public class StartParticles : MonoBehaviour {

	// Use this for initialization
	private ParticleSystem particleSys;

	private ActionHandler actionHandler;

	void Start () {
		particleSys = GetComponent<ParticleSystem>();

		actionHandler =  GetComponent<ActionHandler>();
		if(actionHandler)
		{
			actionHandler.TakeAction += StartEmission;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void StartEmission(GameObject gObj, bool stop)
	{

	}
}

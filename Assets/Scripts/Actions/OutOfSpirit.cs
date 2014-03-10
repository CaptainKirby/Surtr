using UnityEngine;
using System.Collections;

public class OutOfSpirit : MonoBehaviour {

	private PlayerSwitch playerSwitch;
	void Awake()
	{
		playerSwitch = GameObject.FindObjectOfType<PlayerSwitch>();
		ActionHandler actionHandler =  GetComponent<ActionHandler>();
		actionHandler.TakeAction += OutSpirit;
	}
	void OutSpirit(GameObject gObj, bool stop)
	{
		if(playerSwitch.curState)
		{
			playerSwitch.curState = !playerSwitch.curState;
		}
	}
}

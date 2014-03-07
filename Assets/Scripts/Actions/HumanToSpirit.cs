using UnityEngine;
using System.Collections;

public class HumanToSpirit : MonoBehaviour {

	private PlayerSwitch playerSwitch;
	private Transform player;
	private Transform spirit;
	void Awake()
	{
		playerSwitch = GameObject.FindObjectOfType<PlayerSwitch>();
		ActionHandler actionHandler =  GetComponent<ActionHandler>();
		player = playerSwitch.gameObject.transform;
		spirit = Transform.FindObjectOfType<SpiritMovement>().gameObject.transform;
		actionHandler.TakeAction += ToSpirit;
	}

	void ToSpirit()
	{
		if(playerSwitch.curState)
		{

			player.position = new Vector3(spirit.position.x, spirit.position.y +0.2f, spirit.position.z);
			playerSwitch.curState = !playerSwitch.curState;
		}
	}
}

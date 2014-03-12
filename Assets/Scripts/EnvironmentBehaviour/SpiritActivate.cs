using UnityEngine;
using System.Collections;

public class SpiritActivate : MonoBehaviour {
	private PlayerSwitch playerSwitch;
	public bool disableInSpirit = true;
	public bool disableInHuman = false;
	void Start () 
	{
		playerSwitch = GameObject.FindObjectOfType<PlayerSwitch>();
	}
	

	void Update () {
//	if(PlayerSwitch.fadeFromForm)
//		{
			if(disableInSpirit)
			{
				if(playerSwitch.curState)
				{
					if(collider.enabled || renderer.enabled)
					{
						collider.enabled = false;
						renderer.enabled = false;
					}
				}
				else
				{
					if(!collider.enabled || !renderer.enabled)
					{
						collider.enabled = true;
						renderer.enabled = true;
					}
				}
			}
			if(disableInHuman)
			{
				if(!playerSwitch.curState)
				{
					if(collider.enabled || renderer.enabled)
					{
						collider.enabled = false;
						renderer.enabled = false;
					}
				}
				else
				{
					if(!collider.enabled || !renderer.enabled)
					{
						collider.enabled = true;
						renderer.enabled = true;
					}
				}
			}
		}
//	}
}

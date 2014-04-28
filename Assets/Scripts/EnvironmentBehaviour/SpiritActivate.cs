using UnityEngine;
using System.Collections;

public class SpiritActivate : MonoBehaviour {
	private PlayerSwitch playerSwitch;
	public bool deActivate;
	public bool invisible;
	public bool uncollidable;
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
					if(invisible && renderer)
					{
						if(renderer.enabled)
						{
							renderer.enabled = false;
						}
					}
					if(uncollidable && collider)
					{
						if(collider.enabled)
						{
							collider.enabled = false;
						}
					}
				}
				else
				{
					if(invisible && renderer)
					{
						if(!renderer.enabled)
						{
							renderer.enabled = true;
						}
					}
					if(uncollidable && collider)
					{
						if(!collider.enabled)
						{
							collider.enabled = true;
						}
					}
				//					if(!collider.enabled || !renderer.enabled)
//					{
//						collider.enabled = true;
//						renderer.enabled = true;
//					}
				}
			}
			if(disableInHuman)
			{
				if(!playerSwitch.curState)
				{
					if(invisible && renderer)
					{
						if(renderer.enabled)
						{
							renderer.enabled = false;
						}
					}
					if(uncollidable && collider)
					{
						if(collider.enabled)
						{
							collider.enabled = false;
						}
					}
				//					if(collider.enabled || renderer.enabled)
//					{
//						collider.enabled = false;
//						renderer.enabled = false;
//					}
				}
				else
				{
					if(invisible && renderer)
					{
						if(!renderer.enabled)
						{
							renderer.enabled = true;
						}
					}
					if(uncollidable && collider)
					{
						if(!collider.enabled)
						{
							collider.enabled = true;
						}
					}
				//					if(!collider.enabled || !renderer.enabled)
//					{
//						collider.enabled = true;
//						renderer.enabled = true;
//					}
				}
			}
		}
//	}
}

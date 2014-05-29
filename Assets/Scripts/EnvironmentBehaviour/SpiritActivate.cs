using UnityEngine;
using System.Collections;

public class SpiritActivate : MonoBehaviour {
	private PlayerSwitch playerSwitch;
	public bool deActivate;
	public bool invisible;
	public bool uncollidable;
	public bool disableInSpirit = true;
	public bool disableInHuman = false;

	private Color startColor;
	private bool fadedIn;
	void Start () 
	{
		playerSwitch = GameObject.FindObjectOfType<PlayerSwitch>();
		startColor = this.renderer.material.color;
		fadedIn =true;
		if(disableInHuman)
		{
			this.renderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 0);
		}
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
						if(fadedIn)
						{		
							fadedIn = false;				
							StartCoroutine("FadeOut");
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
						if(!fadedIn)
						{
						fadedIn = true;
						StartCoroutine("FadeIn");
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

	IEnumerator FadeOut()
	{
		bool onOff = true;
		float mTime = 0;
		Color curCol = this.renderer.material.color;
		while(onOff)
		{
			if(mTime < 1)
			{
				mTime += Time.deltaTime;
				this.renderer.material.color = Color.Lerp(curCol, new Color(curCol.r, curCol.g, curCol.b, 0), mTime);
			}
			else
			{
				onOff = false;
//				renderer.enabled = false;
			}

			yield return null;
		}
	}
	IEnumerator FadeIn()
	{
		bool onOff = true;
		float mTime = 0;
		Color curCol = this.renderer.material.color;
		while(onOff)
		{
			if(mTime < 1)
			{
				mTime += Time.deltaTime;
				this.renderer.material.color = Color.Lerp(curCol, startColor, mTime);
			}
			else
			{
				onOff = false;
			}
			
			yield return null;
		}
	}
//	}
}

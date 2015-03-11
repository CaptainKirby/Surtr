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
		startColor = this.GetComponent<Renderer>().material.color;
		fadedIn =true;
		if(disableInHuman)
		{
			this.GetComponent<Renderer>().material.color = new Color(startColor.r, startColor.g, startColor.b, 0);
		}
	}
	

	void Update () {
//	if(PlayerSwitch.fadeFromForm)
//		{
			if(disableInSpirit)
			{
				if(playerSwitch.curState)
				{
					if(invisible && GetComponent<Renderer>())
					{
						if(GetComponent<Renderer>().enabled)
						{
							GetComponent<Renderer>().enabled = false;
						}
					}
					if(uncollidable && GetComponent<Collider>())
					{
						if(GetComponent<Collider>().enabled)
						{
							GetComponent<Collider>().enabled = false;
						}
					}
				}
				else
				{
					if(invisible && GetComponent<Renderer>())
					{
						if(!GetComponent<Renderer>().enabled)
						{
							GetComponent<Renderer>().enabled = true;
						}
					}
					if(uncollidable && GetComponent<Collider>())
					{
						if(!GetComponent<Collider>().enabled)
						{
							GetComponent<Collider>().enabled = true;
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
					if(invisible && GetComponent<Renderer>())
					{
						if(fadedIn)
						{		
							fadedIn = false;				
							StartCoroutine("FadeOut");
						}
					}
					if(uncollidable && GetComponent<Collider>())
					{
						if(GetComponent<Collider>().enabled)
						{
							GetComponent<Collider>().enabled = false;
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
					if(invisible && GetComponent<Renderer>())
					{
						if(!fadedIn)
						{
						fadedIn = true;
						StartCoroutine("FadeIn");
						}
					}
					if(uncollidable && GetComponent<Collider>())
					{
						if(!GetComponent<Collider>().enabled)
						{
							GetComponent<Collider>().enabled = true;
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
		Color curCol = this.GetComponent<Renderer>().material.color;
		while(onOff)
		{
			if(mTime < 1)
			{
				mTime += Time.deltaTime;
				this.GetComponent<Renderer>().material.color = Color.Lerp(curCol, new Color(curCol.r, curCol.g, curCol.b, 0), mTime);
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
		Color curCol = this.GetComponent<Renderer>().material.color;
		while(onOff)
		{
			if(mTime < 1)
			{
				mTime += Time.deltaTime;
				this.GetComponent<Renderer>().material.color = Color.Lerp(curCol, startColor, mTime);
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

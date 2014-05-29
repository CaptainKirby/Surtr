using UnityEngine;
using System.Collections;

public class SwirlFade : MonoBehaviour {
	private Color startColor;
	private bool fadedIn;
	private SpiritMovement sMove;
	private PlayerSwitch playerSwitch;
	// Use this for initialization
	void Start () {
	
		startColor = this.renderer.material.GetColor("_TintColor");

		sMove = GameObject.Find("Spirit").GetComponent<SpiritMovement>();
		playerSwitch = GameObject.FindObjectOfType<PlayerSwitch>();
		StartCoroutine("FadeOut");
		fadedIn =	true;

	}
	
	// Update is called once per frame
	void Update () {
	
		if(playerSwitch.curState)
		{
		
			if(sMove.grounded)
			{
				if(fadedIn)
				{		
	//				if(lightPulse != null)
	//				{
	//					lightPulse.enabled = true;
	//					lightPulse.StartCoroutine("Pulsate");
	//					
	//				}
					fadedIn = false;				
					StartCoroutine("FadeIn");
				}
			}
			else
			{
				if(!fadedIn)
				{
	//				if(lightPulse != null)
	//				{
	//					lightPulse.enabled = false;
	//					lightPulse.StopCoroutine("Pulsate");
	//				}
					fadedIn = true;
					StartCoroutine("FadeOut");
				}
			}

		}
		else
		{
			if(!fadedIn)
			{
				//				if(lightPulse != null)
				//				{
				//					lightPulse.enabled = false;
				//					lightPulse.StopCoroutine("Pulsate");
				//				}
				fadedIn = true;
				StartCoroutine("FadeOut");
			}
		}
	}
	IEnumerator FadeOut()
	{
		bool onOff = true;
		float mTime = 0;
		Color curCol = this.renderer.material.GetColor("_TintColor");
		while(onOff)
		{
			if(mTime < 1)
			{
				mTime += Time.deltaTime;
				this.renderer.material.SetColor("_TintColor", Color.Lerp(curCol, new Color(curCol.r, curCol.g, curCol.b, 0), mTime));
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
		Color curCol = this.renderer.material.GetColor("_TintColor");
		while(onOff)
		{
			if(mTime < 1)
			{
				mTime += Time.deltaTime;
				this.renderer.material.SetColor("_TintColor", Color.Lerp(curCol, startColor, mTime));
			}
			else
			{
				onOff = false;
			}
			
			yield return null;
		}
	}
}

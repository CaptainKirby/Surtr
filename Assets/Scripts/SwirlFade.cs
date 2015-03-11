using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwirlFade : MonoBehaviour {
	private Color startColor;
	private bool fadedIn;
	private SpiritMovement sMove;
	private PlayerSwitch playerSwitch;
	// Use this for initialization
//	private List<GameObject> children;
//	private int i = 0;
	void Start () {

//		foreach( GameObject gObj in transform)
//		{
//			children[i] = gObj;
//			i++;
//		}

		startColor = this.GetComponent<Renderer>().material.GetColor("_TintColor");

		sMove = GameObject.Find("Spirit").GetComponent<SpiritMovement>();
		playerSwitch = GameObject.FindObjectOfType<PlayerSwitch>();
		if(!sMove.grounded)
		{
			StartCoroutine("FadeOut");
			fadedIn =	true;
		}
		this.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(startColor.r, startColor.g, startColor.b, 0));

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
//					StartCoroutine("FadeOut");
					StartCoroutine("CheckIfGrounded");
				}
			}

		}
		else
		{
			if(!fadedIn)
			{
				StopCoroutine("FadeIn");
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
	IEnumerator CheckIfGrounded()
	{
		yield return new WaitForSeconds(0.5f);
		if(!sMove.grounded)
		{
			StartCoroutine("FadeOut");
		}
	}
	IEnumerator FadeOut()
	{
		bool onOff = true;
		float mTime = 0;
		Color curCol = this.GetComponent<Renderer>().material.GetColor("_TintColor");
		while(onOff)
		{
			if(mTime < 1)
			{
				mTime += Time.deltaTime;

					this.GetComponent<Renderer>().material.SetColor("_TintColor", Color.Lerp(curCol, new Color(curCol.r, curCol.g, curCol.b, 0), mTime));
				
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
		Color curCol = this.GetComponent<Renderer>().material.GetColor("_TintColor");
		while(onOff)
		{
			if(mTime < 1)
			{
				mTime += Time.deltaTime;

					this.GetComponent<Renderer>().material.SetColor("_TintColor", Color.Lerp(curCol, startColor, mTime));

			}
			else
			{
				onOff = false;
			}
			
			yield return null;
		}
	}
}

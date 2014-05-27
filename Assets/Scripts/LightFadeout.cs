using UnityEngine;
using System.Collections;

public class LightFadeout : MonoBehaviour {

	private Light light;
	private float startIntens;
	private bool fadedIn;
	private PlayerSwitch playerSwitch;
	private LightPulse lightPulse;
	void Awake()
	{
		if(GetComponent<LightPulse>())
		{
			lightPulse = GetComponent<LightPulse>();
//			lightPulse.StopCoroutine("Pulsate");
			lightPulse.enabled = false;
		}
	}
	void Start () {

		playerSwitch = GameObject.FindObjectOfType<PlayerSwitch>();
		light = this.GetComponent<Light>();
		startIntens = light.intensity;
		fadedIn =	true;
		StartCoroutine("FadeOut");



	}
	

	void Update () {
	
		if(playerSwitch.curState)
		{
			if(fadedIn)
			{		
				if(lightPulse != null)
				{
					lightPulse.enabled = true;
					lightPulse.StartCoroutine("Pulsate");

				}
				fadedIn = false;				
				StartCoroutine("FadeIn");
			}
		}
		else
		{
			if(!fadedIn)
			{
				if(lightPulse != null)
				{
					lightPulse.enabled = false;
					lightPulse.StopCoroutine("Pulsate");
				}
				fadedIn = true;
				StartCoroutine("FadeOut");
			}
		}
	}

	IEnumerator FadeOut()
	{
		bool onOff = true;
		float mTime = 0;
		float curIntens = light.intensity;
		while(onOff)
		{
			if(mTime < 1)
			{
				mTime += Time.deltaTime;
				light.intensity = Mathf.Lerp(curIntens, 0, mTime);
//				this.renderer.material.color = Color.Lerp(curCol, new Color(curCol.r, curCol.g, curCol.b, 0), mTime);
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
//		Color curCol = this.renderer.material.color;
		while(onOff)
		{
			if(mTime < 1)
			{
				mTime += Time.deltaTime;
				light.intensity = Mathf.Lerp(0, startIntens, mTime);
//				this.renderer.material.color = Color.Lerp(curCol, startColor, mTime);
			}
			else
			{
				onOff = false;
			}
			
			yield return null;
		}
	}
}

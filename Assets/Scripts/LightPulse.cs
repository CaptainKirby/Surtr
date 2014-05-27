using UnityEngine;
using System.Collections;

public class LightPulse : MonoBehaviour {
	public float rate = 1;
	public float maxIn = 1;
	public float minIn = 0.5f;
	private Light light;
	private float startInt;
	private bool enabled;
	private bool pulsating;
	void Start () {
		light = this.GetComponent<Light>();
		enabled = true;
		StartCoroutine("Pulsate");
		startInt = light.intensity;
//		faded = true;
//		enabled= true;
	}
	


	void Update () {
	
//		if(PlayerSwitch.fadeFromForm && !enabled && !pulsating)
//		{
//			enabled = true;
//			StartCoroutine("Pulsate");
//		}
//		if(PlayerSwitch.fadeFromForm && enabled && pulsating)
//		{
//			StartCoroutine("FadeOut");
//			StopCoroutine("Pulsate");
//		}

	}

	IEnumerator Pulsate()
	{
		bool onOff = true;
		float mTime = 0;
		bool oneWay = false;
		float curIntens = startInt;
//		yield return new WaitForSeconds(0.1f);
//		pulsating = true;
		while(onOff)
		{
			if(enabled)
			{

				if(!oneWay)
				{

					if(mTime < 1)
					{
						mTime += Time.deltaTime * rate;
						light.intensity = Mathf.SmoothStep(curIntens,  minIn, mTime);
					}
					else
					{
						oneWay = true;
						mTime = 0;
						curIntens = light.intensity;
//						faded = true;
					}
				}
				else
				{
					if(mTime < 1)
					{
						mTime += Time.deltaTime * rate;
						light.intensity = Mathf.SmoothStep(curIntens, maxIn, mTime);
					}
					else
					{
						oneWay = false;
						mTime = 0;
						curIntens = light.intensity;
					}
				}
			}

			yield return null;
		}

	}

//	IEnumerator FadeOut()
//	{
//		bool onOff= true;
//		float curIntens = light.intensity;
//		float mTime = 0;
//		while(onOff)
//		{
//			if(mTime <1)
//			{
//				mTime += Time.deltaTime;
//				light.intensity = Mathf.Lerp(curIntens, 0, mTime);
//			}
//			else
//			{
//				enabled = false;
////				faded = false;
//				pulsating = false;
//			}
//			yield return null;
//
//		}
//	}


}

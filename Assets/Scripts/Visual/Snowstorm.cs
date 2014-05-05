using UnityEngine;
using System.Collections;


[RequireComponent (typeof (ActionHandler))]

public class Snowstorm : MonoBehaviour {

	public float emissionMax;
	public bool fadeIn;
	public ParticleSystem pSys;
	// Use this for initialization
	private bool started;
	private ActionHandler actionHandler;
	public float fadeSpeed = 0.5f;

	void Start () 
	{
		pSys = GetComponent<ParticleSystem>();
		actionHandler =  GetComponent<ActionHandler>();

		if(actionHandler)
		{
			actionHandler.TakeAction += FadeS;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

//	void OnTriggerEnter(Collider col)
//	{
//		if(col.CompareTag("Player"))
//		{
//			if(fadeIn)
//			{
//				StartCoroutine("Fade", true);
//			}
//			else
//			{
//				StartCoroutine("Fade", false);
//			}
//		}
//
//	}
	void FadeS(GameObject gObj, bool stop)
	{
//		Debug.Log ("HUEGSG");

		if(gObj.CompareTag("Player"))
		{

			if(!started)
			{
				if(fadeIn)
				{
					StartCoroutine("Fade", true);
					started = true;
				}
				else
				{
					StartCoroutine("Fade", false);
					started = true;

				}
			}
		}

	}
	IEnumerator Fade(bool fadeIn)
	{
		bool onOff = true;
		float mTime = 0;
		while(onOff)
		{
			mTime += Time.deltaTime * fadeSpeed;
			if(fadeIn)
			{
				if(mTime < 1)
				{
					pSys.emissionRate = Mathf.Lerp(0, emissionMax, mTime);
				}
				else 
				{
					onOff = false;
				}
				//fade emission up
			}
			else
			{
				if(mTime < 1)
				{
					pSys.emissionRate = Mathf.Lerp(emissionMax, 0, mTime);
				}
				else 
				{
					onOff = false;
				}
				//fade emission down
			}
			yield return null;
		}

	}


}

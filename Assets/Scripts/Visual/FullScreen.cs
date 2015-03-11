using UnityEngine;
using System.Collections;
[RequireComponent (typeof (ActionHandler))]

public class FullScreen : MonoBehaviour {

	private ActionHandler actionHandler;
	private bool faded;
	private	 bool onOff = true;
	private Color noAlpha;
	private Color sColor;

	void Start () {
		sColor = GetComponent<Renderer>().material.color;
		noAlpha =new Color(GetComponent<Renderer>().material.color.r, GetComponent<Renderer>().material.color.g, GetComponent<Renderer>().material.color.b, 0);
		actionHandler =  GetComponent<ActionHandler>();
		if(actionHandler)
		{
			actionHandler.TakeAction += Fader;
		}
		GetComponent<Renderer>().enabled = false;
	}

	void Update () {
	
	}

	void Fader(GameObject gObj, bool stop)
	{
		if(!faded)
		{
			faded = true;

			StartCoroutine(FadeCR());
		}
	}

	IEnumerator FadeCR()
	{
//		if(!onOff)
//		{
		yield return new WaitForSeconds(0.3f);
		GetComponent<Renderer>().enabled = true;
		float mTime = 0;
		yield return new WaitForSeconds(1.2f);
		onOff = true;
		while(onOff)
		{
			//fadein
			mTime += Time.deltaTime;
			if(mTime < 1)
			{
				GetComponent<Renderer>().material.color = Color.Lerp(sColor, noAlpha, mTime);
			}
			yield return null;
		}
	}
}

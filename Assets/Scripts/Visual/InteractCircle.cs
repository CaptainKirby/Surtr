using UnityEngine;
using System.Collections;

public class InteractCircle : MonoBehaviour {
	public bool outerCircle;
	private bool started = false;
	// Use this for initialization
	public float speed;
	public float minScale = 0.8f;
	private float curVel;
	private Transform player;
	private Transform spirit;
	private float distP;
	private float distS;

	private Vector3 startScale;
	public bool fadedIn;
	private Color noAlphaColor;
	private Color startColor;
	public float distanceCut = 5;
	public bool spiritInteract;
	public bool playerInteract;
	public bool dontFade;
	private PlayerSwitch pSwitch;
	void Start () 
	{

		pSwitch = GameObject.FindObjectOfType<PlayerSwitch>();
		startColor = GetComponent<Renderer>().material.color;
		noAlphaColor = new Color (GetComponent<Renderer>().material.color.r, GetComponent<Renderer>().material.color.g, GetComponent<Renderer>().material.color.b, 0);
		startScale = transform.localScale;
		player = GameObject.Find("Player").transform;
		spirit = GameObject.Find("Spirit").transform;
		if(outerCircle)
		{
			StartCoroutine(Scale ());
		}
		if(!dontFade)
		{

			StartCoroutine(DistanceCheck());
		}


	}

	void Update () 
	{
		//if spiritdist
		if(!dontFade)
		{
			if(pSwitch.curState)
			{
				if(!fadedIn && distS > distanceCut )
				{
		//			Debug.Log ("YOLO");
					fadedIn = true;
					StartCoroutine("Fade", true);
				}

				if(fadedIn && distS < distanceCut)
				{
					fadedIn = false;
					StartCoroutine("Fade", false);
				}
			}
			else
			{
				if(!fadedIn )
				{

					fadedIn = true;
					StartCoroutine("Fade", true);
				}
			}

		}
	}

	IEnumerator DistanceCheck()
	{
		while(true)
		{
			distP = Vector3.Distance(player.position, this.transform.position);
			distS = Vector3.Distance(spirit.position, this.transform.position);

			yield return new WaitForSeconds(0.5f);
		}
	}

	IEnumerator Fade(bool shown)
	{
		Color beginColor = GetComponent<Renderer>().material.color;
		bool onOff = true;
		float mTime = 0;
		while(onOff)
		{
			mTime += Time.deltaTime;
			if(!shown)
			{
				//fade ind
				if(mTime < 1)
				{
					GetComponent<Renderer>().material.color = Color.Lerp(noAlphaColor, startColor, mTime); 
				}
				else
				{
					onOff = false;
				}
			}
			else
			{
				if(mTime < 1)
				{
					GetComponent<Renderer>().material.color = Color.Lerp(startColor, noAlphaColor, mTime); 
				}
				else
				{
					onOff = false;
				}
			}
			yield return null;
		}
	}
	IEnumerator Scale()
	{
		bool onOff = true;
		float mTime = 0;
		bool oneWay = false;
		while(onOff)
		{
			mTime += Time.deltaTime;
			if(!oneWay)
			{
				if(mTime < 1)
				{
					transform.localScale = new Vector3(Mathf.SmoothStep(startScale.x, minScale,  mTime), transform.localScale.y, Mathf.SmoothStep(startScale.y, minScale,  mTime));
				}
				else
				{
					oneWay = true;
					mTime = 0;

				}
			}
			if(oneWay)
			{
				if(mTime < 1)
				{

					transform.localScale = new Vector3(Mathf.SmoothStep(minScale, startScale.x, mTime), transform.localScale.y, Mathf.SmoothStep(minScale, startScale.y,  mTime));
				}
				else
				{
					oneWay = false;
					mTime = 0;
					
				}
			}

			yield return null;
		}
	}
}

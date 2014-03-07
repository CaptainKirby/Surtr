using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move : MonoBehaviour {

	[SerializeField]
	public bool transformMove;
	[SerializeField]
	public bool pingPongMove;
	[SerializeField]
	public bool smoothMove;
	[SerializeField]
	public float moveSpeed = 1;
	[SerializeField]
	public bool moveStartDelay = false;
	[SerializeField]
	public float moveStartDelayTime;
	[SerializeField]
	public bool moveInbetweenDelay;
	[SerializeField]
	public float moveInbetweenDelayTime;
	[SerializeField]
	public bool resetMove;
	[SerializeField]
	public Vector3 moveToPos = Vector3.zero; 
	[SerializeField]
	public Vector3 moveStartPos = Vector3.zero;
	
	public bool pauseable;
	public bool pause;
	public bool playOnce;
	public bool started;
	//find action script
	public bool animCurveUse;
	public AnimationCurve animCurve;
	public float curveValue;
//	public ActionHandler actionHandler;

	void Awake()
	{
		gameObject.transform.position = moveStartPos;
		ActionHandler actionHandler =  GetComponent<ActionHandler>();
		actionHandler.TakeAction += TransformPositionT;
//		actionHandler = GetComponent<ActionHandler>();

	}
	void Start () {
		//subscripte to doit delegate
//		if(actionHandler != null)
//		{
//			actionHandler.TakeAction += TransformPositionT();
//		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(started && pauseable)
		{
			if(PlayerSwitch.fadeFromForm)
			{
				pause = !pause;
			}
		}

	}

	private void TransformPositionT()
	{
		if(!started)
		{
			StartCoroutine(TransformPosition());
		}
		started = true;
	}

	IEnumerator TransformPosition()
	{
		bool onOff = true;
		float mTime = 0f;
		//		Vector3 startPos = this.transform.position;
		
		bool oneWay = false;
		bool delay = true;
		
		
		
		if(moveStartDelay)
		{
			yield return new WaitForSeconds(moveStartDelayTime);
		}
		if(!pingPongMove)
		{
			while(onOff)
			{
				if(!pause)
				{
					if(mTime < 1f)
					{
						//						started = true;
						mTime += Time.deltaTime * moveSpeed;
						if(animCurveUse)
						{
							curveValue = animCurve.Evaluate(mTime);
						}
						if(!animCurveUse)
						{
							if(!smoothMove)
							{
								this.transform.position = Vector3.Lerp(moveStartPos, moveToPos, mTime);
							}
							else
							{
								this.transform.position = new Vector3(Mathf.SmoothStep(moveStartPos.x, moveToPos.x, mTime), Mathf.SmoothStep(moveStartPos.y, moveToPos.y, mTime), Mathf.SmoothStep(moveStartPos.z, moveToPos.z, mTime));
							}
						}
						else
						{
							this.transform.position = Vector3.Lerp(moveStartPos, moveToPos, curveValue);

						}
					}
					else
					{
						if(!playOnce)
						{
							started = false;
						}
						onOff = false;
						
						//doit = false
					}
				}
				yield return null;
				
			}
		}
		if(pingPongMove)
		{
			while(onOff)
			{
				if(!pause)
				{
					if(animCurveUse)
					{
						curveValue = animCurve.Evaluate(mTime);
					}
					if(mTime > 1 && !oneWay)
					{
						oneWay = true;
						mTime = 0;
						if(moveInbetweenDelay)
						{
							delay = false;
							yield return new WaitForSeconds(moveInbetweenDelayTime);
							delay = true;
						}
					}
					if(mTime > 1 && oneWay)
					{
						oneWay = false;
						mTime = 0;
						if(moveInbetweenDelay)
						{
							delay = false;
							yield return new WaitForSeconds(moveInbetweenDelayTime);
							delay = true;
						}
					}
					if(delay)
					{
						if(!oneWay)
						{
							mTime += Time.deltaTime * moveSpeed;
							if(animCurveUse)
							{
								curveValue = animCurve.Evaluate(mTime);
							}
							if(!animCurveUse)
							{
								if(!smoothMove)
								{
									this.transform.position = Vector3.Lerp(moveStartPos, moveToPos, mTime);
								}
								else
								{
									this.transform.position = new Vector3(Mathf.SmoothStep(moveStartPos.x, moveToPos.x, mTime), Mathf.SmoothStep(moveStartPos.y, moveToPos.y, mTime), Mathf.SmoothStep(moveStartPos.z, moveToPos.z, mTime));
								}
							}
							else
							{
								this.transform.position = Vector3.Lerp(moveStartPos, moveToPos, curveValue);

							}
						}
						if(oneWay)
						{
							mTime += Time.deltaTime * moveSpeed;
							if(animCurveUse)
							{
								curveValue = animCurve.Evaluate(mTime);
							}
							if(!animCurveUse)
							{
								if(!smoothMove)
								{
									this.transform.position = Vector3.Lerp(moveToPos, moveStartPos, mTime);
								}
								else
								{
									this.transform.position = new Vector3(Mathf.SmoothStep(moveToPos.x, moveStartPos.x, mTime), Mathf.SmoothStep(moveToPos.y, moveStartPos.y, mTime), Mathf.SmoothStep(moveToPos.z, moveStartPos.z, mTime));
								}
							}
							else
							{
								this.transform.position = Vector3.Lerp(moveToPos, moveStartPos,curveValue);
							}
							
						}
					}
				}
				yield return null;
			}
		}
//		if(animCurveUse)
//		{
//			while(true)
//			{
//				mTime += Time.deltaTime * moveSpeed;
//				Debug.Log (animCurve.Evaluate(mTime));
//				yield return null;
//			}
//		}
	}
}

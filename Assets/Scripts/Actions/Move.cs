using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (ActionHandler))]
public class Move : MonoBehaviour {

	[SerializeField]
	public bool transformMove;
	[SerializeField]
	public bool pingPongMove;
	[SerializeField]
	public bool backAndForth;
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
//	[SerializeField]
	public Vector3 moveToPos; 
//	[SerializeField]
	public Vector3 moveStartPos;

	private Vector3 moveStartPos2;
	private Vector3 moveToPos2;
	public bool moveBack;
	private bool movedB;
	private bool callMoveBack;
	public bool pauseable;
	public bool pause;
	public bool playOnce;
	public bool started;
	//find action script
	public bool animCurveUse;
	public AnimationCurve animCurve;
	public float curveValue;
//	public bool onOff = true;

	private float mTime;
	private ActionHandler actionHandler;
	public bool playOnAwake;
	private PlayerSwitch pSwitch;
	public bool onlyHuman;
//	public ActionHandler actionHandler;
	void Awake()
	{
//		onOff = true;
		pSwitch = GameObject.FindObjectOfType<PlayerSwitch>();
		gameObject.transform.position = moveStartPos;
		actionHandler =  GetComponent<ActionHandler>();
		if(actionHandler)
		{
			actionHandler.TakeAction += TransformPositionT;
		}
//		actionHandler = GetComponent<ActionHandler>();

	}
	void Start () {
		if(!started && playOnAwake)
		{
			started = true;
			mTime = 0;
			StartCoroutine(TransformPosition());
		}
		if(pauseable)
		{
			pause = !pause;
		}
		//subscripte to doit delegate
//		if(actionHandler != null)
//		{
//			actionHandler.TakeAction += TransformPositionT();
//		}
	}
	
	// Update is called once per frame
	void Update () 
	{
//		Debug.Log (started);
		if(started && pauseable)
		{
			if(PlayerSwitch.fadeFromForm)
			{
				pause = !pause;
			}
		}

	}

	private void TransformPositionT(GameObject gObj, bool stop)
	{
//		if(!pSwitch.curState)
//		{
		if(gObj.CompareTag("Player") && onlyHuman)
		{

//		if(started && moveBack && onOff)
//		{
//			onOff = false;
//		}
//		if(started && moveBack && !onOff)
//		{
//			onOff = true;
//			moveToPos = moveStartPos;
//			moveStartPos = this.transform.position;
//			StartCoroutine(TransformPosition());
//
//
//		}
//		if(started && !movedB && moveBack)
//		{

//			Debug.Log ("TEST");
//			moveToPos = moveStartPos;
//			moveStartPos = this.transform.position;
//			StartCoroutine(TransformPosition());
//		}
			if(!started)
			{
//				Debug.Log ("started");
				started = true;
				mTime = 0;
				StartCoroutine(TransformPosition());
			}
			else if(started && moveBack)
			{
				Debug.Log ("TGESUIGSGN");
				moveToPos2 = moveStartPos;
				moveStartPos2 = moveToPos;
	//			onOff = false;
				moveToPos = moveToPos2;
				moveStartPos = moveStartPos2;

				mTime = 1- mTime;
				StartCoroutine(TransformPosition());
	//			onOff = true;
	//			Debug.Log ("WHALALAL");
			}
//			}
		}

		if(!onlyHuman)
		{
			if(!started)
			{
				//				Debug.Log ("started");
				started = true;
				mTime = 0;
				StartCoroutine(TransformPosition());
			}
			else if(started && moveBack)
			{
				Debug.Log ("TGESUIGSGN");
				moveToPos2 = moveStartPos;
				moveStartPos2 = moveToPos;
				//			onOff = false;
				moveToPos = moveToPos2;
				moveStartPos = moveStartPos2;
				
				mTime = 1- mTime;
				StartCoroutine(TransformPosition());
				//			onOff = true;
				//			Debug.Log ("WHALALAL");
			}

		}

	}
	
	IEnumerator TransformPosition()
	{		
//		actionHandler.TakeAction -= TransformPositionT;



		bool onOff = true; 
//		mTime = 0f;
		//		Vector3 startPos = this.transform.position;
		
		bool oneWay = false;
		bool delay = true;
//		callMoveBack = true;
//		if(moveBack)
//		{
//			if(movedB)
//			{
//				moveToPos = moveStartPos;
//
//			}
//		}
//		
		if(moveStartDelay)
		{
			yield return new WaitForSeconds(moveStartDelayTime);
		}
		if(!pingPongMove && !backAndForth)
		{
			while(onOff)
			{
				if(this.enabled)
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
						if(!moveBack)
						{
							started = false;
						}
//						actionHandler.TakeAction += TransformPositionT;

						onOff = false;

						Debug.Log ("DONE");
//							if(moveBack)
//							{
//								moveToPos = moveStartPos2;
//								moveStartPos = moveToPos2;
//							}
						//doit = false
					}
				}
				}
				yield return new WaitForFixedUpdate();
			
			}
		}
		if(pingPongMove)
		{
			while(onOff)
			{
				if(this.enabled)
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
				}
				yield return new WaitForFixedUpdate();

			}
		}
		if(backAndForth)
		{
			while(onOff)
			{
				if(this.enabled)
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

//						else
//						{
//							if(!moveBack)
//							{
//								started = false;
//							}
//							
//							onOff = false;
//							
//							Debug.Log ("DONE");
//						}
//						if(mTime > 1 && oneWay)
//						{
//							oneWay = false;
//							mTime = 0;
//							if(moveInbetweenDelay)
//							{
//								delay = false;
//								yield return new WaitForSeconds(moveInbetweenDelayTime);
//								delay = true;
//							}
//						}
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
								if(mTime > 1)
								{
									Debug.Log ("DONE!!!");
									onOff = false;
									started = false;
								}
								
							}
						}
					}
				}
				yield return new WaitForFixedUpdate();
				
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

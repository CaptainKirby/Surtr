using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
//[ExecuteInEditMode()]  
public class ActionHandler : MonoBehaviour {
//	[System.Serializable]
	//transform pos, rot, scale, ping-pong, color 
	public bool takeInput = true;

	public bool listen;
	public bool listenEnable;
	public bool on;
	[SerializeField]
	public GameObject attatchedObj;
	[SerializeField]
	public List<GameObject> attatchedObjs = new List<GameObject>();
	private bool doit;
	public bool playOnce;

	public delegate void TakeActionDelegate(GameObject gObj, bool stop);
	public event TakeActionDelegate TakeAction;


	[SerializeField]
	public bool pause;
	[SerializeField]
	public bool pausable;
	[SerializeField]
	public bool started;

	//transform move
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


	//transform rotate
	[SerializeField]
	public bool transformRotate; 
	[SerializeField]
	public Vector3 rotateToAngle;
	[SerializeField]
	public Vector3 rotateStartAngle = Vector3.zero;
	[SerializeField]
	public bool rotateStartDelay = false;
	[SerializeField]
	public float rotateStartDelayTime;
	[SerializeField]
	public bool smoothRotate;
	[SerializeField]
	public bool pingPongRotate;
	[SerializeField]
	public float rotateSpeed = 1f;
	[SerializeField]
	public bool rotateInbetweenDelay;
	[SerializeField]
	public float rotateInbetweenDelayTime;


	//call dynamic function
	[SerializeField]
	public bool callFunction;
//	[SerializeField]
//	public delegate void DynamicFunction();
	[SerializeField]
	public string dynFunctionName = null;
//	[SerializeField]
	//trigger on colliding object
	[SerializeField]
	public GameObject collidingObject;

	void Start () 
	{
//		dynFunctionName = nameOfTheFunction;
//		if(transformMove)
//		{
//			if(moveStartPos == new Vector3(0,0,0))
//			{
//				moveStartPos = this.transform.position;
//			}
//			this.transform.position = moveStartPos;
//		}
//		if(transformRotate)
//		{
//			if(rotateStartAngle ==  new Vector3(0,0,0))
//			{
//				rotateStartAngle = this.transform.rotation.eulerAngles;
//			}
//			this.transform.rotation = Quaternion.Euler(rotateStartAngle);
//		}


	}


	void Update () 
	{
//		Debug.Log (pause);
	}




	public void DoThing(GameObject gObj, bool stop)
	{
//		if(
		if(TakeAction != null)
		{
//			foreach(GameObject gObj in attatchedObjs)
//			{
				TakeAction(gObj, stop);
//			}
		}
//		if(callFunction)
//		{
//			if(collidingObject)
//			{
//				MonoBehaviour[] allMbs = collidingObject.GetComponents<MonoBehaviour>();
//				foreach(MonoBehaviour mb in allMbs)
//				{
//					mb.Invoke (dynFunctionName, 0);
//				}
//			}
//		}
//		if(pausable)
//		{
//			if(!doit)
//			{
//
//				if(started && pausable)
//				{ 
//					if(!pause)
//					{
//						pause = true;
//					}
//					else
//					{
//						pause = false;
//					}
//				}
//				if(!started)
//				{
//					started = true;
//					if(transformMove)
//					{
//						StartCoroutine(TransformPosition());
//					}
//					if(transformRotate)
//					{
//						StartCoroutine(TransformRoation()); 
//					}
//				}
//
//
//
//			}
//		}
//		if(!pausable)
//		{
//			if(transformMove)
//			{
//				StartCoroutine(TransformPosition());
//			}
//			if(transformRotate)
//			{
//				StartCoroutine(TransformRoation()); 
//			}
//		}
//		if(pausable && !pause)
//		{
//			if(!doit && !started)
//			{
//
//				started = true;
//				if(transformMove)
//				{
//					StartCoroutine(TransformPosition());
//				}
//				if(transformRotate)
//				{
//					StartCoroutine(TransformRoation()); 
//				}
//			}
//			if(started && !pause)
//			{
//				pause = true;
////				started = false;
//			}

		}


	IEnumerator TransformRoation()
	{
//		Debug.Log ("TEST");
		bool onOff = true;
		float mTime = 0;
//		Vector3 startRot = Quaternion.Euler(this.transform.eulerAngles);
//		Quaternion startRot = Quaternion.Euler(this.transform.eulerAngles);
		bool oneWay = false;
		bool delay = true;



//		
		if(rotateStartDelay)
		{
			yield return new WaitForSeconds(rotateStartDelayTime);
		}
		if(!pingPongRotate)
		{
			while(onOff)
			{
				if(!pause)
				{
					if(mTime < 1f)
					{
//						started = true;
						mTime += Time.deltaTime * moveSpeed;
						if(!smoothRotate)
						{
							this.transform.rotation = Quaternion.Lerp(Quaternion.Euler(rotateStartAngle),Quaternion.Euler(rotateToAngle),mTime);
						}
						else
						{
							float smoothStep = Mathf.SmoothStep(0.0f, 1.0f, mTime);
							this.transform.rotation = Quaternion.Lerp(Quaternion.Euler(rotateStartAngle),Quaternion.Euler(rotateToAngle), smoothStep);
						}
					}
					else
					{
						if(!playOnce)
						{
							started = false;
						}
						onOff = false;
					}
				}
					yield return null;
			}
		}
		if(pingPongRotate)
		{
			while(onOff)
			{
				if(!pause)
				{
					if(mTime > 1 && !oneWay)
					{
						oneWay = true;
						mTime = 0;
						if(rotateInbetweenDelay)
						{
							delay = false;
							yield return new WaitForSeconds(rotateInbetweenDelayTime);
							delay = true;
						}
					}
					if(mTime > 1 && oneWay)
					{
						oneWay = false;
						mTime = 0;
						if(rotateInbetweenDelay)
						{
							delay = false;
							yield return new WaitForSeconds(rotateInbetweenDelayTime);
							delay = true;
						}
					}
					if(delay)
					{
						if(!oneWay)
						{
							mTime += Time.deltaTime * rotateSpeed;
							if(!smoothRotate)
							{
								this.transform.rotation = Quaternion.Lerp(Quaternion.Euler(rotateStartAngle),Quaternion.Euler(rotateToAngle),mTime);
	//							this.transform.position = Vector3.Lerp(moveStartPos, moveToPos, mTime);
							}
							else
							{
								float smoothStep = Mathf.SmoothStep(0.0f, 1.0f, mTime);
								this.transform.rotation = Quaternion.Lerp(Quaternion.Euler(rotateStartAngle),Quaternion.Euler(rotateToAngle), smoothStep);
	//							this.transform.position = new Vector3(Mathf.SmoothStep(moveStartPos.x, moveToPos.x, mTime), Mathf.SmoothStep(moveStartPos.y, moveToPos.y, mTime), Mathf.SmoothStep(moveStartPos.z, moveToPos.z, mTime));
							}
						}
						if(oneWay)
						{
							mTime += Time.deltaTime * rotateSpeed;
							if(!smoothRotate)
							{
								this.transform.rotation = Quaternion.Lerp(Quaternion.Euler(rotateToAngle),Quaternion.Euler(rotateStartAngle),mTime);
	//							this.transform.position = Vector3.Lerp(moveToPos, moveStartPos, mTime);
							}
							else
							{
								float smoothStep = Mathf.SmoothStep(0.0f, 1.0f, mTime);
								this.transform.rotation = Quaternion.Lerp(Quaternion.Euler(rotateToAngle),Quaternion.Euler(rotateStartAngle), smoothStep);
	//							this.transform.position = new Vector3(Mathf.SmoothStep(moveToPos.x, moveStartPos.x, mTime), Mathf.SmoothStep(moveToPos.y, moveStartPos.y, mTime), Mathf.SmoothStep(moveToPos.z, moveStartPos.z, mTime));
							}
							
						}
					}
				}

				yield return null;
			}
		}

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
							if(!smoothMove)
							{
								this.transform.position = Vector3.Lerp(moveStartPos, moveToPos, mTime);
							}
							else
							{
								this.transform.position = new Vector3(Mathf.SmoothStep(moveStartPos.x, moveToPos.x, mTime), Mathf.SmoothStep(moveStartPos.y, moveToPos.y, mTime), Mathf.SmoothStep(moveStartPos.z, moveToPos.z, mTime));
							}
						}
						if(oneWay)
						{
							mTime += Time.deltaTime * moveSpeed;
							if(!smoothMove)
							{
								this.transform.position = Vector3.Lerp(moveToPos, moveStartPos, mTime);
							}
							else
							{
								this.transform.position = new Vector3(Mathf.SmoothStep(moveToPos.x, moveStartPos.x, mTime), Mathf.SmoothStep(moveToPos.y, moveStartPos.y, mTime), Mathf.SmoothStep(moveToPos.z, moveStartPos.z, mTime));
							}

						}
					}
				}
				yield return null;
			}
		}
	}

	public void OnDrawGizmos()
	{
		if(transformMove)
		{
			Gizmos.color = Color.gray;
			Gizmos.DrawLine(this.transform.position, moveToPos); 
		}
		
	}


	//play on awake(no input required)
	//smooth or lerp
	//start delay
	//transform position, rotation, scale: pingpong, onetime // cranking start and end med animation curves
	//play (child) particle once or loop
	// color fade
}

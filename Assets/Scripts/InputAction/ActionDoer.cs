using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
//[ExecuteInEditMode()]  
public class ActionDoer : MonoBehaviour {
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


	//transform rotate
	[SerializeField]
	public bool transformRotate; 
	[SerializeField]
	public Vector3 rotateToAngle;
	public float rotateFloat;

	void Start () 
	{
	
	}


	void Update () 
	{

	}




	public void DoThing()
	{
		if(!doit)
		{
			doit = true;

			if(transformMove)
			{
				StartCoroutine(TransformPosition());
			}
			if(transformRotate)
			{
				StartCoroutine(TransformRoation());
			}
//			if(!playOnce)
//			{
//
//			}

		}
	}

	IEnumerator TransformRoation()
	{
		bool onOff = true;
		float mTime = 0;
//		Vector3 startRot = Quaternion.Euler(this.transform.eulerAngles);
		Quaternion startRot = Quaternion.Euler(this.transform.eulerAngles);

		while(onOff)
		{
			if(mTime < 1f)
			{
				mTime += Time.deltaTime * moveSpeed;
				this.transform.rotation = Quaternion.Lerp(startRot,Quaternion.Euler(rotateToAngle),mTime);
			}
			else
			{
				onOff = false;
			}
				yield return null;
		}

	}
	IEnumerator TransformPosition()
	{
		bool onOff = true;
		float mTime = 0f;
		Vector3 startPos = this.transform.position;

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
				if(mTime < 1f)
				{
					mTime += Time.deltaTime * moveSpeed;
					if(!smoothMove)
					{
						this.transform.position = Vector3.Lerp(startPos, moveToPos, mTime);
					}
					else
					{
						this.transform.position = new Vector3(Mathf.SmoothStep(startPos.x, moveToPos.x, mTime), Mathf.SmoothStep(startPos.y, moveToPos.y, mTime), Mathf.SmoothStep(startPos.z, moveToPos.z, mTime));
					}
				}
				else
				{
					onOff = false;

					//doit = false
				}
				yield return null;
				 
			}
		}
		if(pingPongMove)
		{
			while(onOff)
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
							this.transform.position = Vector3.Lerp(startPos, moveToPos, mTime);
						}
						else
						{
							this.transform.position = new Vector3(Mathf.SmoothStep(startPos.x, moveToPos.x, mTime), Mathf.SmoothStep(startPos.y, moveToPos.y, mTime), Mathf.SmoothStep(startPos.z, moveToPos.z, mTime));
						}
					}
					if(oneWay)
					{
						mTime += Time.deltaTime * moveSpeed;
						if(!smoothMove)
						{
							this.transform.position = Vector3.Lerp(moveToPos, startPos, mTime);
						}
						else
						{
							this.transform.position = new Vector3(Mathf.SmoothStep(moveToPos.x, startPos.x, mTime), Mathf.SmoothStep(moveToPos.y, startPos.y, mTime), Mathf.SmoothStep(moveToPos.z, startPos.z, mTime));
						}

					}
				}
				yield return null;
			}
		}
	}

	void OnDrawGizmos()
	{
//		Gizmos.DrawLine(this.transform.position, transform.forward);
//		Gizmos.DrawCube(this.transform.position,
	}


	//play on awake(no input required)
	//smooth or lerp
	//start delay
	//transform position, rotation, scale: pingpong, onetime // cranking start and end med animation curves
	//play (child) particle once or loop
	// color fade
}

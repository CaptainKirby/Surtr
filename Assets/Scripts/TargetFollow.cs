using UnityEngine;
using System.Collections;

public class TargetFollow : MonoBehaviour {

	public Transform target;

	private float curVel;
	private float curVel2;

	public float followSpeed;
	public float offsetY = 5;
	private Vector3 refPos;
	void Start () 
	{
		refPos = this.transform.position;
	}
	

	void FixedUpdate () 
	{
		refPos.x = Mathf.SmoothDamp(this.transform.position.x, target.position.x, ref curVel, Time.deltaTime * followSpeed);
		refPos.y = Mathf.SmoothDamp(this.transform.position.y, target.position.y + offsetY, ref curVel2, Time.deltaTime * followSpeed);

		transform.position = refPos;
	}
}

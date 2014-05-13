using UnityEngine;
using System.Collections;

public class RotateInfinitely : MonoBehaviour {
	public float speed = 2;
	void Start () 
	{
	
	}
	
	void Update () 
	{
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + Time.deltaTime * speed, transform.eulerAngles.z);
	}
}

using UnityEngine;
using System.Collections;

public class SimpleRotate : MonoBehaviour {

	void Start () 
	{
	
	}
	
	void Update () 
	{
		transform.Rotate(Vector3.up * Time.deltaTime * 25);
	}
}

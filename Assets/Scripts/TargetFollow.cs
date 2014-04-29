﻿using UnityEngine;
using System.Collections;

public class TargetFollow : MonoBehaviour {

	public Transform target;

	private float curVel;
	private float curVel2;

	public float followSpeed;
	public float offsetY = 5;
	private Vector3 refPos;
	public float zPos;
	private GameObject player;
	private PlayerSwitch pSwitch;
	private GameObject spirit;
	void Start () 
	{
		spirit = GameObject.Find("Spirit");
		player = GameObject.Find("Player");
		pSwitch = player.GetComponent<PlayerSwitch>();
		refPos = this.transform.position;
		zPos = refPos.z;
	}
	
	void Update()
	{
		if(!pSwitch.curState && target != player.transform)
		{
			target = player.transform;
		}
		if(pSwitch.curState && target != spirit.transform)
		{
			target = spirit.transform;
		}
	}
	void FixedUpdate () 
	{
		refPos.x = Mathf.SmoothDamp(this.transform.position.x, target.position.x, ref curVel, Time.deltaTime * followSpeed);
		refPos.y = Mathf.SmoothDamp(this.transform.position.y, target.position.y + offsetY, ref curVel2, Time.deltaTime * followSpeed);
		refPos.z = zPos;
		transform.position = refPos;
	}
}

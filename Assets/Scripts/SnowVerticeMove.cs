﻿using UnityEngine;
using System.Collections;

public class SnowVerticeMove : MonoBehaviour {

	Mesh mesh;
	Vector3[] vertices;
	Vector3[] normals;
	Vector3[] verticesStart;
	public GameObject deformTarget;
//	Collider[] overlapSphere;
	void Start () 
	{
		mesh = GetComponent<MeshFilter>().mesh;
		vertices = mesh.vertices;
		normals = mesh.normals;
		verticesStart = mesh.vertices;
	}
	
	// Update is called once per frame
	void Update () {
//		overlapSphere = Physics.OverlapSphere(deformTarget, 5.0f);
//		Vector3 posNorm = deformTarget.transform.position;
		Debug.Log (deformTarget.transform.position);
		Vector3 charPoint = this.transform.InverseTransformPoint(deformTarget.transform.position);
		for(int i = 0; i < vertices.Length; i++)
		{
			float dist = Vector3.Distance(new Vector3(vertices[i].x, vertices[i].y, vertices[i].z), charPoint);
			if(dist < 1f)
			{
				vertices[i]= verticesStart[i] - new Vector3(0,1,0);
			}
		}
		mesh.vertices = vertices;

	}
}
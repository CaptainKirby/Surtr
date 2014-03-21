﻿using UnityEngine;
using System.Collections;

public class DistanceVertexColor : MonoBehaviour {
	Mesh mesh;
	Vector3[] vertices;
	Color[] colors;
//	Color[] colorsStart;
	public Color32 closeColor;
	public Color32 farColor;
	public float minZ = 0;
	public float maxZ = 100;
	public float fadePos = 5.0f;
	public float fadeLength = 5.0f;
//	public bool useBaseColor; //fix!
	void Start () 
	{
		mesh = GetComponent<MeshFilter>().mesh;
		vertices = mesh.vertices;
		colors = new Color[vertices.Length];

	}

	void Update()
	{
		for(int i = 0; i < vertices.Length; i++)
		{
			Vector3 worldPos = this.transform.TransformPoint( vertices[i]);
			colors[i] = Color32.Lerp(closeColor, farColor, (worldPos.z - minZ - fadePos) / (maxZ-minZ) / fadeLength);
			
		}
		mesh.colors = colors;
	}

}

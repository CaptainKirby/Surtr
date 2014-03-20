using UnityEngine;
using System.Collections;

public class SnowVerticeMove : MonoBehaviour {

	Mesh mesh;
	Vector3[] vertices;
	Vector3[] normals;
	Vector3[] verticesStart;
	Color32[] colors;
	public GameObject deformTarget;
//	Collider[] overlapSphere;
	void Start () 
	{
		mesh = GetComponent<MeshFilter>().mesh;
		vertices = mesh.vertices;
		normals = mesh.normals;
		verticesStart = mesh.vertices;
		colors = new Color32[vertices.Length];
		for(int i = 0; i < colors.Length; i++)
		{
			colors[i] = Color.white;
		}
	}
	
	// Update is called once per frame
	void Update () {

//		overlapSphere = Physics.OverlapSphere(deformTarget, 5.0f);
//		Vector3 posNorm = deformTarget.transform.position;
		Debug.Log (deformTarget.transform.position);
		Vector3 charPoint = this.transform.InverseTransformPoint(deformTarget.transform.position);
		for(int i = 0; i < vertices.Length; i++)
		{
			float curVel = 0;
			float dist = Vector3.Distance(new Vector3(vertices[i].x, vertices[i].y, vertices[i].z), charPoint);
			if(dist < 0.5f)
			{
				vertices[i]= new Vector3(verticesStart[i].x,Mathf.SmoothDamp(vertices[i].y, dist + 0.5f, ref curVel, 0.1f),verticesStart[i].z);
//				colors[i] = new Color(200,100,100);
			}
//			if(dist > 0.7f && dist < 0.8f)
//			{
//				if(vertices[i].y > 0.6f)
//				{
//				vertices[i]= new Vector3(verticesStart[i].x,Mathf.SmoothDamp(vertices[i].y, verticesStart[i].y + 0.1f, ref curVel, 0.03f),verticesStart[i].z);
//				}
//
//			}
		}
//		mesh.colors32 = colors;
		mesh.vertices = vertices;

	}

//	void MoveVertice(Mesh
}

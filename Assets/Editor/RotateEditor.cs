using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(Rotate))] 
public class RotateEditor : Editor {

	public Rotate rotate;
	public override void OnInspectorGUI() 
	{
		rotate = (Rotate)target;

//		rotate.transformrotate = EditorGUILayout.ToggleLeft(" Transform rotate", rotate.transformrotate);
//		if(rotate.transformrotate)
//		{
//			SceneView.RepaintAll(); 
		rotate.playOnAwake = EditorGUILayout.ToggleLeft("Play on awake", rotate.playOnAwake);
			rotate.pauseable = EditorGUILayout.ToggleLeft("Pauseable", rotate.pauseable);
			//			rotate.resetrotate = EditorGUILayout.ToggleLeft(" Reset", rotate.resetrotate);
			rotate.pingPongRotate = EditorGUILayout.ToggleLeft(" Ping Pong", rotate.pingPongRotate);
			rotate.smoothRotate= EditorGUILayout.ToggleLeft(" Smooth rotate", rotate.smoothRotate);
			rotate.rotateStartDelay = EditorGUILayout.ToggleLeft(" Start Delay", rotate.rotateStartDelay);
			if(rotate.rotateStartDelay) 
			{
				rotate.rotateStartDelayTime = EditorGUILayout.FloatField("Start Delay Duration: ", rotate.rotateStartDelayTime);
			}
			rotate.rotateInbetweenDelay= EditorGUILayout.ToggleLeft(" Inbetween Delay ", rotate.rotateInbetweenDelay);
			if(rotate.rotateInbetweenDelay)
			{
				rotate.rotateInbetweenDelayTime = EditorGUILayout.FloatField("Inbetween Delay Duration: ", rotate.rotateInbetweenDelayTime);
			}
			rotate.rotateSpeed = EditorGUILayout.FloatField("rotate Speed: ", rotate.rotateSpeed);
			
			EditorGUILayout.Vector3Field("Start from vector3:", rotate.rotateStartAngle);
			
			EditorGUILayout.Vector3Field("rotate to vector3:", rotate.rotateToAngle);
			
			Rect r = EditorGUILayout.BeginVertical();
			
			if(GUI.Button(new Rect(r.x, r.y, 120,15),"Set start rotation"))
			{
				rotate.rotateStartAngle = rotate.gameObject.transform.rotation.eulerAngles;
			}
			if(GUI.Button(new Rect(r.x + 125, r.y, 150,15),"rotate to start rotation"))
			{
				rotate.gameObject.transform.rotation = Quaternion.Euler(rotate.rotateStartAngle);
			}
			if(GUI.Button(new Rect(r.x + 280, r.y, 50,15),"Reset"))
			{
				rotate.rotateStartAngle = new Vector3(0,0,0);
			}
			
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			EditorGUILayout.EndVertical();
			
			EditorGUILayout.Space();
			
			Rect r2 = EditorGUILayout.BeginVertical();
			
			if(GUI.Button(new Rect(r2.x, r2.y, 120,15),"Set end rotation"))
			{
				rotate.rotateToAngle = rotate.gameObject.transform.rotation.eulerAngles;
			}
			if(GUI.Button(new Rect(r2.x + 125, r2.y, 150,15),"rotate to end rotation"))
			{
				rotate.gameObject.transform.rotation = Quaternion.Euler(rotate.rotateToAngle);
			}
			if(GUI.Button(new Rect(r2.x + 280, r2.y, 50,15),"Reset"))
			{
				rotate.rotateToAngle = new Vector3(0,0,0);
			}
			
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			EditorGUILayout.EndVertical();
			
			
			EditorGUILayout.Space();
			GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));   
			EditorGUILayout.Space();
			
//		}
	}
}

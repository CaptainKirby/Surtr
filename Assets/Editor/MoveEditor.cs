using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(Move))] 
public class MoveEditor : Editor {

	public Move move;
	public override void OnInspectorGUI() 
	{
		move = (Move)target;

//		move.transformMove = EditorGUILayout.ToggleLeft(" Transform move", move.transformMove);
//		if(move.transformMove)
//		{
//			SceneView.RepaintAll(); 
			move.pauseable = EditorGUILayout.ToggleLeft("Pauseable", move.pauseable);
			move.moveBack = EditorGUILayout.ToggleLeft("Move Back", move.moveBack);
			//			move.resetMove = EditorGUILayout.ToggleLeft(" Reset", move.resetMove);
			move.pingPongMove= EditorGUILayout.ToggleLeft(" Ping Pong", move.pingPongMove);
			move.smoothMove= EditorGUILayout.ToggleLeft(" Smooth Move", move.smoothMove);
			move.moveStartDelay = EditorGUILayout.ToggleLeft(" Start Delay", move.moveStartDelay);
//			move.onOff = EditorGUILayout.ToggleLeft("gbeug", move.onOff);
			
			if(move.moveStartDelay) 
			{
				move.moveStartDelayTime = EditorGUILayout.FloatField("Start Delay Duration: ", move.moveStartDelayTime);
			}
			move.moveInbetweenDelay= EditorGUILayout.ToggleLeft(" Inbetween Delay ", move.moveInbetweenDelay);
			if(move.moveInbetweenDelay)
			{
				move.moveInbetweenDelayTime = EditorGUILayout.FloatField("Inbetween Delay Duration: ", move.moveInbetweenDelayTime);
			}
			move.moveSpeed = EditorGUILayout.FloatField("Move Speed: ", move.moveSpeed);
			
			EditorGUILayout.Vector3Field("Start from vector3:", move.moveStartPos);
			
			EditorGUILayout.Vector3Field("Move to vector3:", move.moveToPos);
			
			Rect r = EditorGUILayout.BeginVertical();
			
			if(GUI.Button(new Rect(r.x, r.y, 120,15),"Set start position"))
			{
				move.moveStartPos = move.gameObject.transform.position;
			}
			if(GUI.Button(new Rect(r.x + 125, r.y, 150,15),"Move to start position"))
			{
				move.gameObject.transform.position = move.moveStartPos;
			}
			if(GUI.Button(new Rect(r.x + 280, r.y, 50,15),"Reset"))
			{
				move.moveStartPos = new Vector3(0,0,0);
			}
			
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			EditorGUILayout.EndVertical();
			
			EditorGUILayout.Space();
			
			Rect r2 = EditorGUILayout.BeginVertical();
			
			if(GUI.Button(new Rect(r2.x, r2.y, 120,15),"Set end position"))
			{
				move.moveToPos = move.gameObject.transform.position;
			}
			if(GUI.Button(new Rect(r2.x + 125, r2.y, 150,15),"Move to end position"))
			{
				move.gameObject.transform.position = move.moveToPos;
			}
			if(GUI.Button(new Rect(r2.x + 280, r2.y, 50,15),"Reset"))
			{
				move.moveToPos = new Vector3(0,0,0);
			}
			
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			EditorGUILayout.EndVertical();
			EditorGUILayout.Space();
			move.animCurveUse = EditorGUILayout.ToggleLeft("Use Animation Curve", move.animCurveUse);
			if(move.animCurveUse)
			{	
//				move.animCurve = AnimationCurve.Linear(0,0,1,1);
				EditorGUILayout.CurveField(move.animCurve);
			}
			EditorGUILayout.Space();
			GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));   
			EditorGUILayout.Space();
			
//		}
	}
}

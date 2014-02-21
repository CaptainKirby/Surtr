// MyScriptEditor.cs
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(InputTaker))] 
[System.Serializable]
[InitializeOnLoad]
public class InputTakerEditor : Editor {

//	public delegate void ObjectTarget(GameObject gObj);
//	public Object thisObj;
	public delegate void OnAction(GameObject target);
	public static event OnAction OnClicked;
	public GameObject curObj;

	public static GameObject attatchedObj;
	public static List<GameObject> attatchedObjs;
	public static InputTaker inputTaker;

	public bool toggle;
	static InputTakerEditor()
	{
		ActionDoerEditor.OnClickedBack += Reciever;
	}

	public override void OnInspectorGUI() {
		inputTaker = (InputTaker)target;
		inputTaker.inputType = (InputTaker.InputType)EditorGUILayout.EnumPopup(inputTaker.inputType);

		if(inputTaker.attatchedObjs.Count > 0)
		{
			for(int i = 0;i<inputTaker.attatchedObjs.Count;++i) 
			{
				inputTaker.attatchedObjs[i] = (GameObject)EditorGUILayout.ObjectField(inputTaker.attatchedObjs[i], typeof(GameObject), true);
			}
		}
		
//		if(attatchedObj != null)
//		{
//			EditorGUILayout.BeginHorizontal();
//			inputTaker.attatchedObj = (GameObject)EditorGUILayout.ObjectField(inputTaker.attatchedObj, typeof(GameObject), true);
//			EditorGUILayout.EndHorizontal();
//		}

		curObj = Selection.activeGameObject;

		if(GUILayout.Button("Broadcast"))
		{
			if(OnClicked != null)
			OnClicked(curObj); 
			SceneView.RepaintAll();
//			Debug.Log ();
		}

		toggle = EditorGUILayout.Toggle(toggle);
	}

	static public void Reciever(GameObject target)
	{
//		attatchedObjs.Add(target);
		if(!inputTaker.attatchedObjs.Contains(target))
		{
			inputTaker.attatchedObjs.Add(target);
		}

//		attatchedObj = target;
//		inputTaker.attatchedObj = attatchedObj;
//		Debug.Log (attatchedObj.name + "yolo");
		
	}

	



}
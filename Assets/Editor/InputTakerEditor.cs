// MyScriptEditor.cs
using UnityEditor;
using UnityEngine;
using System.Collections;

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
	public static InputTaker inputTaker;


	static InputTakerEditor()
	{
		ActionDoerEditor.OnClickedBack += Reciever;
	}

	public override void OnInspectorGUI() {
		inputTaker = (InputTaker)target;
		inputTaker.inputType = (InputTaker.InputType)EditorGUILayout.EnumPopup(inputTaker.inputType);

		if(attatchedObj != null)
		{
			EditorGUILayout.BeginHorizontal();
			inputTaker.attatchedObj = (GameObject)EditorGUILayout.ObjectField(inputTaker.attatchedObj, typeof(GameObject), true);
			EditorGUILayout.EndHorizontal();
		}

		curObj = Selection.activeGameObject;

		if(GUILayout.Button("Broadcast"))
		{
			if(OnClicked != null)
			OnClicked(curObj); 
//			Debug.Log ();
		}
	}

	static public void Reciever(GameObject target)
	{
		attatchedObj = target;
		inputTaker.attatchedObj = attatchedObj;
		Debug.Log (attatchedObj.name + "yolo");
		
	}

	



}
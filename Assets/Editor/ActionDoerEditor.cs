// MyScriptEditor.cs
using UnityEditor;
using UnityEngine;
using System.Collections;

[InitializeOnLoad]
[CustomEditor(typeof(ActionDoer))] 
[System.SerializableAttribute]
public class ActionDoerEditor : Editor {

	public delegate void OnActionBack(GameObject target);
	public static event OnActionBack OnClickedBack;
	public GameObject curObj;

	[SerializeField]
	static public GameObject attatchedObj;
	[SerializeField]
	private string name;
	private string test;
	static ActionDoerEditor()
	{
		Debug.Log ("Up and running");
		InputTakerEditor.OnClicked += Reciever;

	}

	public override void OnInspectorGUI() {
		ActionDoer actionDoer = (ActionDoer)target;
//		inputTaker.inputType = (InputTaker.InputType)EditorGUILayout.EnumPopup(inputTaker.inputType);
//		on = EditorGUILayout.Toggle(on);
//		test = EditorGUILayout.SelectableLabel(test
		if(attatchedObj != null)
		{
			EditorGUILayout.BeginHorizontal();
			actionDoer.attatchedObj = (GameObject)EditorGUILayout.ObjectField(actionDoer.attatchedObj, typeof(GameObject), true);
			EditorGUILayout.EndHorizontal();
		}
		curObj = Selection.activeGameObject;


		if(attatchedObj == null)
		{
//			Debug.Log ("WHAT");
//			attatchedObj = actionDoer.attatchedObj;
		}

		EditorGUILayout.HelpBox(name,MessageType.None);

		if(GUILayout.Button("Recieve"))
		{
			if(actionDoer.attatchedObj.GetComponent<InputTaker>().attatchedObjs.Contains(actionDoer.gameObject))
			{
				actionDoer.attatchedObj.GetComponent<InputTaker>().attatchedObjs.Remove(actionDoer.gameObject);
				SceneView.RepaintAll();
			}
			actionDoer.attatchedObj = attatchedObj;
			OnClickedBack(curObj); 
			SceneView.RepaintAll();

		}

//		if(GUILayout.Button("Remove From Input"))
//		{
//			if(actionDoer.attatchedObj.GetComponent<InputTaker>().attatchedObjs.Contains(actionDoer.gameObject))
//			{
//				actionDoer.attatchedObj.GetComponent<InputTaker>().attatchedObjs.Remove(actionDoer.gameObject);
//				SceneView.RepaintAll();
//			}
//			
//		}

		if(GUILayout.Button("Remove Connection"))
		{
//			actionDoer.attatchedObj = null;
			if(actionDoer.attatchedObj.GetComponent<InputTaker>().attatchedObjs.Contains(actionDoer.gameObject))
			{
				actionDoer.attatchedObj.GetComponent<InputTaker>().attatchedObjs.Remove(actionDoer.gameObject);
			}
			SceneView.RepaintAll();
		}

	}

	static public void Reciever(GameObject target)
	{
		attatchedObj = target;
		Debug.Log (attatchedObj.name + "yolo");
		 
	}



}
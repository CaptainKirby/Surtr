// MyScriptEditor.cs
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(InputTaker))] 
[System.Serializable]
[InitializeOnLoad]
public class InputTakerEditor : Editor {
//	[System.Serializable]
//	public delegate void ObjectTarget(GameObject gObj);
//	public Object thisObj;
	public delegate void OnAction(GameObject target);
	public static event OnAction OnClicked;

	public delegate void OnActionDelete(GameObject targett);
	public static event OnActionDelete OnClickedDelete;
	public GameObject curObj;

	public static GameObject attatchedObj;
	[SerializeField]
	public static List<GameObject> attatchedObjs;
	[SerializeField]
	public static InputTaker inputTaker;

	public bool toggle;
	private static GameObject toDelete;
	private static bool delete;
	static InputTakerEditor()
	{
		ActionDoerEditor.OnClickedBack += Reciever;
		ActionDoerEditor.OnClickedBackDelete += Remover;
//		inputTaker = (InputTaker)target;
	}

	public override void OnInspectorGUI() {
		inputTaker = (InputTaker)target;
		inputTaker.inputType = (InputTaker.InputType)EditorGUILayout.EnumPopup(inputTaker.inputType);

		if(inputTaker.attatchedObjs.Count > 0)
		{
			if(delete)
			{
				inputTaker.attatchedObjs.Remove (toDelete);
				delete = false;

			}
			for(int i = 0;i<inputTaker.attatchedObjs.Count;++i) 
			{

//				inputTaker.attatchedObjs[i].rect = EditorGUI.RectField(new	Rect(3,25+45*i,position.width - 6, 25),
//				                                                       inputTaker.attatchedObjs[i].name,
//				                                                       inputTaker.attatchedObjs[i].rect);
//				EditorGUILayout.BeginVertical();
//				inputTaker.attatchedObjs[i] = (GameObject)EditorGUILayout.ObjectField(inputTaker.attatchedObjs[i], typeof(GameObject), true);
//				inputTaker.attatchedObjs[i] = (GameObject)EditorGUI.ObjectField(r, inputTaker.attatchedObjs[i], typeof(GameObject), true);
				Rect r = EditorGUILayout.BeginVertical();
				GUILayout.Label(inputTaker.attatchedObjs[i].name);
//				GUILayout.Label(inputTaker.attatchedObjs[i].name + "lala");
				if(GUI.Button(new Rect(r.x + 150, r.y, 150,15), "delete " + inputTaker.attatchedObjs[i].name))
				{
					OnClickedDelete(inputTaker.gameObject); 
					inputTaker.attatchedObjs.Remove(inputTaker.attatchedObjs[i]);
					inputTaker.actionDoers.Remove(inputTaker.attatchedObjs[i].GetComponent<ActionHandler>());
					SceneView.RepaintAll();
				}

				EditorGUILayout.EndVertical();
//				if(GUI.Button (r, "del"))
//				{
//
////					inputTaker.attatchedObjs.Remove[i];
//				}
//				EditorGUILayout.EndVertical();
			}
		}
		if(inputTaker.inputType == InputTaker.InputType.clickInput)
		{
//			inputTaker.clickedButton = EditorGUILayout.TextField(inputTaker.clickedButton);
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
		if(GUILayout.Button("Remove All"))
		{
			inputTaker.attatchedObjs.Clear();
			SceneView.RepaintAll();
		}

//		toggle = EditorGUILayout.Toggle(toggle);
	}

	static public void Reciever(GameObject target)
	{
//		attatchedObjs.Add(target);
		if(!inputTaker.attatchedObjs.Contains(target))
		{
			inputTaker.attatchedObjs.Add(target);
		}
//		

//		attatchedObj = target;
//		inputTaker.attatchedObj = attatchedObj;
//		Debug.Log (attatchedObj.name + "yolo");
		
	}

	static public void Remover(GameObject targett)
	{
		Debug.Log (targett);
		if(inputTaker.attatchedObjs.Contains(targett))
		{
			inputTaker.attatchedObjs.Remove(targett);
		}
	}



	



}
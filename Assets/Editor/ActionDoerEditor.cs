// MyScriptEditor.cs
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[InitializeOnLoad]
[CustomEditor(typeof(ActionDoer))] 
[System.SerializableAttribute]
public class ActionDoerEditor : Editor {

	public delegate void OnActionBack(GameObject target);
	public static event OnActionBack OnClickedBack;

	public delegate void OnActionBackDelete(GameObject targett);
	public static event OnActionBackDelete OnClickedBackDelete;
	public GameObject curObj;

	[SerializeField]
	static public GameObject attatchedObj;
	[SerializeField]
	static public List<GameObject> attatchedObjs = new List<GameObject>();
	[SerializeField]
	static public GameObject[] attatchedObjs2;
	[SerializeField]
	private string name;
	private string test;
	public static ActionDoer actionDoer;
	static ActionDoerEditor()
	{
		Debug.Log ("Up and running");
		InputTakerEditor.OnClicked += Reciever;
		InputTakerEditor.OnClickedDelete += Remover;

	}

	public override void OnInspectorGUI() {
		 actionDoer = (ActionDoer)target;
//		inputTaker.inputType = (InputTaker.InputType)EditorGUILayout.EnumPopup(inputTaker.inputType);
//		on = EditorGUILayout.Toggle(on);
//		test = EditorGUILayout.SelectableLabel(test
//		EditorGUILayout.HelpBox("test",MessageType.None);
//		EditorGUILayout.LabelField("Input connections: " + attatchedObjs.Count);
		if(actionDoer.attatchedObjs.Count > 0)
		{
			for(int i = 0;i<actionDoer.attatchedObjs.Count;++i) 
			{
			
				Rect r = EditorGUILayout.BeginVertical();
				GUILayout.Label(actionDoer.attatchedObjs[i].name);
//				actionDoer.attatchedObjs[i] = (GameObject)EditorGUILayout.ObjectField(actionDoer.attatchedObjs[i], typeof(GameObject), true);
				//				GUILayout.Label(inputTaker.attatchedObjs[i].name + "lala");
				if(GUI.Button(new Rect(r.x + 150, r.y, 150,15), "delete " + actionDoer.attatchedObjs[i].name))
				{
					OnClickedBackDelete(actionDoer.gameObject); 

					actionDoer.attatchedObjs.Remove(actionDoer.attatchedObjs[i]);

					SceneView.RepaintAll();
				}
				
				EditorGUILayout.EndVertical();

			}
		}




//		if(attatchedObj != null)
//		{
//			EditorGUILayout.BeginHorizontal();
//			actionDoer.attatchedObj = (GameObject)EditorGUILayout.ObjectField(actionDoer.attatchedObj, typeof(GameObject), true);
//			EditorGUILayout.EndHorizontal();
//		}
		curObj = Selection.activeGameObject;




		if(attatchedObj == null)
		{
//			Debug.Log ("WHAT");
//			attatchedObj = actionDoer.attatchedObj;
		}



		if(GUILayout.Button("Recieve"))
		{
//			if(actionDoer.attatchedObj.GetComponent<InputTaker>().attatchedObjs.Contains(actionDoer.gameObject))
//			{
//				actionDoer.attatchedObj.GetComponent<InputTaker>().attatchedObjs.Remove(actionDoer.gameObject);
//				SceneView.RepaintAll();
//			}
			for(int i = 0;i<attatchedObjs.Count;i++)
			{
				if(!actionDoer.attatchedObjs.Contains(attatchedObjs[i]))
				{
					actionDoer.attatchedObjs.Add(attatchedObjs[i]);
				}
			}
			actionDoer.attatchedObj = attatchedObj;
			OnClickedBack(curObj); 
			attatchedObjs.Clear();
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
		attatchedObjs.Clear();
		if(!attatchedObjs.Contains(target))
		{
			attatchedObjs.Add(target);
		}
//		Debug.Log (attatchedObjs2.ToString());
		attatchedObj = target;
		Debug.Log (attatchedObj.name + "yolo");		 
	}

	static public void Remover(GameObject targett)
	{
		Debug.Log (targett);
		if(actionDoer.attatchedObjs.Contains(targett))
		{
//			Debug.Log ("REMOVE"); 
			
			actionDoer.attatchedObjs.Remove(targett);
		}
	}



}
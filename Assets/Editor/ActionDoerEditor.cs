// MyScriptEditor.cs
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[InitializeOnLoad]
[CustomEditor(typeof(ActionDoer))] 
[System.SerializableAttribute]
public class ActionDoerEditor : Editor {
//	[System.Serializable]
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
	[SerializeField]
	public static ActionDoer actionDoer;


	//handlers

	static ActionDoerEditor()
	{
		Debug.Log ("Up and running");
		InputTakerEditor.OnClicked += Reciever;
		InputTakerEditor.OnClickedDelete += Remover;

	}

	public override void OnInspectorGUI() {
		actionDoer = (ActionDoer)target;
		curObj = Selection.activeGameObject;
		actionDoer.takeInput = EditorGUILayout.ToggleLeft(" Recieve input?", actionDoer.takeInput);
//		inputTaker.inputType = (InputTaker.InputType)EditorGUILayout.EnumPopup(inputTaker.inputType);
//		on = EditorGUILayout.Toggle(on);
//		test = EditorGUILayout.SelectableLabel(test
//		EditorGUILayout.HelpBox("test",MessageType.None);
//		EditorGUILayout.LabelField("Input connections: " + attatchedObjs.Count);
		if(actionDoer.takeInput)
		{
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


			if(GUILayout.Button("Recieve"))
			{

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
			if(GUILayout.Button("Remove Connection"))
			{
				if(actionDoer.attatchedObj.GetComponent<InputTaker>().attatchedObjs.Contains(actionDoer.gameObject))
				{
					actionDoer.attatchedObj.GetComponent<InputTaker>().attatchedObjs.Remove(actionDoer.gameObject);
				}
				SceneView.RepaintAll();
			}

		}


		EditorGUILayout.Space();
		GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
		EditorGUILayout.Space();




		//transform position
		actionDoer.transformMove = EditorGUILayout.ToggleLeft(" Transform move", actionDoer.transformMove);
		if(actionDoer.transformMove)
		{
			SceneView.RepaintAll(); 
			actionDoer.resetMove = EditorGUILayout.ToggleLeft(" Reset", actionDoer.resetMove);
			if(actionDoer.resetMove)
			{
				actionDoer.moveToPos = new Vector3(actionDoer.gameObject.transform.position.x,actionDoer.gameObject.transform.position.y, actionDoer.gameObject.transform.position.z);
				actionDoer.resetMove = false;
			}
			EditorGUILayout.Vector3Field("Move to vector3:", actionDoer.moveToPos);

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

	public void OnSceneGUI () {
		if(actionDoer.transformMove)
		{
			Handles.color = Color.red;
			Handles.DrawLine(actionDoer.transform.position, actionDoer.moveToPos);
			actionDoer.moveToPos = Handles.PositionHandle(actionDoer.moveToPos, Quaternion.identity);
//			actionDoer.moveToPos = Handles.FreeMoveHandle(actionDoer.moveToPos, Quaternion.identity, 1, Vector3.zero, Handles.DrawRectangle);
		}
	}


}
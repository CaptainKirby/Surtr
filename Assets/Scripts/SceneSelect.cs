using UnityEngine;
using System.Collections;

public class SceneSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(GUILayout.Button("House Scene"))
		{
			Application.LoadLevel("House");
		}
		if(GUILayout.Button("Outside House Scene"))
		{
			Application.LoadLevel("test_convert");
		}
		if(GUILayout.Button("Boat Scene"))
		{
			Application.LoadLevel("boat");
		}
		if(GUILayout.Button("Runestone Scene"))
		{
			Application.LoadLevel("Cave");
		}
	}
}

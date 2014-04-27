using UnityEngine;
using System.Collections;

public class Screenshots : MonoBehaviour {
	void Update() {
		if(Input.GetKeyDown(KeyCode.P))
		{
			Application.CaptureScreenshot("Assets/Screenshots/Screenshot.png", 4);
		}
	}
}
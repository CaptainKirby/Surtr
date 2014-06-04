using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	private ActionHandler actionHandler;
	private AudioSource aSource;
	public float duration;
	void Start () {
		aSource = GetComponent<AudioSource>();
		if(duration == 0)
		{
			duration = aSource.clip.length;
		}
		actionHandler =  GetComponent<ActionHandler>();
		if(actionHandler)
		{
			actionHandler.TakeAction += PlayClip;
		}
		aSource.volume = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PlayClip(GameObject gObj, bool stop)
	{
		StartCoroutine("PlayClipCR");
	}

	IEnumerator PlayClipCR()
	{
//		SoundManager
		aSource.volume = 1;
		aSource.Play ();
		yield return new WaitForSeconds(duration);
		aSource.Stop();
	}
}

using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

	public float volume;
	// Use this for initialization
	void Start () {
		SoundManager.SetVolumeMusic(volume);
	}
	
	// Update is called once per frame
	void Update () {

	}
}

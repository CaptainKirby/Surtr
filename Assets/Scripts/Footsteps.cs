using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {

	private PlayerMovement pMove;


	private AudioClip[] snowSteps;
	private AudioClip[] woodSteps;
	private AudioClip[] stoneSteps;

	void Start () 
	{
		pMove = GameObject.FindObjectOfType<PlayerMovement>();
		snowSteps = SoundManager.LoadAllFromGroup("Snowsteps");
		woodSteps = SoundManager.LoadAllFromGroup("Woodsteps");
		stoneSteps = SoundManager.LoadAllFromGroup("Stonesteps");


	}
	

	void Update () {
	
	}

	void Footstep()
	{
		if(pMove.onSnow)
		{
			SoundManager.PlaySFX(Camera.main.gameObject, snowSteps[Random.Range(0, snowSteps.Length)], false, 0, 0.05f);
		}
		if(pMove.onStone)
		{
			SoundManager.PlaySFX(Camera.main.gameObject,stoneSteps[Random.Range(0, stoneSteps.Length)], false, 0, 0.1f);
		}
		if(pMove.onWood)
		{
			SoundManager.PlaySFX(Camera.main.gameObject,woodSteps[Random.Range(0, woodSteps.Length)], false, 0, 0.1f);
		}
//		laySFX(AudioClip clip, float volume, float pitch)

	}
}

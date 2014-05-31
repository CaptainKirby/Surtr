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
			SoundManager.PlaySFX(snowSteps[Random.Range(0, snowSteps.Length)]);
		}
		if(pMove.onStone)
		{
			SoundManager.PlaySFX(stoneSteps[Random.Range(0, stoneSteps.Length)]);
		}
		if(pMove.onWood)
		{
			SoundManager.PlaySFX(woodSteps[Random.Range(0, woodSteps.Length)]);
		}
//		laySFX(AudioClip clip, float volume, float pitch)

	}
}

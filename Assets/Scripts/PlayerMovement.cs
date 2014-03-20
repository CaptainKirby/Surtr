using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[HideInInspector]
	public bool activeMovement = true;
	private CharacterMotor motor;

	void Start () 
	{
		activeMovement = true;
		motor = GetComponent<CharacterMotor>();

	}
	

	void Update () 
	{

		// til hoppet skal jeg finde input dir retning(venstre el. højre).
		// i meget kort tid skal jeg checke om hop knappen er hold inde i kort eller længere tid for at finde ud af hvor langt hopet skal være(ddete skal ske undervejs i hoppet)
		// der skal være en smule styring iblandet kraften fra hoppet

		if(activeMovement)
		{
			motor.inputMoveDirection = Vector3.right * Input.GetAxis("Horizontal");
			motor.inputJump = Input.GetKey(KeyCode.JoystickButton0);

		}
		else
		{
			motor.inputMoveDirection = Vector3.zero;
		}


	}
	
}
		




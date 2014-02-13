using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//input to movement stuffs
//	private Vector3 inputDir;
//	private float speed;
//	public float accel = 1f;
//	public float drag = 1f;
//	public float movementMax = 1f;
//	private float moveMaxStart;
//
//	//grounded?
//	public bool grounded;	
//	public float groundedCheckRange = 0.5f;
//
//	//gravity && jump
//	public float gravity = 0f;
//	public float gravityForce = 6f;
//	public float jumpForce = 0;
//	private float jumpPower;
//	public bool jumpKeyDown;
//	private KeyCode jumpKey = KeyCode.Space;
//	private KeyCode jumpKey2 = KeyCode.Joystick1Button0;
//	private bool jumping;
//	public float jumpMaxDuration = 0.3f;
//	public  float jumpSlow;
//	//onetime coRoutine
//	private bool oneTimeCoR;
	private CharacterMotor motor;
	void Start () 
	{
//		moveMaxStart = movementMax;
		motor = GetComponent<CharacterMotor>();
	}
	

	void Update () 
	{

		// til hoppet skal jeg finde input dir retning(venstre el. højre).
		// i meget kort tid skal jeg checke om hop knappen er hold inde i kort eller længere tid for at finde ud af hvor langt hopet skal være(ddete skal ske undervejs i hoppet)
		// der skal være en smule styring iblandet kraften fra hoppet
		motor.inputMoveDirection = Vector3.right * Input.GetAxis("Horizontal");
		motor.inputJump = Input.GetKey(KeyCode.Joystick1Button0);


	}

	void FixedUpdate()
	{


	}
}
		




using UnityEngine;
using System.Collections;

public class SpiritMovement : MonoBehaviour {
	
	//input to movement stuffs
	private Vector3 inputDir;
	public float speed = 5;
	public float movementMax = 1f;
	private float moveMaxStart;
	
	//grounded?
	public bool grounded;	
	public float groundedCheckRange = 0.5f;
	
	//gravity && jump
	public float gravity = 0f;
	public float gravityForce = 6f;
	public float jumpForce = 0;
	private float jumpPower;
	public bool jumpKeyDown;
	private KeyCode jumpKey = KeyCode.Space;
	private KeyCode jumpKey2 = KeyCode.Joystick1Button0;
	private bool jumping;
	public float jumpMaxDuration = 0.3f;
	public  float jumpSlow;
	private bool jumpReleased = true;


	private Quaternion rightRot;
	private Quaternion leftRot;
	//onetime coRoutine
	private bool oneTimeCoR;
	private int dirIndicator = 1;
	public float diluteInput = 6;

	[HideInInspector]
	public bool activeMovement;
	void Start () 
	{
		activeMovement = true;
		rightRot = Quaternion.Euler(0,-90,0);
		leftRot = Quaternion.Euler(0,90,0);
		jumpSlow = movementMax;
		moveMaxStart = movementMax;
		gravity = gravityForce;
	}
	
	
	void Update () 
	{
		
		// til hoppet skal jeg finde input dir retning(venstre el. højre).
		// i meget kort tid skal jeg checke om hop knappen er hold inde i kort eller længere tid for at finde ud af hvor langt hopet skal være(ddete skal ske undervejs i hoppet)
		// der skal være en smule styring iblandet kraften fra hoppet
		if(activeMovement)
		{
			if(!grounded)
			{
				gravity = gravityForce;
			}
			else
			{
				gravity = 0;
			}
			
			grounded = IsGrounded();
			inputDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
	//		inputDir = inputDir.normalized;
			
			if(Input.GetKey(jumpKey2) && !jumpKeyDown && grounded && jumpReleased)
			{
				jumpReleased = false;
				jumpKeyDown = true;
			}
			if(!Input.GetKey(jumpKey2))
			{
				jumpKeyDown = false;
				jumping = false;
			}

			if(Input.GetKeyUp(jumpKey2))
			{
				jumpReleased = true;
			}
			
			if(!oneTimeCoR && jumpKeyDown)
			{
				StartCoroutine(Jump ());
			}
			
			if(jumping)
			{
				jumpPower = jumpForce;
				movementMax = jumpSlow;
			}
			else
			{
				movementMax = moveMaxStart;
				if(jumpPower > 0 && !grounded)
				{
					jumpPower -= Time.deltaTime * 20;
				}
				else
				{
					jumpPower = 0;
				}

				
			}

			if(inputDir.x > 0)
			{
				dirIndicator = 1;
			}
			if(inputDir.x < 0)
			{
				dirIndicator = -1;
			}
		}
		
	}
	
	void FixedUpdate()
	{
		if(activeMovement)
		{
			rigidbody.AddForce(new Vector3(inputDir.x * speed, -gravity, 0), ForceMode.VelocityChange);

			rigidbody.AddForce(new Vector3(0, jumpPower,0), ForceMode.Impulse);

			if(rigidbody.velocity.y < 0)
			{
				//falling
				rigidbody.AddForce(new Vector3(0, inputDir.y/diluteInput,0), ForceMode.VelocityChange);
			}
		}

	}

	IEnumerator Jump()
	{
		oneTimeCoR = true;
		jumping = true;
		yield return new WaitForSeconds(jumpMaxDuration);
		jumpKeyDown = false;
		oneTimeCoR = false;
		jumping = false;
	}
	
	bool IsGrounded()
	{
		return  Physics.Raycast(transform.position, -Vector3.up,groundedCheckRange);
	}
}

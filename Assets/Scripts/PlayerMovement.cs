using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

//	[HideInInspector]
	public bool activeMovement = true;
	private CharacterMotor motor;
	public float pushPower = 2.0f;
	public float weight = 6.0f;

	public bool movingLeft;
	public bool movingRight;
	public bool idle;
	private bool movedRight;
	private bool movedLeft;

	private bool sprinting;
	public float sprintSpeed = 5;
	private float sprintValue= 1;
	public Transform charGfx;
	private Animator charAnim;
	public bool spiritActive;
	public bool jumping;
	public bool inSpirit;
	private FloatChar floatC;
	private ParticleSystem snowPF;
	private bool snowAtFeet;
	[HideInInspector]
	public bool onSnow;
	[HideInInspector]
	public bool onStone;
	[HideInInspector]
	public bool onWood;

	public bool startSitting;
	public bool startSittingHouse;
	private bool sitting;
	private bool inStorm;
	public Vector3 prevGroundedPos;
	private PlayerSwitch pSwitch;
	public bool fallingDeath;

	private bool dieWhenGrounded;
	public bool dead;
	private GameObject whiteFade;

	private float movementSpeed;
	private bool sittingHouse;
	private bool canSprint = false;
	void Start () 
	{	
		canSprint = false;
		foreach (AudioListener o in FindObjectsOfType<AudioListener>())
			Debug.Log(o.name, o);


		whiteFade = GameObject.Find("WhiteFade");
		pSwitch = GameObject.FindObjectOfType<PlayerSwitch>();
//		inStorm = true;
		if(startSitting)
		{
			sitting = true;
		}
		if(startSittingHouse)
		{
			sittingHouse = true;
		}
		floatC = GetComponent<FloatChar>();
		charAnim = GetComponentInChildren<Animator>(); 
		charGfx = transform.GetChild(0);
		activeMovement = true;
		motor = GetComponent<CharacterMotor>();
		snowPF = GetComponentInChildren<ParticleSystem>();
		snowPF.enableEmission = false;
		snowAtFeet = false;
		if(pSwitch.canGoSpirit)
		{
			StartCoroutine("StepUpdate");
		}

	}
	
	IEnumerator StepUpdate()
	{
		while(true)
		{
			yield return new WaitForSeconds(2f);
//			StartCoroutine("SavePos");
			if(motor.grounded && !dieWhenGrounded && Mathf.Abs(motor.movement.velocity.y) < 1f)
			{
				prevGroundedPos = this.transform.position;
				
			}
		}
	}

	IEnumerator SavePos()
	{
		while(true)
		{



			yield return new WaitForSeconds(3);
		}
	}

	void OnTriggerStay(Collider col)
	{
		if(col.CompareTag("Storm"))
		{
			inStorm= true;
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(col.CompareTag("Storm"))
		{
			inStorm = false;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("Kill") && !dead)
		{
			activeMovement = false;
			dead = true;
			StartCoroutine("Die");
		}
	}
	void Update () 
	{

//		Debug.Log (motor.movement.velocity.y);
		if(!motor.grounded)
		{
			jumping = true;
		}
		else
		{
			jumping = false;
			if(dieWhenGrounded && !dead)
			{
				activeMovement = false;
				dead = true;
				StartCoroutine("Die");
//				pSwitch.curState = !pSwitch.curState;
//				PlayerSwitch.fadeFromForm = true;
			}
		}
		if(fallingDeath)
		{
			if(!IsFallingHigh())
			{

				if(motor.movement.velocity.y < -10)
				{
//					this.transform.position = prevGroundedPos;
					dieWhenGrounded = true;
//					Instantiate(

				}
			}
		}

		//if in snow && grounded && not idle, activate snow particle emission
		if(!idle && motor.grounded && !snowPF.enableEmission  || snowAtFeet)
		{
			snowPF.enableEmission = true;
		}
		if((idle || !motor.grounded) && snowPF.enableEmission || !snowAtFeet)
		{
			snowPF.enableEmission = false;
		}
//		movementSpeed = Mathf.Abs(motor.movement.velocity.x / 3);
//		charAnim.SetFloat("speed",movementSpeed);
		charAnim.SetBool("fall", dead);
		charAnim.SetBool("InStorm", inStorm);
		charAnim.SetBool("sitting", sitting);
		charAnim.SetBool("sittingHouse", sittingHouse);

		charAnim.SetBool("walkRight", movingRight);
		charAnim.SetBool("walkLeft", movingLeft);
		charAnim.SetBool("idle", idle);
		charAnim.SetBool ("jumping", jumping);
		charAnim.SetBool ("inSpirit", inSpirit);
//		Debug.Log (Input.GetAxis("RTrigger"));
		if(canSprint)
		{
		if(Input.GetAxis("RTrigger") > 0.8f && !sprinting)
		{
			sprinting = true;
			sprintValue = sprintSpeed;
		}
		if(Input.GetAxis("RTrigger") < 0.8f && sprinting)
		{
			sprinting = false;
			sprintValue = 1;
		}
		}
		// til hoppet skal jeg finde input dir retning(venstre el. højre).
		// i meget kort tid skal jeg checke om hop knappen er hold inde i kort eller længere tid for at finde ud af hvor langt hopet skal være(ddete skal ske undervejs i hoppet)
		// der skal være en smule styring iblandet kraften fra hoppet

//		Debug.Log (motor.movement.velocity.x);
//		if(motor.movement.velocity.x > 0.1f && !movingRight)
//		{
//
//			movingRight = true;
//			movingLeft = false;
//			idle = false;
//
//		}
//		if(motor.movement.velocity.x < -0.1f && !movingLeft)
//		{
//			movingLeft = true;
//			movingRight = false;
//			idle = false;
//		}
//
//		if(motor.movement.velocity.x > -0.1f && motor.movement.velocity.x < 0.1f && !idle)
//		{
//			idle = true;
//			movingLeft = false;
//			movingRight = false;
//		}
		if(!inSpirit)
		{
		
			if(floatC)
			{
			if(activeMovement && !floatC.floating)
			{
				Controls ();
			}
			}

			if(!floatC)
			{
				if(activeMovement)
				{
					Controls ();
//					Debug.Log (
				}
			}
			if(motor.jumping.jumping)
			{
				jumping = true;
			}
			else
			{
				jumping = false;
			}

		}
		else
		{
			motor.inputMoveDirection = Vector3.zero;
		}



	}

	IEnumerator Die()
	{	bool onOff = true;
		float mTime = 0;
		whiteFade.GetComponent<Renderer>().material.color = new Color(1,1,1,0);
		whiteFade.GetComponent<Renderer>().enabled = true;
		SoundManager.PlaySFX(Camera.main.gameObject,"jump fail", false, 0, 0.1f, 0.2f); 

		while(onOff)
		{
			if(mTime < 1)
			{
				mTime += Time.deltaTime;
				whiteFade.GetComponent<Renderer>().material.color = Color.Lerp(new Color(1,1,1,0), new Color(1,1,1,1), mTime);

			}
			else
			{
				dieWhenGrounded = false;

				this.transform.position = prevGroundedPos;
				whiteFade.GetComponent<Renderer>().material.color = new Color(1,1,1,0);
				activeMovement = true;
				dead = false;
				onOff = false;

			}

			yield return null;
		}
	}
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.collider.CompareTag("Snow"))
		{
			onSnow = true;
			onWood = false;
			onStone = false;
			if(!snowAtFeet)
			{
				snowAtFeet = true;

			}
		}
		if(hit.collider.CompareTag("Wood"))
		{
			onSnow = false;
			onWood = true;
			onStone = false;
			if(snowAtFeet)
			{
				snowAtFeet =	false;
			}
		}
		if(hit.collider.CompareTag("Stone"))
		{
			onSnow = false;
			onWood = false;
			onStone = true;
			if(snowAtFeet)
			{
				snowAtFeet = false;
			}
		}
	}
//	void OnTriggerEnter(Collider col)
//	{
//		if(col.CompareTag("NoSnow"))
//		{
////						Debug.Log ("SNOW!");
//			snowAtFeet = false;
//
//		}
//		if(col.CompareTag("Snow"))
//		{
//			//						Debug.Log ("SNOW!");
//			snowAtFeet = true;
//			
//		}
//	}

	void Controls()
	{
//		Debug.Log ("TEXT");
			if(Input.GetAxis("Horizontal") > 0.1f && !movingRight)
			{
				if(sitting)
				{
					sitting = false;
				}
			if(sittingHouse) sittingHouse = false;
				charGfx.eulerAngles = new Vector3(0,90,0);
				movingRight = true;
				movingLeft = false;
				idle = false;
				movedRight = true;
				movedLeft = true;
				
			}
			
			if(Input.GetAxis("Horizontal") < -0.1f && !movingLeft)
			{
				charGfx.eulerAngles = new Vector3(0,-90,0);
				if(sitting)
				{
					sitting = false;
				}
			if(sittingHouse) sittingHouse = false;

				movingLeft = true;
				movingRight = false;
				idle = false;
				movedRight = false;
				movedLeft = true;
			}
			
			if(Input.GetAxis("Horizontal") > -0.1f && Input.GetAxis("Horizontal") < 0.1f && !idle)
			{
				if(sitting)
				{
					sitting = false;
				}
//			if(sittingHouse) sittingHouse = false;

				idle = true;
				movingLeft = false;
				movingRight = false;
				
			}
			
			motor.inputMoveDirection = Vector3.right * Input.GetAxis("Horizontal") * sprintValue;
//			motor.inputJump = Input.GetKey(KeyCode.JoystickButton0);

		

	}
//	void OnControllerColliderHit (ControllerColliderHit hit)
//	{
//		Rigidbody body = hit.collider.attachedRigidbody;
//		
//		Vector3 force = Vector3.zero;
//		
//		// no rigidbody
//		if (body == null || body.isKinematic) { return; }
//		
//		// We use gravity and weight to push things down, we use
//		// our velocity and push power to push things other directions
////		if (hit.moveDirection.y > -0.3f) {
//////			force = new Vector3 (0, -0.5f, 0) * motor.movement.gravity * weight;
////		} else {
////			force = hit.controller.velocity * pushPower - body.velocity;
////		}
//		
//		// Apply the push
////		body.AddForceAtPosition(force, hit.point);
////		if (hit.moveDirection.y < -1.0F){
////			Debug.Log ("return");
////			return;
//
////		Debug.Log (hit.point.y);
////		if(!motor.grounded)
////			return;
////		}
//		if (Vector3.Dot(this.transform.position - hit.transform.position, hit.transform.up) > 0.5f) {
//
//			return;
////			return true; // object B is above object A
//			
//		}
//		else{
//
//
//		Vector3 pushDir = motor.movement.velocity;
////		Vector3 pushDir = new Vector3(hit.moveDirection.x, hit.moveDirection.y, hit.moveDirection.z);
//		body.velocity =  new Vector3(pushDir.x * pushPower, 0, body.velocity.z);
//		}
//	}
//
	void LateUpdate()
	{
		if(activeMovement)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, 0 );
		}
	}

	bool IsFallingHigh()
	{
		return  Physics.Raycast(transform.position, -Vector3.up,2);
	}

//	IEnumerator DelayedGrounded()
//	{
////		yield return WaitForSeconds
//	}



}





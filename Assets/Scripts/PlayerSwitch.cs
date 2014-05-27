using UnityEngine;
using System.Collections;

public class PlayerSwitch : MonoBehaviour {

	public GameObject playerObj;
	public GameObject spiritObj;
	public GameObject spiritGfx;
	public GameObject spiritGfxMesh;
	public bool switchFreely;
	private CharacterController playerController;
	public PlayerMovement playerMove;
	private Vector3 playerVelocity;

	private SpiritMovement spiritMove;
	private Vector3 spiritVelocity;

	public KeyCode switchKey= KeyCode.JoystickButton3;
//	[HideInInspector]
	public bool curState; //false = player true = spirit
	[HideInInspector]
	public static bool fadeFromForm;

//	public delegate void FadeFromFormDelegate();
//	public event FadeFromFormDelegate FadeFromForm;
	private Vector3 curVel;

	private int dir = -1; //-1 == left 1 == right
	public bool switchable;
	public bool canGoSpirit;
	public Color spiritLight;
	private Color startAmbientL;
	private bool doneFirstSwitch;
	[HideInInspector]
	public bool goingToSpirit;
	private ParticleSystemRenderer spiritParticlesR;
	private Color sPRColorStart;

	void Start () 
	{
		spiritParticlesR = Camera.main.GetComponentInChildren<ParticleSystemRenderer>();
		sPRColorStart = spiritParticlesR.material.GetColor("_TintColor");
		spiritParticlesR.material.SetColor("_TintColor", new Color(sPRColorStart.r, sPRColorStart.g, sPRColorStart.b, 0));
//		RenderSettings.ambientLight = new Color(1,1,1);
		startAmbientL = RenderSettings.ambientLight;
		spiritObj = GameObject.Find("Spirit");
		playerController = playerObj.GetComponent<CharacterController>();
		playerVelocity = playerController.velocity;
		playerMove = playerObj.GetComponent<PlayerMovement>();

		spiritMove = spiritObj.GetComponent<SpiritMovement>();
		spiritGfx = spiritObj.transform.GetChild(0).gameObject;
		spiritGfxMesh = spiritGfx.transform.GetChild(0).gameObject;

		spiritMove.activeMovement = false;
//		spiritObj.renderer.enabled = false;
		spiritObj.collider.enabled = false;
		spiritGfx.SetActive(false);

		dir = -1;
		switchable =true;
	}
	

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.K))
		{
			Application.LoadLevel("sceneselect");
		}
		if(canGoSpirit)
		{

		if(Input.GetAxis("Horizontal") >0.2f)
		{
			dir = 1;
		}
		if(Input.GetAxis("Horizontal") <-0.2f)
		{
			dir = -1;
		}

//		Debug.Log(dir);
		if(!curState)
		{
			//player is shown and moved
			if(spiritMove.activeMovement && switchable)
			{
				goingToSpirit = true;
				playerMove.inSpirit = false;

				spiritObj.collider.enabled = false;
				spiritMove.activeMovement = false;
				playerMove.activeMovement = true;
//				spiritObj.renderer.enabled = false; // skal være fade ud
				playerMove.spiritActive = false;
				StartCoroutine("SpiritFadeout", false);

			}

//			spiritObj.transform.position = Vector3.SmoothDamp(spiritObj.transform.position, playerObj.transform.position, ref curVel, Time.deltaTime * 5f);
		}

		if(curState && playerMove.activeMovement && switchable)
		{
			//spirit is shown and moved
			playerMove.inSpirit = true;
			spiritObj.transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y + 1, playerObj.transform.position.z);

			playerMove.activeMovement = false;
			spiritMove.activeMovement = true;
//			spiritObj.renderer.enabled = true;
			spiritGfx.SetActive(true);
			spiritObj.collider.enabled = true;
			spiritMove.rigidbody.AddForce(new Vector3(dir,0,0) * Mathf.Clamp(playerVelocity.magnitude, 0.3f, 10f) * 2,ForceMode.Impulse);
			playerMove.spiritActive = true;
				Debug.Log ("tospirit");
			StartCoroutine("SpiritFadeout", true);

		}




		if(Input.GetKeyDown(switchKey) && switchable)
		{
//				Debug.Log ("huehuehe");
//			Debug.Log ("wat22222");
			curState = !curState;
//			StartCoroutine(ClickOnce());
			fadeFromForm = true;
//			curState = true;
//			fadeFromForm = !fadeFromForm;
		}
		else if(switchFreely && Input.GetKeyDown(KeyCode.JoystickButton2) && spiritMove.grounded && switchable)
		{
			playerObj.transform.position = new Vector3(spiritObj.transform.position.x, spiritObj.transform.position.y +0.2f, spiritObj.transform.position.z);
			curState = !curState;
			fadeFromForm = true;

		}
		else
		{
////			Debug.Log (fadeFromForm);
			fadeFromForm = false;
//
		}
		}
//		if(fadeFromForm)
//		{
//			fadeFromForm = false;
//		}
//		if(Input.GetKeyDown(switchKey) && curState && !fadeFromForm)
//		{
//			curState = false;
//			fadeFromForm = !fadeFromForm;
//		}
//		if(fadeFromForm)
//		{
//			fadeFromForm = false;
//		}
//		if(Input.GetKeyUp(switchKey))
//		{
//			fadeFromForm = false;
//		}

//		Debug.Log (fadeFromForm);
		playerVelocity = playerController.velocity;
//		Debug.Log (playerVelocity.x);

	}

	// spirit skal kunne 1. fade ud.
	// 1. player skal kunne komme hen til spirit.

	IEnumerator SpiritFadeout(bool turnOnSpirit)
	{
		bool onOff = true;
		float mTime = 0;
		Color curCol = spiritGfxMesh.renderer.material.color;
//		Color spCurCol = spiritParticlesR.material.color;
		switchable = false;

		while(onOff)
		{
			if(turnOnSpirit)
			{
				if(mTime < 1)
				{
					RenderSettings.ambientLight = Color.Lerp(startAmbientL, spiritLight, mTime);
					mTime += Time.deltaTime * 1.5f;
					spiritGfxMesh.renderer.material.color = Color.Lerp(curCol, new Color(curCol.r, curCol.g, curCol.b, 1), mTime);
					spiritParticlesR.material.SetColor("_TintColor", Color.Lerp(new Color(sPRColorStart.r, sPRColorStart.g, sPRColorStart.b, 0), sPRColorStart, mTime));
				}
				else
				{
					onOff = false;
					switchable = true;
					doneFirstSwitch = true;

				}
			}
			else
			{
				if(mTime < 1)
				{
					if(doneFirstSwitch)
					{
						RenderSettings.ambientLight = Color.Lerp(spiritLight, startAmbientL, mTime);
					}
					mTime += Time.deltaTime * 1.5f;
					spiritGfxMesh.renderer.material.color = Color.Lerp(curCol, new Color(curCol.r, curCol.g, curCol.b, 0), mTime);
					spiritParticlesR.material.SetColor("_TintColor", Color.Lerp(sPRColorStart, new Color(sPRColorStart.r, sPRColorStart.g, sPRColorStart.b, 0), mTime));

				}
				else
				{
					onOff = false;

					spiritGfx.SetActive(false);
					switchable = true;
					goingToSpirit =	false;

				}

			}
			yield return null;
		}


	}

//	void ChangeState()
//	{
//		curState = !curState;
//	}
//	IEnumerator ClickOnce()
//	{
//		curState = !curState;
//		fadeFromForm = !fadeFromForm;
//		yield return new WaitForEndOfFrame();
//		fadeFromForm = !fadeFromForm;
//	}

}

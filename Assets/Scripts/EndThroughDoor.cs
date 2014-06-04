using UnityEngine;
using System.Collections;

public class EndThroughDoor : MonoBehaviour {

	// Use this for initialization
	public Animator anim;
	private Transform charGfx;
	private PlayerMovement pMove;
	private PlayerSwitch pSwitch;
	private SpiritMovement sMove;
	private GameObject fadeBlack;
	private ActionHandler actionHandler;

	void Start () {
		fadeBlack = GameObject.Find ("BlackFade");
		anim = GetComponentInChildren<Animator>();
		charGfx = anim.gameObject.transform;
		sMove = GameObject.FindObjectOfType<SpiritMovement>();
		pMove = GetComponent<PlayerMovement>();
		pSwitch = GetComponent<PlayerSwitch>();
		actionHandler =  GetComponent<ActionHandler>();
		if(actionHandler)
		{
			actionHandler.TakeAction += End;
		}
//		StartCoroutine("EndCR");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void End(GameObject gObj, bool stop)
	{
		StartCoroutine("EndCR");
	}
	IEnumerator EndCR()
	{
		charGfx.eulerAngles = new Vector3(0, 360,0);
		pSwitch.curState = !pSwitch.curState;
		pSwitch.spiritGfx.SetActive(false);
		bool onOff = true;
		bool onOff2 = true;
		float mTime = 0;
		fadeBlack.renderer.enabled = true;
		fadeBlack.renderer.material.color = new Color(0,0,0,0);
//		bool startFading =false;;
		float count = 0;
//		yield return new WaitForSeconds(1);
		sMove.activeMovement = false;
		pSwitch.switchable = false;
		pMove.activeMovement = false;
		pSwitch.canGoSpirit = false;
		yield return new WaitForSeconds(7);
	
		pMove.movingRight = true;



		while(onOff)
		{
			transform.Translate(Vector3.forward * Time.deltaTime);
			count += Time.deltaTime;
			if(count > 15)
			{
				if(mTime < 1)
				{
					mTime += Time.deltaTime / 5;
					fadeBlack.renderer.material.color = Color.Lerp(new Color(0,0,0,0), new Color(0,0,0,1), mTime);
				}
//				Debug.Log ("NGUIEGNU");

			}
			yield return null;
		}
//		yield return new WaitForSeconds(1);



//		Debug.Log ("BFUEWIA");

	}
}

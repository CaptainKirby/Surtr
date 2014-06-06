using UnityEngine;
using System.Collections;

public class IKTest : MonoBehaviour {
	public float leftFootPositionWeight;
	public float leftFootRotationWeight;
	public Transform leftFootObj;
	public Transform leftFootRC;
	private Animator animator;
	private RaycastHit hit1;
	private Quaternion grndTilt;
	public LayerMask layerMask;

//	private 
	void Start() {
		animator = GetComponent<Animator>();
	}


	void OnAnimatorIK(int layerIndex) {
		animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootPositionWeight);
		animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootRotationWeight);
		animator.SetIKPosition(AvatarIKGoal.LeftFoot, hit1.point);
		animator.SetIKRotation(AvatarIKGoal.LeftFoot, grndTilt);
	}
	void Update()
	{
		if (Physics.Raycast(leftFootRC.transform.position, -Vector3.up, out hit1, layerMask)) 
		{
			Debug.Log(hit1.point);
			Debug.DrawLine (leftFootObj.transform.position, hit1.point, Color.cyan);
			grndTilt = Quaternion.Euler(hit1.normal);
		}

	}
}
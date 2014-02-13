using UnityEngine;
using System.Collections;

public class MoveWithPlatform : MonoBehaviour {
	CharacterController myCharacterController;
	private Transform activePlatform;
	private ControllerColliderHit hit;
	private Vector3 activeGlobalPlatformPoint;
	private Vector3 activeLocalPlatformPoint;
	private Quaternion activeGlobalPlatformRotation;
	private Quaternion activeLocalPlatformRotation;
	string tagName;
	private Vector3 moveDirection= Vector3.zero;
	private bool  grounded = false;
	private Vector3 lastPlatformVelocity;
	
	void  FixedUpdate (){
		if (tagName != "MovingSurface") 
		{
			activePlatform = null;
			lastPlatformVelocity = Vector3.zero;
		}
		if (tagName == "MovingSurface") 
		{
			if (grounded) {
				// We are grounded on a Moving Surface, so recalculate move direction directly from axes
				moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
				moveDirection = transform.TransformDirection(moveDirection);// Move the controller
				CharacterController controller = GetComponent<CharacterController>();
				CollisionFlags flags= controller.Move(moveDirection * Time.deltaTime);
				grounded = (flags & CollisionFlags.CollidedBelow) != 0;
				//Keep moving (?) by getting the spped var from the FPSWalker CC script or whatever you are using 
//				moveDirection *= FPSWalker.speed;
				
			}
			Vector3 calculatedMovement= moveDirection * Time.deltaTime;
			// Moving platform support
			if (activePlatform != null) {
				Vector3 newGlobalPlatformPoint= activePlatform.TransformPoint(activeLocalPlatformPoint);
				Vector3 moveDistance= (newGlobalPlatformPoint - activeGlobalPlatformPoint);
				transform.position = transform.position + moveDistance;
				lastPlatformVelocity = (newGlobalPlatformPoint - activeGlobalPlatformPoint) / Time.deltaTime;
				// If you want to support moving platform rotation as well:
				Quaternion newGlobalPlatformRotation= activePlatform.rotation * activeLocalPlatformRotation;
				Quaternion rotationDiff= newGlobalPlatformRotation * Quaternion.Inverse(activeGlobalPlatformRotation);
				transform.rotation = rotationDiff * transform.rotation;
			}
			else
			{
				lastPlatformVelocity = Vector3.zero;
			}
			//Controller Move  takes place here 
			CollisionFlags collisionFlags = myCharacterController.Move (calculatedMovement);
			// Moving platforms support
			if (activePlatform != null) {
				activeGlobalPlatformPoint = transform.position;
				activeLocalPlatformPoint = activePlatform.InverseTransformPoint (transform.position);
				// If you want to support moving platform rotation as well:
				activeGlobalPlatformRotation = transform.rotation;
				activeLocalPlatformRotation = Quaternion.Inverse(activePlatform.rotation) * transform.rotation;
			}
		}
	}
	
	void  OnControllerColliderHit ( ControllerColliderHit hit  ){
		// Make sure we are really standing on a straight platform
		// Not on the underside of one and not falling down from it either!
		if (hit.moveDirection.y < -0.9f && hit.normal.y > 0.5f) {
			activePlatform = hit.collider.transform;
			tagName = hit.collider.tag;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Vector3 targetPosition;
	Vector3 lookAtTarget;
	Quaternion playerRot;
	float rotSpeed = 10;
	float speed = 20;
	bool moving = false;


	 
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			SetTargetPosition ();
		}
		if (moving)
			Move ();
	}

	void SetTargetPosition()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 1000)) 
		{
			Vector3 newhit = new Vector3(hit.point.x,hit.point.y, hit.point.z - 2 );
 
			targetPosition = newhit;
			//this.transform.LookAt (targetPosition);
			lookAtTarget = new Vector3 (targetPosition.x - transform.position.x,
				transform.position.y, 
				targetPosition.z - transform.position.z);
			playerRot = Quaternion.LookRotation (lookAtTarget);
			moving = true;
		}
	}


	void Move()
	{
		transform.rotation = Quaternion.Slerp (transform.rotation,
									playerRot,
									rotSpeed * Time.deltaTime);
		transform.position = Vector3.MoveTowards(transform.position,
									targetPosition,
									speed * Time.deltaTime); 
		if (transform.position == targetPosition) {
			 
			moving = false;
		}
	}
}

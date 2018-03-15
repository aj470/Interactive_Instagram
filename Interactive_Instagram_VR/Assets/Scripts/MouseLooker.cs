using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooker : MonoBehaviour {

	//public variables
	public float Xsen = 2f;
	public float Ysen = 2f;
	public bool ClampVerticalRotation = true;
	public float MinX = -90f;
	public float MaxX = 90f;
	public bool smooth;
	public float Smoothtime = 5f;


	//private variables
	private Quaternion CharacterTargetRot;
	private Quaternion CameraTargetRot;
	private Transform Character; 
	private Transform CameraTransform;

	// Use this for initialization
	void Start () {
		LockCursor (false);

		//get reference to our character transform(specifically for the script we attach to the specific layer of our game)
		//Character = gameObject.transform;

		//get a reference to camera's transform
		CameraTransform = Camera.main.transform;

		//get location of our camera and character
		//CharacterTargetRot = Character.localRotation;
		CameraTargetRot = CameraTransform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		LookRotation ();

		if (Input.GetButtonDown ("Cancel")) {
			LockCursor (false);
		}
		if (Input.GetButtonDown ("Fire1")) {
			LockCursor (true);
		}
	}

	private void LockCursor(bool isLocked) {
		if (isLocked) 
		{
			// make the mouse pointer invisible
			Cursor.visible = false;

			// lock the mouse pointer within the game area
			Cursor.lockState = CursorLockMode.Locked;
		} else {
			// make the mouse pointer visible
			Cursor.visible = true;

			// unlock the mouse pointer so player can click on other windows
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void LookRotation() {
		//get x and y rotation behind input manager
		float yRot = Input.GetAxis ("Mouse X") * Xsen;

		float xRot = Input.GetAxis ("Mouse Y") * Ysen;

		//CharacterTargetRot *= Quaternion.Euler (0f, yRot, 0f);

		CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);

		if(ClampVerticalRotation)
			CameraTargetRot = ClampRotationAroundXAxis (CameraTargetRot);

		// update the character and camera based on calculations
		if(smooth) 
			// if smooth, then slerp over time
		{
			//Character.localRotation = Quaternion.Slerp (Character.localRotation, CharacterTargetRot,
			//	Smoothtime * Time.deltaTime);
			CameraTransform.localRotation = Quaternion.Slerp (CameraTransform.localRotation, CameraTargetRot,
				Smoothtime * Time.deltaTime);
		}
		else 
			// not smooth, so just jump
		{
			//Character.localRotation = CharacterTargetRot;
			CameraTransform.localRotation = CameraTargetRot;
		}
	}

	//Some math
	Quaternion ClampRotationAroundXAxis (Quaternion q) 
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1.0f;

		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);
		angleX = Mathf.Clamp (angleX, MinX, MaxX);
		q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);
		return q;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public float speed = 3.0f;
	public float gravity = 9.81f;

	private CharacterController myController;

	// Use this for initialization
	void Start () {
		myController = gameObject.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 Movementx = Input.GetAxis ("Vertical") * Vector3.forward * speed * Time.deltaTime;

		Vector3 Movementz = Input.GetAxis ("Horizontal") * Vector3.right * speed * Time.deltaTime;

		Vector3 Movement = transform.TransformDirection (Movementx + Movementz);

		//apply gravity
		Movement.y -= gravity * Time.deltaTime;

		Debug.Log ("Movement " + Movement);

		myController.Move (Movement);
		
	}
}

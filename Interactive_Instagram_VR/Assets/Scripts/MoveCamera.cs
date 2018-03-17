using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	Rigidbody m_Rigidbody;
	//float m_Speed;
	public float rotateSpeed = 10.0f;


	void Start()
	{
		//Fetch the Rigidbody component you attach from your GameObject
		m_Rigidbody = GetComponent<Rigidbody>();
		//Set the speed of the GameObject
		//m_Speed = 10.0f;
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			//transform.Rotate(Vector3.up * -m_Speed * Time.deltaTime);
			//transform.RotateAround(Vector3.zero, Vector3.right, 20 * Time.deltaTime);
			transform.RotateAround(Vector3.zero, Vector3.right, rotateSpeed * Time.deltaTime );

		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			//transform.RotateAround(Vector3.zero, Vector3.left, 20 * Time.deltaTime);
			transform.RotateAround(Vector3.one, Vector3.left, rotateSpeed * Time.deltaTime);


		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			//Rotate the sprite about the Y axis in the positive direction
			//transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * m_Speed, Space.World);
			//transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
			transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);


		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			//Rotate the sprite about the Y axis in the negative direction
			//transform.RotateAround(Vector3.zero, Vector3.down, 20 * Time.deltaTime);
			transform.RotateAround(Vector3.zero, Vector3.down, rotateSpeed * Time.deltaTime);

		}
	}
}
/*
 * Copyright 2014 Jason Graves (GodLikeMouse/Collaboradev)
 * http://www.collaboradev.com
 *
 * This file is part of Unity - Topology.
 *
 * Unity - Topology is free software: you can redistribute it 
 * and/or modify it under the terms of the GNU General Public 
 * License as published by the Free Software Foundation, either 
 * version 3 of the License, or (at your option) any later version.
 *
 * Unity - Topology is distributed in the hope that it will be useful, 
 * but WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with Unity - Topology. If not, see http://www.gnu.org/licenses/.
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraControlZeroG : MonoBehaviour {

	public float speed = 6.0f;
    public Text movementSpeed;
	private CharacterController myController;
 

    private Vector3 move = new Vector3();

	 

	 

    void Update () {
		
		move.x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		move.z = Input.GetAxis ("Vertical") * speed * Time.deltaTime;

		move.x = Input.GetAxis ("Mouse X") * speed * Time.deltaTime;
		move.z = Input.GetAxis ("Mouse Y") * speed * Time.deltaTime;

		 


		move.y = 0;
		if (Input.GetKey ("w")) {
			transform.position += Vector3.forward * speed * Time.deltaTime;		}

		if (Input.GetKey ("s")) {
			transform.position += Vector3.back * speed * Time.deltaTime;
		}
 
	//	Vector3 moveforward = Input.GetAxis ("Fire4") * Vector3.forward * speed * Time.deltaTime;
	//	Vector3 movebackward = Input.GetAxis ("Fire5") * Vector3.back * speed * Time.deltaTime;
	//	Vector3 Movement = transform.TransformDirection (moveforward + movebackward);
	//	Debug.Log ("Movement " + Movement);
 
	

		//adjust speed with mouse wheel
		speed += Input.GetAxis("Mouse ScrollWheel") * 15;
		if (speed < 5)
			speed = 5;

		movementSpeed.text = "Flyspeed: " + speed;

		move = transform.TransformDirection(move);
		transform.position += move;
	}
}

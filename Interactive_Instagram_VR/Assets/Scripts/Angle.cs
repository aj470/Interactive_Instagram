using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle : MonoBehaviour {


	public GameObject target;
 

	public Vector3 camoriginposition;
 
	void Start() {

		camoriginposition = Camera.main.transform.position;
 	}

	//When I press Wide Angle Position  resets to default X,Y,Z Coordinates
	public void ButtonMethod()
	{
		Camera.main.transform.position = camoriginposition ;
 	}

 
}
	

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetCamera : MonoBehaviour {

	public GameObject Camera;
	public Button yourButton;


	// Use this for initialization
	void Start () {
	    Camera = GameObject.FindGameObjectWithTag ("MainCamera");
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
 		Debug.Log("Camera Found");
 	}
	
	// Update is called once per frame
	//void Update () {
		
	//}
}

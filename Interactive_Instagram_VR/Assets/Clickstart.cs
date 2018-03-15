using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Clickstart : MonoBehaviour {

	//public string myString;
	public Color color;
	public Text myText;
	public bool displayInfo;


	void Start () {
		
		//GameObject loadButton = GameObject.Find("Btn_Load");
		//GameCtrlInputReader textReader = loadButton.GetComponent<GameCtrlInputReader>();
		myText.text ="" + this.name.ToString();
		//myText = GameObject.Find ("message").GetComponent<Text> ();
		//myText.color = Color.blue;
		//Screen.showCursor = false;
		//Screen.lockCursor = true;
	}

	public void OnMouseEnter()
	{
		gameObject.GetComponent<Renderer> ().material.color = color;
		displayInfo = true;
		//Debug.Log ("myText is: " + myText.enabled);
	}

	void OnMouseExit()
	{
		gameObject.GetComponent<Renderer> ().material.color = Color.green;
		displayInfo = false;

	}

	void Update()
	{
		if (displayInfo) {
			myText.enabled = true;
			Debug.Log (myText.text);
		}
		if (!displayInfo) {
			myText.enabled = false;
		}

	}

}

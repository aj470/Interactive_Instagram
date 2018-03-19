using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clickstart : MonoBehaviour {

	//public string myString;
	public Color color;
	public Text myText;
	public bool displayInfo;
	Dictionary<GameObject, List<GameObject>> all_links_input = new Dictionary<GameObject, List<GameObject>>{};
	public GraphController graphControl_link;
	public bool linked = false;
	List <Link> links = new List<Link>();
	int count;
	public bool destroy = true;
	void Start () {
		

		Node nodeobject = this.GetComponent<Node>();
		//GameObject loadButton = GameObject.Find("Btn_Load");
		//GameCtrlInputReader textReader = loadButton.GetComponent<GameCtrlInputReader>();
		myText.text ="" + nodeobject.TextName.ToString();
		//myText = GameObject.Find ("message").GetComponent<Text> ();
		//myText.color = Color.blue;
		//Screen.showCursor = false;
		//Screen.lockCursor = true;
		all_links_input = GameCtrlInputReader.all_links;
		graphControl_link = GameCtrlInputReader.graphControl;
		Debug.Log ("The size"+ all_links_input.Count);
	}

	public void OnMouseEnter()
	{
		count = 0;
		if (GameCtrlInputReader.done) {
			gameObject.GetComponent<Renderer> ().material.color = color;
		//	myText.enabled = true;
			Debug.Log (myText.text);
			displayInfo = true;
			if (!linked) {
				link ();
			}
		}
		//Debug.Log ("myText is: " + myText.enabled);
	}

	void OnMouseExit()
	{
		linked =false;
		if (GameCtrlInputReader.done) {
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
			displayInfo = false;
			if (links.Count > 0 && count <50 && destroy) {
				destroy = false;
				foreach (Link li in links) {
					try
					{
						Destroy (li.gameObject);
					}
					catch{
						continue;
					}

				}
			}
		}
	}

	void link(){
		linked = true;

		List<GameObject> li = new List<GameObject> (){ };
		bool success = all_links_input.TryGetValue (gameObject, out li);
		if (success) {


			Debug.Log (li.Count);
			foreach (GameObject obj in li) {
				Debug.Log ("I am here");
				Debug.Log (obj);
				Debug.Log (this.gameObject);
				Debug.Log (this.GetComponent<GraphController> ());


				Link o = graphControl_link.GenerateLink ("specific_src_tgt", gameObject, obj); //LAG IS FROM HERE.
				if(o != null)
				links.Add(o);
			}
		}
	}

	void Update()
	{
		count = count + 1;
		if (displayInfo) {
			
				myText.enabled = true;
				Debug.Log (myText.text);
		}
			if (!displayInfo) {
				myText.enabled = false;
			}
				
	}
}

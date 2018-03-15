using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemtextControl : MonoBehaviour {

	public Transform popuptext;
	public static string textstatus="off";

	void OnMouseEnter()
	{
		if (textstatus == "off")
		{

		

			if (gameObject.name == "nodePrefabBullet") 
			{
 				popuptext.GetComponent<TextMesh> ().text = "Bullet";

			}

			if (gameObject.name == "nodePrefabPhysX") 
			{
				popuptext.GetComponent<TextMesh> ().text = "Node";
 
			}


			textstatus = "on";
			Instantiate (popuptext, new Vector3 ((float)transform.position.x, (float)transform.position.y, (float)transform.position.z + 2.0f), popuptext.rotation);
			Debug.Log("Bullet");

		}
	}

	void OnMouseExit()
	{
		if (textstatus == "on") 
		{
			textstatus = "off";

		}

	}

}

using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
    public Transform canvas;
	public Transform Player;




	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
	}
    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            Player.GetComponent<Controller>().enabled = false;
 			Player.GetComponent<CameraControlZeroG>().enabled = false;
			Player.GetComponent<MoveCamera>().enabled = false;
			Player.GetComponent<CameraController>().enabled = false;
			Player.GetComponent<ResetCamera>().enabled = false;
			Player.GetComponent<displayUI>().enabled = false;
			Player.GetComponent<GameController>().enabled = false;
			Player.GetComponent<GameCtrlHelper>().enabled = false;
			Player.GetComponent<GameCtrlHID>().enabled = false;
			Player.GetComponent<GameCtrlInputReader>().enabled = false;
			Player.GetComponent<GameCtrlUI>().enabled = false;
			Player.GetComponent<GhostObjPiggyBack2>().enabled = false;
			Player.GetComponent<GraphController>().enabled = false;
			Player.GetComponent<ItemtextControl>().enabled = false;
			Player.GetComponent<Link>().enabled = false;	
			Player.GetComponent<GhostObjPiggyBack2>().enabled = false;
			Player.GetComponent<Node>().enabled = false;
			Player.GetComponent<NodePhysX>().enabled = false;
			Player.GetComponent<NodeBullet>().enabled = false;
			Player.GetComponent<paintedLink>().enabled = false;
			Player.GetComponent<ResetCamera>().enabled = false;




        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
			Player.GetComponent<Controller>().enabled = true;
			Player.GetComponent<CameraControlZeroG>().enabled = true;
			Player.GetComponent<MoveCamera>().enabled = true;
			Player.GetComponent<CameraController>().enabled = true;
			Player.GetComponent<ResetCamera>().enabled = true;
			Player.GetComponent<displayUI>().enabled = true;
			Player.GetComponent<GameController>().enabled = true;
			Player.GetComponent<GameCtrlHelper>().enabled = true;
			Player.GetComponent<GameCtrlHID>().enabled = true;
			Player.GetComponent<GameCtrlInputReader>().enabled = true;
			Player.GetComponent<GameCtrlUI>().enabled = true;
			Player.GetComponent<GhostObjPiggyBack2>().enabled = true;
			Player.GetComponent<GraphController>().enabled = true;
			Player.GetComponent<ItemtextControl>().enabled = true;
			Player.GetComponent<Link>().enabled = true;	
			Player.GetComponent<GhostObjPiggyBack2>().enabled = true;
			Player.GetComponent<Node>().enabled = true;
			Player.GetComponent<NodePhysX>().enabled = true;
			Player.GetComponent<NodeBullet>().enabled = true;
			Player.GetComponent<paintedLink>().enabled = true;
			Player.GetComponent<ResetCamera>().enabled = true;




        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class GameCtrlInputReader : MonoBehaviour {

    [SerializeField]
    private bool verbose = true;

	public static GraphController graphControl;
    private static GameCtrlUI gameCtrlUI;
	public static bool done = false;
	//used to store the collection of Node GameObjects with their corresponding string source/target values.

	public Dictionary<string, GameObject> string_to_obj = new Dictionary<string, GameObject>{};

	public static Dictionary<GameObject, List<GameObject>> all_links = new Dictionary<GameObject, List<GameObject>>{};

    public class nodeListObj
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }
    public List<nodeListObj> nodesList = new List<nodeListObj>();

    public class linkListObj
    {
        public string id { get; set; }
        public string name { get; set; }
        public string source { get; set; }
        public string target { get; set; }
    }
    private List<linkListObj> linksList = new List<linkListObj>();

    //Method for loading the GraphML layout file
    private IEnumerator LoadInputFile(string sourceFile)
    {
        gameCtrlUI.PanelStatusText.text = "Loading file: " + sourceFile;
        gameCtrlUI.ProgressBarSetActive(true);
        gameCtrlUI.ProgressBarValue(0F);

        //determine which platform to load for
        string xml = null;
        if (Application.isWebPlayer)
        {
            WWW www = new WWW(sourceFile);
            yield return www;
            xml = www.text;
        }
        else
        {
            StreamReader sr = new StreamReader(sourceFile);
            xml = sr.ReadToEnd();
            sr.Close();
        }

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xml);

        gameCtrlUI.PanelStatusText.text = "Loading Topology";

        XmlElement root = xmlDoc.FirstChild as XmlElement;
        for (int i = 0; i < root.ChildNodes.Count; i++)
        {
            XmlElement xmlGraph = root.ChildNodes[i] as XmlElement;

            int myNodeCount = 0;
            int myLinkCount = 0;

            int childCount = xmlGraph.ChildNodes.Count;

            for (int j = 0; j < childCount; j++)
            {

                gameCtrlUI.ProgressBarValue((float)j / (float)childCount * 100F);

                XmlElement xmlNode = xmlGraph.ChildNodes[j] as XmlElement;

                //create nodes
                gameCtrlUI.PanelStatusText.text = "Loading: " + xmlNode.Attributes["id"].Value;
				if (xmlNode.Name == "node" && myNodeCount<1000)
                {
                    myNodeCount++;
                    /*nodesList.Add(new nodeListObj
                    //{
                        id = xmlNode.Attributes["id"].Value,
                        name = xmlNode.Attributes["name"].Value,
                        type = xmlNode.Attributes["type"].Value,
                        x = float.Parse(xmlNode.Attributes["x"].Value),
                        y = float.Parse(xmlNode.Attributes["y"].Value),
                        z = float.Parse(xmlNode.Attributes["z"].Value)
                    });*/
					nodeListObj nn = new nodeListObj
					{
						id = xmlNode.Attributes["id"].Value,
						name = xmlNode.Attributes["name"].Value,
						type = xmlNode.Attributes["type"].Value,
						x = float.Parse(xmlNode.Attributes["x"].Value),
						y = float.Parse(xmlNode.Attributes["y"].Value),
						z = float.Parse(xmlNode.Attributes["z"].Value)
					};
					string_to_obj.Add(nn.id,graphControl.GenerateNode(nn.x, nn.y, nn.z,nn.name, nn.id, nn.type));
					//store in dictionary

                }

                //create links
				if (xmlNode.Name == "edge")
                {
					if (myLinkCount == 2000)
						break;
						
					myLinkCount++;
                    /*linksList.Add(new linkListObj
                    {
                        id = xmlNode.Attributes["id"].Value,
                        name = xmlNode.Attributes["label"].Value,
                        source = xmlNode.Attributes["source"].Value,
                        target = xmlNode.Attributes["target"].Value
                    });*/
					linkListObj link = new linkListObj
						{
							id = xmlNode.Attributes["id"].Value,
							name = xmlNode.Attributes["label"].Value,
							source = xmlNode.Attributes["source"].Value,
							target = xmlNode.Attributes["target"].Value
						};
					GameObject val_1;
					GameObject val_2;

					string_to_obj.TryGetValue (link.source, out val_1);
					string_to_obj.TryGetValue (link.target, out val_2);

					List<GameObject> li;
					//graphControl.GenerateLink("specific_src_tgt", val_1, val_2); //LAG IS FROM HERE. 
					bool success = all_links.TryGetValue (val_1, out li);
					if (success) {
						li.Add (val_2);
						all_links.Remove (val_1);
						all_links.Add(val_1, li);
					} 
					else 
					{
						List<GameObject> new_li = new List<GameObject>();
						new_li.Add (val_2);
						all_links.Add(val_1, new_li);
					}

					//Utilize a dictionary to store all nodes, and then call from it.

                }

                //every 100 cycles return control to unity
                if (j % 10 == 0)
                    yield return true;
            }
        }

        gameCtrlUI.ProgressBarValue(100F);
        gameCtrlUI.PanelStatusText.text = "Loading done.";
        gameCtrlUI.ProgressBarValue(0F);
        gameCtrlUI.ProgressBarSetActive(false);

        gameCtrlUI.PanelStatusText.text = "Generating graph...";

        /*foreach (nodeListObj genNode in nodesList)
        {
            // Create a node on random Coordinates, but with labels
			graphControl.GenerateNode(genNode.x, genNode.y, genNode.z,genNode.name, genNode.id, genNode.type);
        }

        foreach (linkListObj genLink in linksList)
        {
            graphControl.GenerateLink("specific_src_tgt", GameObject.Find(genLink.source), GameObject.Find(genLink.target));
        }
		*/
        gameCtrlUI.PanelStatusText.text = "Graph done.";
		gameCtrlUI.PanelStatusText.text = all_links.Count.ToString();
		done = true;
    }

    public void LoadandGenWorld()
    {
        nodesList.Clear();
        linksList.Clear();

        string sourceFile = gameCtrlUI.OpenFileDialogGetFile();
        if (sourceFile.Length != 0)
        {
            StartCoroutine(LoadInputFile(sourceFile));
        }
    }

    void Start()
    {
        graphControl = GetComponent<GraphController>();
        gameCtrlUI = GetComponent<GameCtrlUI>();
        //gameCtrlHelper gameCtrlHelper = GetComponent<gameCtrlHelper>();
    }
		
}

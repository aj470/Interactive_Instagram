# Interactive_Instagram
An WIP interactive 3D visualization of Instagram networks

This project is composed of two directories - Instagram_Network_Visualization, and Interactive_Instagram_VR. The former contains the neccessary scripts to generate the neccessary XML file, which is a network consisting of users that you are following on Instagram (and possibly more), and the latter actually generates said network from the XML, as seen below

![Interactive Instagram Simulation](https://github.com/aj470/Interactive_Instagram/blob/master/Interactive_Instagram_VR/visuals/network.gif)

[Conceptual Demo](https://plot.ly/~AyushJoshic973/30/instagram-network-visualization-by-ayush-joshi/).

<br>
Featuring:

- Multidimensional network visualizations of users within your immediate network.
- Username toggling on hover.


<br>
NOTE: We will be releasing the script needed to generate the network.json file later.

<br>
XML File Generation:
- Run the Jupyter Notebook to load the network.json file to generate the XML file.

<br>
How to Run:

- Click Play to initialize the environment
- Select 'Load File'
- Load the XML file containing the graph (i.e throughshutter.xml)

<br>
Controls:

- Movement: WASD keys
- Rotation: Up/Down/Left/Right Arrow keys

<br>
Licensing:

This project uses the initial code of Bamfax's repository, hosted at https://github.com/Bamfax/ForceDirectedNodeGraph3DUnity

As such, the following also apply to our project:

- Please be aware that the different parts of the code are using different licenses.
- If not mentioned otherwise, the code is released is GPLv3.
- Included is a slighty modified version of BulletUnity Plugin (Examples removed, BCamera included), refer to mentioned BulletUnity Github repository for its license.
- Layout.xml and CameraControlZeroG.cs from Jason Graves are GPLv3, as mentioned in his tutorial (see link above). 
- ProgressBar Unity3D Plugin from Eri is used as progress bar (on loading files). More info and licensing are available here:
      https://www.assetstore.unity3d.com/en/#!/content/30891
      https://eri-st.eu/

<br>
To-DOs:

- Load links dynamically (i.e only load links between selected/visible nodes on hover) //which will also help in optimizing node computation
- Implement inbuilt photo feed for each node.
- Add computational heuristics for more varied graph visualizations.
- Polishes.

<br>
Authors:

[aj470](https://github.com/aj470), 
[scarletknight11](https://github.com/scarletknight11),
[alexjjia](https://github.com/alexjjia)

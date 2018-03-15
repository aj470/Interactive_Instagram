using UnityEngine;

public abstract class Node : MonoBehaviour
{
	[SerializeField]
	protected static bool verbose = true;

	protected static GraphController graphControl;

	private string id;
	public string textname;
	private string type;

	public string Id
	{
		get
		{
			return id;
		}
		set
		{
			id = value;
		}
	}

	public string TextName
	{
		get
		{
			return textname;
		}
		set
		{
			textname = value;
		}
	}

	public string Type
	{
		get
		{
			return type;
		}
		set
		{
			type = value;
		}
	}

	protected abstract void doGravity();

	protected abstract void doRepulse();

	protected virtual void Start()
	{
		graphControl = FindObjectOfType<GraphController>();
	}

	void FixedUpdate()
	{
		if (!graphControl.AllStatic && graphControl.RepulseActive)
			doRepulse();

		if (!graphControl.AllStatic)
			doGravity();
	}
}
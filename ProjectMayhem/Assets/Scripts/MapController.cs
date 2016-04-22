
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MapController : MonoBehaviour 
{
	private GameObject _nodeButton;
	//public string sdsf;

	// Use this for initialization
	void Awake () 
	{
		_nodeButton = GameObject.FindWithTag ("Node");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void NodeSelector(string name)
	{
		Debug.Log ("Selected " + name);
	}
}


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MapController : MonoBehaviour 
{

	// Use this for initialization
	void Awake () 
	{
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

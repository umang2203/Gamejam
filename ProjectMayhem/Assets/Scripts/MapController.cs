
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour 
{

	// Use this for initialization
	void Awake () 
	{
		SceneManager.LoadScene ("MapSelection");
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

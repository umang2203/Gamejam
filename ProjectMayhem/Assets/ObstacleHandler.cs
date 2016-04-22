using UnityEngine;
using System.Collections;

public class ObstacleHandler : MonoBehaviour {

	// Use this for initialization
	void OnEnable () 
	{
		InputManager.OnSwipe += PositionChanger;
	}

	public void PositionChanger(SwipeDirection dir)
	{
		Debug.Log (dir);

	}

	void OnDisable () 
	{
		InputManager.OnSwipe -= PositionChanger;
	}
	// Update is called once per frame
	void Update () {
	
	}
}

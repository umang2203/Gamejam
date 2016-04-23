using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

    public Runner _runner;

	void Start () 
    {
//        _runner = transform.FindChild("Platform/Runner").GetComponent<Runner>();
        InputManager.OnSwipe += InputManager_OnSwipe;
	}

    void OnDestroy()
    {
        InputManager.OnSwipe -= InputManager_OnSwipe;
    }

    public void InputManager_OnSwipe (SwipeDirection swipeDirection)
    {
        Debug.Log(swipeDirection);
        switch (swipeDirection)
        {
            case SwipeDirection.SwipeDown:
                break;
            case SwipeDirection.SwipeLeft:
                break;
            case SwipeDirection.SwipeRight :
                break;
            case SwipeDirection.SwipeUp:
                if(_runner != null)
                    _runner.Jump();
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections.Generic;

public class World : MonoBehaviour {

    public Runner _runner;

    private Object      _cachedCarPrefab;
    private Transform   _platform;
    private float       _size;

    public ManHole   activeManHole;
    public Lightning activeLightning;
    public List<LampPost>   LampPostList;
	void Start () 
    {
        activeLightning = null;
        LampPostList = new List<LampPost>();
        InputManager.OnSwipe += InputManager_OnSwipe;
        _cachedCarPrefab = Resources.Load("Prefabs/Car");
        _platform = transform.FindChild("Platform");
        _size = Camera.main.orthographicSize * Screen.width / Screen.height;
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
                RequestLightning();
                break;
            case SwipeDirection.SwipeLeft:
                SpawnCar();
                break;
            case SwipeDirection.SwipeRight :
                break;
            case SwipeDirection.SwipeUp:
                OpenManHole();
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnCar()
    {
        GameObject killerCar = GameObject.Instantiate(_cachedCarPrefab) as GameObject;
        killerCar.name =  "KillerCar";
        killerCar.transform.SetParent(_platform,false);
        killerCar.transform.localPosition = new Vector3(_runner.transform.localPosition.x + _size * 2,  killerCar.transform.localPosition.y,killerCar.transform.localPosition.z);
    }

    void RequestLightning()
    {
      
        if(activeLightning != null)
        {
             Debug.Log(activeLightning.name);
             activeLightning.Strike();
        }
    }

    void OpenManHole()
    {
        if(activeManHole != null)
        {
            Debug.Log(activeManHole.name);
            activeManHole.Blow();
        }
    }
}

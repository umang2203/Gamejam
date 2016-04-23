using UnityEngine;
using System.Collections.Generic;

public class World : MonoBehaviour {

    public Runner _runner;

    private Object      _cachedCarPrefab;
    private Transform   _platform;
    private float       _size;

    public List<Lightning> LightningList;
    public List<LampPost> LampPostList;

	void Start () 
    {
        LightningList = new List<Lightning>();
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
                break;
            case SwipeDirection.SwipeLeft:
                SpawnCar();
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

    void SpawnCar()
    {
        GameObject killerCar = GameObject.Instantiate(_cachedCarPrefab) as GameObject;
        killerCar.name =  "KillerCar";
        killerCar.transform.SetParent(_platform,false);
        killerCar.transform.localPosition = new Vector3(_runner.transform.localPosition.x + _size * 2,  killerCar.transform.localPosition.y,killerCar.transform.localPosition.z);
    }
}

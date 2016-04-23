using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

    Runner _runner;

    private Object      _cachedCarPrefab;
    private Transform   _platform;
    private float       _size;

	void Start () 
    {
        _runner = transform.FindChild("Platform/Runner").GetComponent<Runner>();
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

        killerCar.transform.localPosition = new Vector3(_runner.transform.localPosition.x + _size * 2,  _runner.transform.localPosition.y,_runner.transform.localPosition.z);
    }
}

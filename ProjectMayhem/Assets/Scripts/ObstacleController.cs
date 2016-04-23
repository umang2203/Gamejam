using UnityEngine;
using System.Collections;

public class ObstacleController: MonoBehaviour {

    private float _ScreenWidth;
    private GameObject _car;
	// Use this for initialization
	void Start () 
    {
        _ScreenWidth = GameObject.Find("World").GetComponent<RectTransform>().rect.width;
        Debug.Log(_ScreenWidth);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

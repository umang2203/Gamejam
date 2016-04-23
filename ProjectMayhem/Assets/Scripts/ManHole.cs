using UnityEngine;
using System.Collections;

public class ManHole : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float _screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        if(transform.position.x < Camera.main.gameObject.transform.position.x - _screenWidth)
            GameObject.Destroy(this.gameObject);
	}
}

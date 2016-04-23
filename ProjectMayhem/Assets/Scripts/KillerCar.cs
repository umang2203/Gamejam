using UnityEngine;
using System.Collections;

public class KillerCar : MonoBehaviour {

    public float speed = 0.1f;

	
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.left * speed);
        float _screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        if(transform.position.x < Camera.main.gameObject.transform.position.x - _screenWidth)
            GameObject.Destroy(this.gameObject);
	}

   
}

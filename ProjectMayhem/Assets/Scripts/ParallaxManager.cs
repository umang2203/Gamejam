using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxManager : MonoBehaviour {


    public GameObject parallaxObject;
    public float parallaxSpeed;

    float prevCameraPos;
    float currentPos;
    float delta;
    float offset;
    Vector3 offsetPosition;



    public Transform cameraGo;


    void Awake()
    {
        if (cameraGo == null)
        {
            cameraGo = Camera.main.transform;
        }
        parallaxObject = transform.gameObject;

    }


	// Use this for initialization
	void Start () {

        prevCameraPos = cameraGo.transform.position.x;
	
	}
	
	// Update is called once per frame
	void Update () {

        currentPos = cameraGo.transform.position.x;

        if(currentPos != prevCameraPos)
        {
            
                delta = (currentPos - prevCameraPos) * parallaxSpeed;
                offset = parallaxObject.transform.position.x + delta ;
                offsetPosition = new Vector3(offset,parallaxObject.transform.position.y,parallaxObject.transform.position.z );
                parallaxObject.transform.position = offsetPosition;

            prevCameraPos = cameraGo.transform.position.x;

        }
	
	}
}

using UnityEngine;
using System.Collections;

public class Tilling : MonoBehaviour {


    public float spriteWidth;
    Camera mainCamera;

    public bool leftBG = false;
    public bool rightBG = false;

    void Awake()
    {
        mainCamera = Camera.main;
    }
	// Use this for initialization
	void Start () 
    {
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if( rightBG == false ||leftBG == false)
        {
            float cameraViewX = mainCamera.orthographicSize * Screen.width/Screen.height;

            float xRight = (transform.position.x + spriteWidth/2) - cameraViewX;
            float XLeft = (transform.position.x + spriteWidth/2) + cameraViewX;

            if(mainCamera.transform.position.x >= xRight - 2 && leftBG == false)
            {
                CreateNewBG(1);
                leftBG = true;
            }

            if(mainCamera.transform.position.x <= XLeft - 2 && rightBG == false)
            {
                CreateNewBG(-1);
                rightBG = true;
            }
        }
	}

    void CreateNewBG(int Side)
    {
        Vector3 newPosition = new Vector3 (this.transform.position.x + spriteWidth * Side, this.transform.position.y,this.transform.position.z);

        Transform newBG = Instantiate (this.transform, newPosition, transform.rotation) as Transform;
        newBG.name = transform.name;


        newBG.parent = transform.parent;
        if (Side > 0) 
        {
            newBG.GetComponent<Tilling>().rightBG = true;
        }
        else 
        {
            newBG.GetComponent<Tilling>().leftBG = true;
        }

        if(Side > 0)
            Destroy(this.transform.gameObject,12);
        
    }
}

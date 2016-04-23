using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class LampPost : MonoBehaviour {

    public bool IsActive;
    public GameObject LightSprite;
	// Use this for initialization

    void Awake()
    {
        LightSprite = this.transform.GetChild(0).gameObject;
    }
	void Start () 
    {
        
        LightSprite.SetActive(true);
	}


	
	// Update is called once per frame
	
    void Update () 
    {

        float _screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        if(transform.position.x < Camera.main.gameObject.transform.position.x - _screenWidth)
            GameObject.Destroy(this.gameObject);
	
        SpriteRenderer rendrer = new SpriteRenderer();

	}

    void OnMouseDown()
    {
        Debug.Log("Meh");
        
    }

   
}

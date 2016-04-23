using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class LampPost : MonoBehaviour {

    public GameObject LightSprite;
	// Use this for initialization

    void Awake()
    {
        LightSprite = this.transform.GetChild(0).gameObject;
        GameObject.Find("GestureRecognizer").GetComponent<InputManager>().OnPointerCall += OnPointerDown;
    }
	void Start () 
    {
        
        LightSprite.SetActive(true);
	}

    public bool IsActive()
    {
        return LightSprite.activeSelf;
    }


	
	// Update is called once per frame
	
    void Update () 
    {

        float _screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        if(transform.position.x < Camera.main.gameObject.transform.position.x - _screenWidth)
            GameObject.Destroy(this.gameObject);
	
       

	}

    void OnPointerDown(GameObject go)
    {
        if(this != null)
        {
            if(go == this.gameObject || go == this.transform.GetChild(0).gameObject)
            {
                LightSprite.SetActive(false);
            }
        }
        
    }

   
}

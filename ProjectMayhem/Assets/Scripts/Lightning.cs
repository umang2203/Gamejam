using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour 
{

    World _world;
    GameObject _lightningBolt;

    void Start()
    {
        _world = transform.root.GetComponent<World>();
        _lightningBolt = transform.FindChild("Bolt").gameObject;
    }

    void Update () {
        float _screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        if(transform.position.x < Camera.main.gameObject.transform.position.x - _screenWidth)
            GameObject.Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Runner")
        {
            _world.activeLightning = this;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.name == "Runner")
        {
            _world.activeLightning = null;
        }
    }
	

    public void Strike()
    {
        _lightningBolt.SetActive(true);
    }
}

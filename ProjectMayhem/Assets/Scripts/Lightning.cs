using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour 
{

    World _world;

    void Start()
    {
        _world = transform.root.GetComponent<World>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Runner")
        {
            _world.LightningList.Add(this);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.name == "Runner")
        {
            _world.LightningList.Remove(this);
        }
    }
	
}

using UnityEngine;
using System.Collections;

public class AI  : MonoBehaviour
{
    Runner _runner;

    void Start()
    {
        _runner = GetComponent<Runner>();
    }

    //Collisions
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);
        if(collider.gameObject.name == "KillerCar" && IsUnderLight())
            _runner.Jump();
        else
            if(collider.gameObject.name == "CarDeath")
                _runner.Hit();

        switch (collider.name)
        {
            case "KillerCar":
                if(IsUnderLight())
                    _runner.Jump();
                break;
            case "ManHole":
                if(IsUnderLight())
                    _runner.Jump();
                break;
            case "CarDeath":
                if(!IsUnderLight())
                {
                    GameObject.Destroy(collider.gameObject);
                    _runner.Hit();
                }
                break;
            case "ManHole_Death":
                if(!IsUnderLight())
                {
                    GameObject.Destroy(collider.gameObject);
                    _runner.Hit();
                }
                break;
        }
    }



    private bool IsUnderLight()
    {
        return true;
    }
	
}

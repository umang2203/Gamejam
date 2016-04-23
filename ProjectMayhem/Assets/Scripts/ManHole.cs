using UnityEngine;
using System.Collections;

public class ManHole : MonoBehaviour {

    public GameObject cover;
    public float coverblowSpeed;

    private World _world;
    public bool isOpen = false;

    void Start () 
    {
        _world = transform.root.gameObject.GetComponent<World>();
       
	}
	
	// Update is called once per frame
	void Update () {
        float _screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        if(transform.position.x < Camera.main.gameObject.transform.position.x - _screenWidth)
            GameObject.Destroy(this.gameObject);
	}


    public void Blow()
    {
        cover.GetComponent<ParticleSystem>().Play();
        isOpen = true;
    }



    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Runner")
        {
            _world.activeManHole = this;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.name == "Runner")
        {
            _world.activeManHole = null;
        }
    }
}

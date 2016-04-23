using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    private GameObject      _runner;
    public GameObject[]    itemPrefabs;
    public float[]         frequency;
    public Transform       platform;
    private float[]        _lastSpawnTime;
    private float          _size;



	void Start () 
    {
        
        _lastSpawnTime = new float[itemPrefabs.Length];
        for(int i = 0; i < _lastSpawnTime.Length; i++)
            _lastSpawnTime[i] = 0f;

        _size = Camera.main.orthographicSize * Screen.width / Screen.height;
	
	}
	
	
	void Update () 
    {
        if(_runner == null)
            _runner = transform.FindChild("Platform/Runner").gameObject;
        
        for(int i = 0; i < itemPrefabs.Length; i++)
        {
            if(_lastSpawnTime[i] + frequency[i] < Time.time)
            {
                GameObject item = GameObject.Instantiate(itemPrefabs[i]) as GameObject;
                item.transform.SetParent(platform,false);
                Vector3 _runnerPostion = _runner.transform.localPosition;
                item.transform.localPosition = new Vector3(_runner.transform.localPosition.x + _size * 2,  item.transform.localPosition.y,item.transform.localPosition.z);
                item.name = itemPrefabs[i].name;
                ParallaxManager _parallax = item.AddComponent<ParallaxManager>();
                _parallax.parallaxSpeed = 0.25f;

                _lastSpawnTime[i] = Time.time;
            }
        }
	
	}
}

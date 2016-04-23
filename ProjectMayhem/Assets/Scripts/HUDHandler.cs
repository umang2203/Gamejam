using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDHandler : MonoBehaviour 
{

	float timer = 10f;
	Text timertext;
//	GameObject obstacleCar;
	// Use this for initialization
	void Start () 
	{
//		obstacleCar = GameObject.FindGameObjectWithTag ("Obstacle");
		//Debug.Log (obstacleCar.name);
		timertext = GameObject.Find("Timer").GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		timertext.text = timer.ToString();

		if (timer < 0) 
		{
			//Time.timeScale = 0;
			print ("GAME OVER!!!");
		}

	}

//	void OnCollisionEnter2D(Collision2D coll) 
//	{
//		Debug.Log ("aaaaaaa");
//		if (coll.gameObject.tag == "Obstacle") 
//		{
//			Debug.Log ("dsgerga");
//		}
//
//	}
}

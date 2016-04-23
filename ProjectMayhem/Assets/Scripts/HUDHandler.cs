using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDHandler : MonoBehaviour 
{

	float timer = 10f;
	Text timertext;

	public Image circularSilder;            //Drag the circular image i.e Slider in our case
	public float StartTime;  

	private	int _count = 0;
	private Text countText;  				//In how much time the progress bar will fill/empty


	void Start () 
	{
		
		countText = GameObject.Find("Count").GetComponent<Text> ();
		_count = 0;
		countText.text = _count.ToString();

		circularSilder.fillAmount=1f; 
		StartTime = Time.time;

	}
	

	void Update () 
	{

		circularSilder.fillAmount = 1 - (Time.time - StartTime )/ timer;   
	}
}

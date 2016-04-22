using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IBeginDragHandler, IEndDragHandler {

	Vector2 initialPosition;
	Vector2 finalPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		Debug.Log ("Begin Drag");
		initialPosition = eventData.position;
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		Debug.Log ("End Drag");
		finalPosition = eventData.position;
		float angle = Vector2.Angle (initialPosition,finalPosition);
		Vector3 cross = Vector3.Cross (initialPosition, finalPosition);
		if (cross.z > 0)
			angle = 360 - angle;
		Debug.Log ("Angle: "+ angle);

		if (finalPosition.x > initialPosition.x)
		{
			Debug.Log ("Right");
		}
		else
		{
			Debug.Log ("Left");
		}

		if (finalPosition.y > initialPosition.y)
		{
			Debug.Log ("Up");
		}
		else
		{
			Debug.Log ("Down");
		}
	}
}

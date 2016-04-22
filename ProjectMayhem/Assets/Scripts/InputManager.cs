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

		Vector2 direction = finalPosition - initialPosition;
		Vector2 swipeType = Vector2.zero;

		if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
		{
			// the swipe is horizontal:
			swipeType = Vector2.right * Mathf.Sign(direction.x);
		}
		else
		{
			// the swipe is vertical:
			swipeType = Vector2.up * Mathf.Sign(direction.y);
		}

		if(swipeType.x != 0.0f)
		{
			if(swipeType.x > 0.0f)
			{
				// MOVE RIGHT
				Debug.Log ("Right");
			}
			else
			{
				// MOVE LEFT
				Debug.Log ("Left");
			}
		}

		if(swipeType.y != 0.0f )
		{
			if(swipeType.y > 0.0f)
			{
				// MOVE UP
				Debug.Log ("Up");
			}
			else
			{
				// MOVE DOWN
				Debug.Log ("Down");
			}
		}

//		float angle = Vector2.Angle (initialPosition,finalPosition);
//		Vector3 cross = Vector3.Cross (initialPosition, finalPosition);
//		if (cross.z > 0)
//			angle = 360 - angle;
//		Debug.Log ("Angle: "+ angle);
//
//		if (finalPosition.x > initialPosition.x)
//		{
//			Debug.Log ("Right");
//		}
//		else
//		{
//			Debug.Log ("Left");
//		}
//
//		if (finalPosition.y > initialPosition.y)
//		{
//			Debug.Log ("Up");
//		}
//		else
//		{
//			Debug.Log ("Down");
//		}
	}
}

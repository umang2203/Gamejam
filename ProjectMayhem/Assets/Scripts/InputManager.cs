using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

using UnityEngine.UI;

public enum SwipeDirection
{
	SwipeUp,
	SwipeDown,
	SwipeLeft,
	SwipeRight
};

public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {



	Vector2 initialPosition;
	Vector2 finalPosition;


    public UnityAction<GameObject> OnPointerCall;
	public delegate void Swipe(SwipeDirection swipeDirection); 
	public static event Swipe OnSwipe;


	// Use this for initialization
	void Start ()
	{	

	}
	
	// Update is called once per frame


    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            var layermask = (1 << 8);
            layermask = ~layermask;


            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up,Mathf.Infinity,layermask);
            if (hit.collider != null) 
            {
                if(OnPointerCall != null)
                {
                    OnPointerCall(hit.collider.gameObject);
                }
               
               
            }

        }
    }
        



	public void OnPointerDown (PointerEventData eventData)
	{
		initialPosition = eventData.position;
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		finalPosition = eventData.position;

		Vector2 direction = finalPosition - initialPosition;
		Vector2 swipeType = Vector2.zero;

        float magnitude = (finalPosition-initialPosition).magnitude;

        Debug.Log(magnitude);
        if(magnitude > 100f)
        {

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
    				OnSwipe(SwipeDirection.SwipeRight);
    				//Debug.Log ("Right");
    			}
    			else
    			{
    				// MOVE LEFT
    				OnSwipe(SwipeDirection.SwipeLeft);
    				//Debug.Log ("Left");
    			}
    		}

    		if(swipeType.y != 0.0f )
    		{
    			if(swipeType.y > 0.0f)
    			{
    				// MOVE UP
    				OnSwipe(SwipeDirection.SwipeUp);
    				//Debug.Log ("Up");
    			}
    			else
    			{
    				// MOVE DOWN
    				OnSwipe(SwipeDirection.SwipeDown);
    				//Debug.Log ("Down");
    			}
    		}
        }
    }
}

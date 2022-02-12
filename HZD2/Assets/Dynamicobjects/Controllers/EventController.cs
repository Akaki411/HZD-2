using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static EventController singleton { get; private set; }
    
    //***Mouse***
    public Vector2 mousePosition = new Vector2(0, 0);
    private float _halfWidth;
    private float _halfHeight;
    
    //***Events***
    //Jump
    public delegate void JumpDelegate();
    public event JumpDelegate Jump;
    
    //Flip
    public delegate void FlipRightDelegate();
    public event FlipRightDelegate FlipRight;
    public delegate void FlipLeftDelegate();
    public event FlipLeftDelegate FlipLeft;
    public bool isRight;

    private void Awake()
    {
        GameObject ec = GameObject.FindGameObjectWithTag("EventController");
        if (ec)
        {
            Destroy(gameObject);
        }

        singleton = this;
        gameObject.tag = "EventController";
        _halfWidth = Screen.width / 2;
        _halfHeight = Screen.height / 2;

        isRight = Input.mousePosition.x - _halfWidth > 0;
    }
    private void Update()
    {
        mousePosition.x = Input.mousePosition.x - _halfWidth;
        mousePosition.y = Input.mousePosition.y - _halfHeight;

        if (mousePosition.x > 0 && !isRight)
        {
            FlipRight?.Invoke();
            isRight = true;
        }

        if (mousePosition.x < 0 && isRight)
        {
            FlipLeft?.Invoke();
            isRight = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchInputManager : TouchInputManager
{
    //Subscribe to the base touch input manager functions
    private void Start()
    {
        tap += OnTap;
        doubleTap += OnDoubleTap;
        hold += OnHold;
    }


    //Unsubscribe to the base touch input manager functions
    private void OnDestroy()
    {
        tap -= OnTap;
        doubleTap -= OnDoubleTap;
        hold -= OnHold;
    }

    private void OnTap(Vector2 tapPosition)
    {

    }

    private void OnDoubleTap(Vector2 doubleTapPosition)
    {

    }

    private void OnHold(Vector2 holdPosition)
    {

    }
}

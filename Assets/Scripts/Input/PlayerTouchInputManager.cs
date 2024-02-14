using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchInputManager : TouchInputManager
{
    public Action<int> dodge;
    public Action attack;

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
        Debug.Log("Attack");

        attack?.Invoke();
    }

    private void OnDoubleTap(Vector2 doubleTapPosition)
    {
        if (doubleTapPosition.x < Screen.width/2)
        {
            dodge?.Invoke(-1);
        }
        else
        {
            dodge?.Invoke(1);
        }
    }

    private void OnHold(Vector2 holdPosition)
    {

    }
}

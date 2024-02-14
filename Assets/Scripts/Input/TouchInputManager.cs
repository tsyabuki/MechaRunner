using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInputManager : MonoBehaviour
{
    public ContinuousTouchData continuousTouchData;

    public Action<Vector2> tap;
    public Action<Vector2> doubleTap;
    public Action<Vector2> hold;

    [Header("Interaction Settings")]
    [SerializeField] private Vector2 _pressTapTimeBounds;
    [SerializeField] private float _pressDoubleTapTime;
    [SerializeField] private float _pressHeldThreshold;

    // Update is called once per frame
    protected virtual void Update() 
    {
        //Handle touch held code
        if(continuousTouchData.touchIsHeld)
        {
            continuousTouchData.timeTouchHeld += Time.deltaTime;
        }
        continuousTouchData.timeSinceTouchLast += Time.deltaTime;
    }

    protected virtual void touchPressInputAction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            continuousTouchData.touchIsHeld = true;
        }
        if (context.canceled)
        {
            continuousTouchData.lastTouchPosition = continuousTouchData.currentTouchPosition;
            continuousTouchData.touchIsHeld = false;
            //Action code

            //Tap action
            if (continuousTouchData.timeTouchHeld >= _pressTapTimeBounds.x && continuousTouchData.timeTouchHeld <= _pressTapTimeBounds.y)
            {
                //Tap action
                tap?.Invoke(continuousTouchData.currentTouchPosition);

                //Double tap action
                if (continuousTouchData.timeSinceTouchLast <= _pressDoubleTapTime)
                {
                    doubleTap?.Invoke(continuousTouchData.currentTouchPosition);
                }
            }

            //Hold action
            if (continuousTouchData.timeTouchHeld >= _pressHeldThreshold)
            {
                hold?.Invoke(continuousTouchData.currentTouchPosition);
            }

            continuousTouchData.timeTouchHeld = 0;
            continuousTouchData.timeSinceTouchLast = 0;
        }
    }

    protected virtual void touchPositionInputAction(InputAction.CallbackContext context)
    {
        if(continuousTouchData.touchIsHeld && context.performed)
        {
            continuousTouchData.currentTouchPosition = context.ReadValue<Vector2>();
        }
    }
}

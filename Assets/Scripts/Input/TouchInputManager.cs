using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInputManager : MonoBehaviour
{
    public ContinuousTouchData continuousTouchData;

    // Start is called before the first frame update
    protected virtual void Start() { }

    // Update is called once per frame
    protected virtual void Update() 
    {
        if(continuousTouchData.touchIsHeld)
        {
            continuousTouchData.timeTouchHeld += Time.deltaTime;
            continuousTouchData.timeSinceTouchLast = 0;
        }
        else
        {
            continuousTouchData.timeTouchHeld = 0;
            continuousTouchData.timeSinceTouchLast += Time.deltaTime;
        }
    }

    protected virtual void touchPressInputAction(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase);
        if (context.started)
        {
            continuousTouchData.touchIsHeld = true;  
        }
        if (context.canceled)
        {
            continuousTouchData.lastTouchPosition = continuousTouchData.currentTouchPosition;
            continuousTouchData.touchIsHeld = false;
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

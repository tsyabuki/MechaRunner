using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public float stateDuration { get; protected set; } = 0;

    public virtual void stateEnter() 
    {
        stateDuration = 0;
    }
    public virtual void stateExit() { }
    public virtual void stateTick() 
    {
        stateDuration += Time.deltaTime;
    }
    public virtual void stateFixedTick() { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState { get; protected set; }

    protected virtual void Start()
    {
        CurrentState?.stateEnter();
    }

    protected virtual void OnDestroy()
    {
        CurrentState?.stateExit();
    }

    protected virtual void Update()
    {
        CurrentState?.stateTick();
    }

    protected virtual void FixedUpdate()
    {
        CurrentState?.stateFixedTick();
    }

    public virtual void ChangeState(State newState)
    {
        CurrentState?.stateExit();
        CurrentState = newState;
        CurrentState?.stateEnter();
    }


}

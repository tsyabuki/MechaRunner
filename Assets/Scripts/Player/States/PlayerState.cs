using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    protected PlayerFSM playerFSM;

    //Both of these state functions trigger when the game recognizes a player input
    public virtual void stateOnAttack() { }
    public virtual void stateOnDash(int direction) { }
    public virtual void stateOnCollisionEnter(Collision collision) { }
    public virtual void stateOnCollisionStay(Collision collision) { }
}

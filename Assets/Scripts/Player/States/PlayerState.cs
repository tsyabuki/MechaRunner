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
    public virtual void stateOnCollisionStay(Collision collision) 
    {
        //If the player collides with the side barriers, reset the movespeed
        if (collision.collider.gameObject.CompareTag("SideBarrierL") && playerFSM.moveSpeedCurrent < 0)
        {
            playerFSM.moveSpeedCurrent = 0;
        }

        if (collision.collider.gameObject.CompareTag("SideBarrierR") && playerFSM.moveSpeedCurrent > 0)
        {
            playerFSM.moveSpeedCurrent = 0;
        }
    }
}

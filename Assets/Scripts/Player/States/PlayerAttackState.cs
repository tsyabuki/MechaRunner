using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private float _cancelWindow = 0.2f;

    public PlayerAttackState(PlayerFSM targetPlayerFSM)
    {
        playerFSM = targetPlayerFSM;
    }

    public override void stateEnter()
    {
        base.stateEnter();

        Debug.Log("Start Attack");

        playerFSM.moveSpeedCurrent = 0f;
        playerFSM.movePlayer();
    }

    public override void stateTick()
    {
        base.stateTick();

        if(stateDuration > .6)
        {
            playerFSM.ChangeState(playerFSM.playerDefaultState);
        }
        else if (stateDuration > 0.45)
        {
            playerFSM.attackHitbox.SetActive(false);
        }
        else if (stateDuration > _cancelWindow)
        {
            playerFSM.attackHitbox.SetActive(true);
        }
    }

    public override void stateExit()
    {
        //Disable the hitbox in case the state switches and the hitbox is somehow still active
        playerFSM.attackHitbox.SetActive(false);
    }

    public override void stateOnDash(int direction)
    {
        //Only allow a cancel into a dash during the beginning of the attack animatino

        if(stateDuration <= _cancelWindow)
        {
            playerFSM.playerDashingState.direction = direction;
            playerFSM.ChangeState(playerFSM.playerDashingState);
        }
    }
}

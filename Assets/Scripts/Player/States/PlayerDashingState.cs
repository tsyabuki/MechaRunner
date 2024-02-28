using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashingState : PlayerState
{
    public int direction;

    public PlayerDashingState(PlayerFSM targetPlayerFSM)
    {
        playerFSM = targetPlayerFSM;
    }

    public override void stateEnter()
    {
        base.stateEnter();

        playerFSM.moveSpeedCurrent = playerFSM.dashSpeed * direction;

        playerFSM.playerAudio.pitch = 2;
        playerFSM.playerAudio.PlayOneShot(playerFSM.dashSound, 0.05f);
        playerFSM.playerAudio.pitch = 1;
    }

    public override void stateFixedTick()
    {
        if(stateDuration >= playerFSM.dashTime)
        {
            playerFSM.ChangeState(playerFSM.playerDefaultState);
        }
        else
        {
            //Apply friction if the player isn't moving. Make sure that fricton can never go the same direciton as movement
            float _directionTraveling = Mathf.Sign(playerFSM.moveSpeedCurrent);
            float _newSpeed = playerFSM.moveSpeedCurrent - (_directionTraveling * playerFSM.dashStopFriction * Time.fixedDeltaTime);

            if (Mathf.Sign(_newSpeed) != _directionTraveling)
            {
                playerFSM.moveSpeedCurrent = 0;
            }
            else
            {
                playerFSM.moveSpeedCurrent = _newSpeed;
            }

            playerFSM.movePlayer();
        }
    }
}

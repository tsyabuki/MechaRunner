using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultState : PlayerState
{
    public PlayerDefaultState(PlayerFSM targetPlayerFSM)
    {
        playerFSM = targetPlayerFSM;
    }

    public override void stateFixedTick()
    {
        if(playerFSM.ptim.continuousTouchData.touchIsHeld)
        {
            float _touchPartition = Screen.width / 2;

            if (playerFSM.ptim.continuousTouchData.currentTouchPosition.x < _touchPartition)
            {
                //Left movement code
                playerFSM.moveSpeedCurrent -= playerFSM.moveAcceleration * Time.fixedDeltaTime;
            }
            else
            {
                //Right movement code
                playerFSM.moveSpeedCurrent += playerFSM.moveAcceleration * Time.fixedDeltaTime;
            }

            playerFSM.moveSpeedCurrent = Mathf.Clamp(playerFSM.moveSpeedCurrent, -playerFSM.moveSpeedMax, playerFSM.moveSpeedMax);
        }
        else
        {
            if(playerFSM.moveSpeedCurrent != 0f)
            {
                //Apply friction if the player isn't moving. Make sure that fricton can never go the same direciton as movement
                float _directionTraveling = Mathf.Sign(playerFSM.moveSpeedCurrent);
                float _newSpeed = playerFSM.moveSpeedCurrent - (_directionTraveling * playerFSM.moveStopFriction * Time.fixedDeltaTime);

                if (Mathf.Sign(_newSpeed) != _directionTraveling)
                {
                    playerFSM.moveSpeedCurrent = 0;
                }
                else
                {
                    playerFSM.moveSpeedCurrent = _newSpeed;
                }
            }
        }
        
        playerFSM.movePlayer();
    }

    public override void stateOnAttack()
    {
        
    }

    public override void stateOnDash(int direction)
    {
        playerFSM.playerDashingState.direction = direction;
        playerFSM.ChangeState(playerFSM.playerDashingState);
    }
}

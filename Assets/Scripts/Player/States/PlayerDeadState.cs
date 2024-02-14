using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(PlayerFSM targetPlayerFSM)
    {
        playerFSM = targetPlayerFSM;
    }

    public override void stateEnter()
    {
        base.stateEnter();
        //Disable the player art when the player dies
        playerFSM.playerArt.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(PlayerFSM targetPlayerFSM)
    {
        playerFSM = targetPlayerFSM;
    }
}

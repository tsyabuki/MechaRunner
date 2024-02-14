using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashingState : PlayerState
{
    public PlayerDashingState(PlayerFSM targetPlayerFSM)
    {
        playerFSM = targetPlayerFSM;
    }
}

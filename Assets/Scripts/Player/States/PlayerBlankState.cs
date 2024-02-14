using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlankState : PlayerState
{
    public PlayerBlankState(PlayerFSM targetPlayerFSM)
    {
        playerFSM = targetPlayerFSM;
    }
}

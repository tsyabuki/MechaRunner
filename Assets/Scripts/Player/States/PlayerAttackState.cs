using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(PlayerFSM targetPlayerFSM)
    {
        playerFSM = targetPlayerFSM;
    }
}

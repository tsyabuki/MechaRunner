using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : State
{
    private PlayerFSM _playerFSM;

    PlayerDeadState(PlayerFSM targetPlayerFSM)
    {
        _playerFSM = targetPlayerFSM;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultState : State
{
    private PlayerFSM _playerFSM;

    PlayerDefaultState(PlayerFSM targetPlayerFSM)
    {
        _playerFSM = targetPlayerFSM;
    }
}

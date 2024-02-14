using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashingState : MonoBehaviour
{
    private PlayerFSM _playerFSM;

    PlayerDashingState(PlayerFSM targetPlayerFSM)
    {
        _playerFSM = targetPlayerFSM;
    }
}

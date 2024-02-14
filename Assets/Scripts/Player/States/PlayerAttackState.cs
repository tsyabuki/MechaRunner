using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : MonoBehaviour
{
    private PlayerFSM _playerFSM;

    PlayerAttackState(PlayerFSM targetPlayerFSM)
    {
        _playerFSM = targetPlayerFSM;
    }
}

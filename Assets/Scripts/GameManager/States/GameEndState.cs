using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndState : GameState
{
    public GameEndState(GameManagerFSM targetGmFSM)
    {
        gmFSM = targetGmFSM;
    }
}

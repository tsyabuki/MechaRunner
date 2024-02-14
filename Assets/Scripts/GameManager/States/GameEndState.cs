using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndState : GameState
{
    public GameEndState(GameManagerFSM targetGmFSM)
    {
        gmFSM = targetGmFSM;
    }

    public override void stateEnter()
    {
        base.stateEnter();

        //Enable the game over menu when you enter the end state
        gmFSM.uim.enableGameOver();
    }
}

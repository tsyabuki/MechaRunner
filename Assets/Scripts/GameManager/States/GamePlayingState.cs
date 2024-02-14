using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayingState : GameState
{
    public GamePlayingState(GameManagerFSM targetGmFSM)
    {
        gmFSM = targetGmFSM;
    }

    public override void stateEnter()
    {
        base.stateEnter();

        //Allow the player to move as soon as the playing state is entered
        gmFSM.playerFSM.ChangeState(gmFSM.playerFSM.playerDefaultState);
    }
}

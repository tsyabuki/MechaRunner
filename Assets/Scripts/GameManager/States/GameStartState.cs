using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartState : GameState
{
    public GameStartState(GameManagerFSM targetGmFSM)
    {
        gmFSM = targetGmFSM;
    }

    public override void stateTick()
    {
        base.stateTick();

        if(stateDuration >= gmFSM.startingCountdown)
        {
            gmFSM.ChangeState(gmFSM.gamePlayingState);
        }
    }
}

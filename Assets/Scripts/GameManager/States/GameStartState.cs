using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartState : GameState
{
    public GameStartState(GameManagerFSM targetGmFSM)
    {
        gmFSM = targetGmFSM;
    }

    public override void stateEnter()
    {
        base.stateEnter();

        //Enable countdown UI
        gmFSM.uim.enableCountdown();
    }

    public override void stateTick()
    {
        base.stateTick();

        //Update the countdown UI based on time spent in the state
        gmFSM.uim.setCountdownPhase(stateDuration, gmFSM.startingCountdown);

        //Leave the state if the starting countdown has ended
        if(stateDuration >= gmFSM.startingCountdown)
        {
            gmFSM.ChangeState(gmFSM.gamePlayingState);
        }
    }

    public override void stateExit()
    {
        base.stateExit();

        //Disable the countdown UI
        gmFSM.uim.disableCountdown();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayingState : GameState
{
    private float _spawnTimerCurrent;

    public GamePlayingState(GameManagerFSM targetGmFSM)
    {
        gmFSM = targetGmFSM;
    }

    public override void stateEnter()
    {
        base.stateEnter();

        //Allow the player to move as soon as the playing state is entered
        gmFSM.playerFSM.ChangeState(gmFSM.playerFSM.playerDefaultState);

        //Set the spawn timer
        _spawnTimerCurrent = 0f;
    }

    public override void stateTick()
    {
        base.stateTick();

        //Spawn obstacles on a timer
        _spawnTimerCurrent += Time.deltaTime;

        if(_spawnTimerCurrent >= gmFSM.spawnTimerMax)
        {
            gmFSM.spawnObstacle?.Invoke(1);
            _spawnTimerCurrent = 0f;
        }
    }
}

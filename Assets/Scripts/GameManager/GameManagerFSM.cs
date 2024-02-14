using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerFSM : StateMachine
{
    [Header("Starting Settings")]
    public float startingCountdown;
    [Header("Fill references")]
    public PlayerFSM playerFSM;

    #region State definition
    public GameStartState gameStartState { get; private set; }
    public GamePlayingState gamePlayingState { get; private set; }
    public GameEndState gameEndState { get; private set; }
    #endregion

    private void Awake()
    {
        #region State initilization 
        gameStartState = new GameStartState(this);
        gamePlayingState = new GamePlayingState(this);
        gameEndState = new GameEndState(this);

        CurrentState = gameStartState;
        #endregion
    }
}

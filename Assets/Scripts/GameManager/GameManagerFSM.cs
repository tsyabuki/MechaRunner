using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerFSM : StateMachine
{
    public Action<int> spawnObstacle;

    [Header("Starting Settings")]
    public float score = 0f;
    public float scoreSpeed;
    public float startingCountdown;
    public float spawnTimerMax;
    [Header("Fill references")]
    public PlayerFSM playerFSM;

    //All components to obtain on awake
    public UIManager uim { get; private set; }

    #region State definition
    public GameStartState gameStartState { get; private set; }
    public GamePlayingState gamePlayingState { get; private set; }
    public GameEndState gameEndState { get; private set; }
    #endregion

    private void Awake()
    {
        #region Getting references
        uim = gameObject.GetComponent<UIManager>();
        if (uim == null) { Debug.Log("The PlayerFSM could not find a UI Manager."); };
        #endregion

        #region State initilization 
        gameStartState = new GameStartState(this);
        gamePlayingState = new GamePlayingState(this);
        gameEndState = new GameEndState(this);

        CurrentState = gameStartState;
        #endregion
    }
}

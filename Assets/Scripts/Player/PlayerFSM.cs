using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : StateMachine
{

    #region state definition
    //Define all states the player can move to
    public PlayerDefaultState playerDefaultState { get; private set; }
    public PlayerDashingState playerDashingState { get; private set; }
    public PlayerAttackState playerAttackState { get; private set; }
    public PlayerDeadState playerDeadState { get; private set; }
    #endregion
}

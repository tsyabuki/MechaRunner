using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : StateMachine
{
    //Designer variables
    [Header("Movement variables")]
    public float moveSpeedCurrent;
    public float moveSpeedMax;
    public float moveAcceleration;
    public float moveStopFriction;
    [Space]
    public float dashSpeed;
    public float dashTime;
    [Header("Fill references")]
    public Camera playerCamera;

    //All components to obtain on awake
    public Rigidbody rb { get; private set; }
    public PlayerTouchInputManager ptim { get; private set; }

    #region State definition
    public PlayerDefaultState playerDefaultState { get; private set; }
    public PlayerDashingState playerDashingState { get; private set; }
    public PlayerAttackState playerAttackState { get; private set; }
    public PlayerDeadState playerDeadState { get; private set; }
    #endregion


    private void Awake()
    {
        #region Getting references
        rb = gameObject.GetComponent<Rigidbody>();
        if (rb == null) { Debug.Log("The PlayerFSM could not find a Rigid Body."); };

        ptim = gameObject.GetComponent<PlayerTouchInputManager>();
        if (ptim == null) { Debug.Log("The PlayerFSM could not find a Player Touch Input Manager."); };
        #endregion

        #region State initilization 
        playerDefaultState = new PlayerDefaultState(this);
        playerDashingState = new PlayerDashingState(this);
        playerAttackState = new PlayerAttackState(this);
        playerDeadState = new PlayerDeadState(this);

        CurrentState = playerDefaultState;
        #endregion

        #region Subscribing to the input manager
        ptim.attack += OnAttackInput;
        ptim.dodge += OnDashInput;
        #endregion
    }


    #region Player specific state machine code
    private void OnAttackInput()
    {
        if (CurrentState is PlayerState)
        {
            //The current state is being temporarily casted to a temporary state. Then this temporary state's on attack input code is run.
            PlayerState _tempState = (PlayerState)CurrentState;
            _tempState?.stateOnAttack();
        }
    }

    private void OnDashInput(int direction)
    {
        if (CurrentState is PlayerState)
        {
            //The current state is being temporarily casted to a temporary state. Then this temporary state's on dash input code is run.
            PlayerState _tempState = (PlayerState)CurrentState;
            _tempState?.stateOnDash(direction);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CurrentState is PlayerState)
        {
            //The current state is being temporarily casted to a temporary state. Then this temporary state's on collision input code is run.
            PlayerState _tempState = (PlayerState)CurrentState;
            _tempState?.stateOnCollisionEnter(collision);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (CurrentState is PlayerState)
        {
            //The current state is being temporarily casted to a temporary state. Then this temporary state's on collision input code is run.
            PlayerState _tempState = (PlayerState)CurrentState;
            _tempState?.stateOnCollisionStay(collision);
        }
    }
    #endregion

    public void movePlayer()
    {
        rb.velocity = new Vector3(moveSpeedCurrent, 0f, 0f);
    }
}

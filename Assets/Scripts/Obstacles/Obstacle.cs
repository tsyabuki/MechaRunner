using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;

    //All components to obtain on awake
    public Rigidbody rb { get; private set; }

    protected virtual void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if (rb == null) { Debug.Log("Obstacle " + gameObject.name + " could not find a Rigid Body."); };
    }

    protected virtual void FixedUpdate()
    {
        rb.velocity = new Vector3(0f, 0f, -speed);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        //Check to see if the collision was with the player. If so, incude the game over state
        PlayerFSM _playerFSM = other.gameObject.GetComponent<PlayerFSM>();
        if(_playerFSM != null)
        {
            _playerFSM.ChangeState(_playerFSM.playerDeadState);

            //Set the game state to game over
            GameManagerFSM _gmFSM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerFSM>();
            _gmFSM.ChangeState(_gmFSM.gameEndState);
        }
    }
}

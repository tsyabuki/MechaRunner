using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedRotator : MonoBehaviour
{
    [SerializeField] private float _rotationFactor;
    [SerializeField] private PlayerFSM _playerFSM;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, _playerFSM.moveSpeedCurrent * _rotationFactor, 0f);
    }
}

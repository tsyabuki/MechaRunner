using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the other object has a detroyable object. If so, drop health by 1
        Destroyable _destro = other.GetComponent<Destroyable>();
        if(_destro != null)
        {
            _destro.decreaseHealth(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : Obstacle
{
    public int health;

    public void decreaseHealth(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            onDie();
        }
    }

    public virtual void onDie()
    {
        Destroy(gameObject);
    }
}

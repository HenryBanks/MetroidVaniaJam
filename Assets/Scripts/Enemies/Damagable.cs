using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    protected int health;

    bool dying;

    [SerializeField]
    protected int maxHealth;

    private void Awake()
    {
        health = maxHealth;
        dying = false;
    }

    public void ResetDying()
    {
        dying = false;
    }

    protected virtual void Death()
    {
        Debug.Log(gameObject.name + " Death");
        dying = true;
    }

    public virtual void LoseHealth(int healthLost)
    {
        if (!dying)
        {
            health -= healthLost;
            if (health <= 0)
            {
                Death();
            }
        }
    }



}

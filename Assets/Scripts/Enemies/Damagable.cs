using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    protected int health;

    [SerializeField]
    protected int maxHealth;

    private void Awake()
    {
        health = maxHealth;
    }

    protected virtual void Death()
    {
        Debug.Log(gameObject.name + " Death");
    }

    public virtual void LoseHealth(int healthLost)
    {
        health -= healthLost;
        if (health <= 0){
            Death();
        }
    }



}

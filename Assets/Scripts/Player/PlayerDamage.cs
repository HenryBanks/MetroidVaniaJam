using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : Damagable
{
    protected override void Death()
    {
        base.Death();

        Debug.Log("PLAYER DEAD, RETURN TO SOME POINT");
    }

    public override void LoseHealth(int healthLost)
    {
        base.LoseHealth(healthLost);

        CharacterInfo.instance.SetHealth(health, maxHealth);
    }

    private void Start()
    {
        CharacterInfo.instance.SetHealth(health, maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            LoseHealth(10);
        }
    }


}

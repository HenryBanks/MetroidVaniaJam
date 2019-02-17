using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : Damagable
{

    protected override void Death()
    {
        base.Death();

        Destroy(this.gameObject);
    }

    public override void LoseHealth(int healthLost)
    {
        base.LoseHealth(healthLost);
    }

}

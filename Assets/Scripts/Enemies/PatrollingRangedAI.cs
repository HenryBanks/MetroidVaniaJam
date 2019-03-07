using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingRangedAI : EnemyAI
{

    float walkSpeed;
    float runSpeed;

    PatrollingRangedActions patrollingRangedActions;

    void Awake()
    {
        patrollingRangedActions = GetComponent<PatrollingRangedActions>();
        runSpeed = patrollingRangedActions.RunSpeed;
        walkSpeed = patrollingRangedActions.WalkSpeed;
    }


    protected override void DetectedBehaviour()
    {
        base.DetectedBehaviour();

        //rb2D.velocity = new Vector2(0f, rb2D.velocity.y);

        rb2D.velocity = new Vector2(0f, 0f);

        Vector2 toPlayer = Player.instance.transform.position - transform.position;

        if (toPlayer.x > 0f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            
        }

        if (toPlayer.x < 0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (Time.time > patrollingRangedActions.TimeToNextShot)
        {
            patrollingRangedActions.Shoot(toPlayer.normalized);
        }

    }

    protected override void NotDetectedBehaviour()
    {
        base.NotDetectedBehaviour();

        if (simpleContactDetection.OnWallLeft || !simpleContactDetection.GroundLeft)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
        if (simpleContactDetection.OnWallRight || !simpleContactDetection.GroundRight)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        }
        rb2D.velocity = new Vector2(walkSpeed * transform.localScale.x, rb2D.velocity.y);

    }

}

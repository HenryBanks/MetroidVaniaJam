using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingBombAI : EnemyAI
{
    [SerializeField]
    float walkSpeed;

    [SerializeField]
    float runSpeed;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Debug.Log(GetState());

        if (GetState() == State.detected)
        {
            rb2D.velocity= new Vector2(0f, rb2D.velocity.y);

        }
        else
        {
            if(simpleContactDetection.OnWallLeft)
            {
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
            }
            if (simpleContactDetection.OnWallRight)
            {
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
            }
            rb2D.velocity = new Vector2(walkSpeed * transform.localScale.x, rb2D.velocity.y);

        }
    }
}

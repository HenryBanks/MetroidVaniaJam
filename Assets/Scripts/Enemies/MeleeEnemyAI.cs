using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAI : EnemyAI
{
    float walkSpeed;

    float runSpeed;
    
    //[SerializeField]
    //Explosion explosion;

    MeleeEnemyActions meleeEnemyActions;

    void Awake()
    {
        meleeEnemyActions = GetComponent<MeleeEnemyActions>();
        runSpeed = meleeEnemyActions.RunSpeed;
        walkSpeed = meleeEnemyActions.WalkSpeed;
    }

    protected override void Start()
    {
        base.Start();
        }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //Debug.Log(GetState());

    }

    protected override void DetectedBehaviour()
    {
        base.DetectedBehaviour();

        //rb2D.velocity = new Vector2(0f, rb2D.velocity.y);

        if (!meleeEnemyActions.Slashing)
        {

            Vector2 toPlayer = Player.instance.transform.position - transform.position;

            if (toPlayer.x > 0f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            }

            if (toPlayer.x < 0f)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            }

            if (toPlayer.magnitude < 2f)
            {
                meleeEnemyActions.StartSlash();
            }
        }
    }

    protected override void NotDetectedBehaviour()
    {
        base.NotDetectedBehaviour();

        if (simpleContactDetection.OnWallLeft || !simpleContactDetection.GroundLeft)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (simpleContactDetection.OnWallRight || !simpleContactDetection.GroundRight)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        rb2D.velocity = new Vector2(walkSpeed * transform.localScale.x, rb2D.velocity.y);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingBombAI : EnemyAI
{
    [SerializeField]
    float walkSpeed;

    [SerializeField]
    float runSpeed;

    bool jumped;

    //[SerializeField]
    //Explosion explosion;

    WalkingBombActions walkingBombActions;

    void Awake()
    {
        walkingBombActions = GetComponent<WalkingBombActions>();
    }

    protected override void Start()
    {
        base.Start();

        jumped = false;
    }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Debug.Log(GetState());

    }

    protected override void DetectedBehaviour()
    {
        base.DetectedBehaviour();

        //rb2D.velocity = new Vector2(0f, rb2D.velocity.y);

        if (!jumped)
        {

            Vector2 toPlayer = Player.instance.transform.position - transform.position;

            if (toPlayer.x > 0f)
            {
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
                rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            }

            if (toPlayer.x < 0f)
            {
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
                rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            }

            if (toPlayer.magnitude < 4f)
            {
                jumped = true;
                walkingBombActions.JumpAndExplode();
            }
        }
    }

    protected override void NotDetectedBehaviour()
    {
        base.NotDetectedBehaviour();

        Debug.Log("OVERRIDE NotDetectedBehaviour");

        if (simpleContactDetection.OnWallLeft)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
        if (simpleContactDetection.OnWallRight)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        }
        rb2D.velocity = new Vector2(walkSpeed * transform.localScale.x, rb2D.velocity.y);

    }

    //IEnumerator JumpAndExplode()
    //{
    //    jumped = true;
    //    rb2D.velocity=new Vector2(rb2D.velocity.x,10f);
    //    yield return new WaitForSeconds(0.5f);
    //    Explode();
    //}

    //void Explode()
    //{
    //    Debug.Log("Explode");
    //    Instantiate(explosion,transform.position,Quaternion.identity);
    //    Destroy(gameObject);
    //}

}

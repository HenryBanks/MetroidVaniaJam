using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingBombHack : Hackable
{
    string MoveText = "<> - Move";
    string ExplodeText = "Space - Explode";

    bool jumped;

    float runSpeed;

    Rigidbody2D rb2d;

    WalkingBombActions walkingBombActions;

    WalkingBombAI walkingBombAI;

    protected override void Awake()
    {
        base.Awake();
        rb2d = GetComponent<Rigidbody2D>();
        jumped = false;
        walkingBombActions = GetComponent<WalkingBombActions>();
        walkingBombAI = GetComponent<WalkingBombAI>();
        runSpeed = walkingBombActions.RunSpeed;
    }


    protected override void Update()
    {
        base.Update();

        if (hacked)
        {
            if (!jumped)
            {
                if (Mathf.Abs(Input.GetAxis("Horizontal"))>0f){
                    rb2d.velocity = new Vector2(Mathf.Sign(Input.GetAxis("Horizontal"))*runSpeed,rb2d.velocity.y);
                }

                if (InputManager.instance.JumpInputUp())
                {
                    jumped = true;
                    CancelHack();
                    walkingBombActions.JumpAndExplode();
                }
            }
        }
    }

    public override void SetHacked()
    {
        base.SetHacked();
        walkingBombAI.SetHacked();
        HackControlsUI.instance.AddControlsText(MoveText);
        HackControlsUI.instance.AddControlsText(ExplodeText);
    }

    protected override void CancelHack()
    {
        base.CancelHack();
        if (!jumped)
        {
            walkingBombAI.SetUnHacked();
        }
    }


}

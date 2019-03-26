using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour {

    ContactDetection contactDetection;
    Rigidbody2D rb2d;
    bool onWallRight;
    bool onWallLeft;

    Vector2 playerSize;

    float jumpVelocityX = 12f;
    float jumpVelocityY = 20f;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerSize = GetComponent<BoxCollider2D>().size;
        contactDetection = GetComponent<ContactDetection>();
    }


    // Update is called once per frame
    void Update () {
        //boxCentreRight = (Vector2)transform.position + Vector2.right * 0.5f * (playerSize.x + boxSize.x);
        //boxCentreLeft = (Vector2)transform.position + Vector2.left * 0.5f * (playerSize.x + boxSize.x);

        //onWallRight = (Physics2D.OverlapBox(boxCentreRight, boxSize, 0f) != null);
        //onWallLeft = (Physics2D.OverlapBox(boxCentreLeft, boxSize, 0f) != null);

        onWallLeft = contactDetection.OnWallLeft;
        onWallRight = contactDetection.OnWallRight;
        

        if((onWallLeft || onWallRight)&& !contactDetection.Grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Max(rb2d.velocity.y, -1f));


            if (InputManager.instance.JumpInputDown())
            {
                Debug.Log("WALL JUMP");


                if (onWallLeft)
                {
                    rb2d.velocity = new Vector2(jumpVelocityX,jumpVelocityY);
                    onWallLeft = false;
                }
                if (onWallRight)
                {
                    rb2d.velocity = new Vector2(-jumpVelocityX, jumpVelocityY);
                    onWallRight = false;
                }
            }
        }

    }

}

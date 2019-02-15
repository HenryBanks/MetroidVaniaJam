using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    ContactDetection contactDetection;

    bool jumping;

    float fallMultiplier=4.2f;

    float jumpVelocity = 21f;

    float groundedSkin = 0.05f;

    Rigidbody2D rb2d;

    Vector2 boxCentre;

    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        contactDetection = GetComponent<ContactDetection>();
        rb2d.gravityScale = fallMultiplier;
    }


    void Update()
    {


        if (GetComponent<PlayerInput>().JumpInputDown())
        {
            Debug.Log("JUMP INPUT");
            Debug.Log(contactDetection.Grounded);
            if (contactDetection.Grounded)
            {
                //GetComponent<PlayerSounds> ().PlaySound (SoundName.Jump);
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpVelocity);
                //grounded = false;
                jumping = true;
                Debug.Log("FLOOR JUMP");

            }
        }

        if (jumping)
        {
            if(GetComponent<PlayerInput>().JumpInputUp())
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Min(rb2d.velocity.y, 0.0f));
                jumping = false;
            }
        }
    }

}

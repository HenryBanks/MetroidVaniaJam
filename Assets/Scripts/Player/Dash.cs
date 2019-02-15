using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    bool canDash;
    Rigidbody2D rb2d;
    ContactDetection contactDetection;
    PlayerInput playerInput;
    Player player;

    float dashSpeed = 60f;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        contactDetection = GetComponent<ContactDetection>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (canDash && playerInput.DashInputDown())
        {
            Debug.Log("DASH");
            StartCoroutine(RunDash(Mathf.Sign(Input.GetAxis("Horizontal"))));
            canDash = false;
        }

        if (contactDetection.Grounded)
        {
            canDash = true;
        }
    }

    IEnumerator RunDash(float direction)
    {
        player.EnableMoveJump(false);
        rb2d.velocity = new Vector2(direction*dashSpeed, 0.0f);
        rb2d.gravityScale = 0.0f;
        yield return new WaitForSeconds(0.15f);
        rb2d.velocity = new Vector2(0.0f, 0.0f);
        player.EnableMoveJump(true);
        rb2d.gravityScale = player.Gravity;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    PlayerJump meatJump;
    PlayerMove meatMove;
    WallJump wallJump;
    ContactDetection contactDetection;
    Dash dash;
    PlayerInput playerInput;

    float gravity = 4.2f;
    public float Gravity { get { return gravity; } }

    // Use this for initialization
    void Awake () {
		DontDestroyOnLoad (gameObject);
        meatJump = GetComponent<PlayerJump>();
        meatMove = GetComponent<PlayerMove>();
        wallJump = GetComponent<WallJump>();
        contactDetection = GetComponent<ContactDetection>();
        dash = GetComponent<Dash>();
        playerInput = GetComponent<PlayerInput>();
	}


    // Update is called once per frame
    void Update () {
		
	}

    public void EnableMoveJump(bool enable)
    {
        meatMove.enabled = enable;
        meatJump.enabled = enable;
    }



}

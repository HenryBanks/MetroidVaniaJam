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

    public static Player instance;

    // Use this for initialization
    void Awake () {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
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

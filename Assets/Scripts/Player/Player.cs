﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    PlayerDamage playerDamage;
    PlayerJump meatJump;
    PlayerMove meatMove;
    WallJump wallJump;
    ContactDetection contactDetection;
    Dash dash;
    Hack hack;

    public int respawnScene=0;
    public int respawnIndex=0;

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
        playerDamage = GetComponent<PlayerDamage>();
        meatJump = GetComponent<PlayerJump>();
        meatMove = GetComponent<PlayerMove>();
        wallJump = GetComponent<WallJump>();
        contactDetection = GetComponent<ContactDetection>();
        dash = GetComponent<Dash>();
        hack = GetComponent<Hack>();
	}


    // Update is called once per frame
    void Update () {
		
	}

    public void EnableMoveJump(bool enable)
    {
        meatMove.enabled = enable;
        meatJump.enabled = enable;
    }

    public void EnableActions(bool enable)
    {
        meatJump.enabled = enable;
        meatMove.enabled = enable;
        wallJump.enabled = enable;
        dash.enabled = enable;
        hack.enabled = enable;

    }

    public void Respawn()
    {
        playerDamage.ResetDying();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInput {

    public static bool PauseKeyDown()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    public static bool AttackInputDown()
    {
        return Input.GetKeyDown(KeyCode.LeftControl);
    }

    public static bool InteractInput()
    {
        return Input.GetKey(KeyCode.E);
    }

    public static bool CancelInputUp()
    {
        return Input.GetKeyUp(KeyCode.C);
    }

    public static bool HackInputDown()
    {
        return Input.GetKeyDown(KeyCode.H);
    }

    public static bool HackInput()
    {
        return Input.GetKey(KeyCode.H);
    }

    public static bool HackInputUp()
    {
        return Input.GetKeyUp(KeyCode.H);
    }

    public static bool JumpInput(){
		bool jumpRequest = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton16);
		return jumpRequest;
	}

    public static bool JumpInputDown()
    {
        bool jumpRequest = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton16);
        return jumpRequest;
    }

    public static bool JumpInputUp()
    {
        bool jumpRequest = Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.JoystickButton16);
        return jumpRequest;
    }

    public static bool DashInputDown(){
		return Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.JoystickButton14);
	}

    public static bool ShootInput()
    {
        return Input.GetKey(KeyCode.Mouse0);
    }


}

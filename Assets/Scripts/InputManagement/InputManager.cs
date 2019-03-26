using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager instance;

    public KeyCode attackButton=KeyCode.LeftControl;
    public KeyCode interactButton=KeyCode.E;
    public KeyCode cancelButton=KeyCode.C;
    public KeyCode hackButton=KeyCode.H;
    public KeyCode jumpButton=KeyCode.Space;
    public KeyCode dashButton=KeyCode.Q;

    public KeyCode attackButton2 = KeyCode.LeftControl;
    public KeyCode interactButton2 = KeyCode.E;
    public KeyCode cancelButton2 = KeyCode.C;
    public KeyCode hackButton2 = KeyCode.H;
    public KeyCode jumpButton2 = KeyCode.Space;
    public KeyCode dashButton2 = KeyCode.Q;

    public KeyCode pauseButton;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public bool PauseKeyDown()
    {
        return Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(pauseButton);
    }

    public bool AttackInputDown()
    {
        return Input.GetKeyDown(attackButton) || Input.GetKeyDown(attackButton2);
    }

    public bool InteractInput()
    {
        return Input.GetKey(interactButton) || Input.GetKey(interactButton2);
    }

    public bool CancelInputUp()
    {
        return Input.GetKeyUp(cancelButton) || Input.GetKeyUp(cancelButton2);
    }

    public bool HackInputDown()
    {
        return Input.GetKeyDown(hackButton) || Input.GetKeyDown(hackButton2);
    }

    public bool HackInput()
    {
        return Input.GetKey(hackButton) || Input.GetKey(hackButton2);
    }

    public bool HackInputUp()
    {
        return Input.GetKeyUp(hackButton) || Input.GetKeyUp(hackButton2);
    }

    public bool JumpInput()
    {
        bool jumpRequest = Input.GetKey(jumpButton) || Input.GetKey(jumpButton2);
        return jumpRequest;
    }

    public bool JumpInputDown()
    {
        bool jumpRequest = Input.GetKeyDown(jumpButton) || Input.GetKeyDown(jumpButton2);
        return jumpRequest;
    }

    public bool JumpInputUp()
    {
        bool jumpRequest = Input.GetKeyUp(jumpButton) || Input.GetKeyUp(jumpButton2);
        return jumpRequest;
    }

    public bool DashInputDown()
    {
        return Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(dashButton) || Input.GetKeyDown(dashButton2);
    }




}

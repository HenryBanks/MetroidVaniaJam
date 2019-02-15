using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool JumpInput(){
		bool jumpRequest = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton16);
		return jumpRequest;
	}

    public bool JumpInputDown()
    {
        bool jumpRequest = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton16);
        return jumpRequest;
    }

    public bool JumpInputUp()
    {
        bool jumpRequest = Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.JoystickButton16);
        return jumpRequest;
    }

    public bool DashInputDown(){
		return Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.JoystickButton14);
	}

    public bool ShootInput()
    {
        return Input.GetKey(KeyCode.Mouse0);
    }


}

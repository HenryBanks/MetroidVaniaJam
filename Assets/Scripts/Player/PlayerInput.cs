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
		bool jumpRequest = Input.GetKey(KeyCode.Space);
		return jumpRequest;
	}

    public bool JumpInputDown()
    {
        bool jumpRequest = Input.GetKeyDown(KeyCode.Space);
        return jumpRequest;
    }

    public bool JumpInputUp()
    {
        bool jumpRequest = Input.GetKeyUp(KeyCode.Space);
        return jumpRequest;
    }

    public bool DashInputDown(){
		return Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftShift);
	}


}

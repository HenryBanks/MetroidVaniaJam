using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : Hackable
{

    string DoorOpenText = "Space - Open Door";

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (hacked)
        {
            if (InputManager.instance.JumpInputUp())
            {
                OpenDoor();
            }
        }
    }

    void OpenDoor()
    {
        CancelHack();
        Destroy(gameObject);
    }

    public override void SetHacked()
    {
        base.SetHacked();
        HackControlsUI.instance.AddControlsText(DoorOpenText);
    }

}

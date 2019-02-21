using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hackable : MonoBehaviour
{
    protected bool hacked;

    protected string cancelText;

    private void Awake()
    {
        cancelText = "C - Cancel Hack";
        hacked = false;
    }

    protected virtual void Update()
    {
        if (PlayerInput.CancelInputUp() && hacked)
        {
            CancelHack();
        }
    }

    protected virtual void CancelHack()
    {
        hacked = false;
        Debug.Log("HACK CANCELED");
        Camera.main.transform.parent = Player.instance.transform;
        Camera.main.transform.localPosition = new Vector3(0f, 0f, -15f);
        Player.instance.EnableActions(true);
        HackControlsUI.instance.ClearControls();
    }

    public virtual void SetHacked()
    {
        hacked = true;
        Debug.Log(gameObject.name + " HACKED");
        Camera.main.transform.parent = transform;
        Camera.main.transform.localPosition = new Vector3(0f, 0f, -15f);
        Player.instance.EnableActions(false);
        HackControlsUI.instance.DisplayControls();
        HackControlsUI.instance.AddControlsText(cancelText);
    }

}

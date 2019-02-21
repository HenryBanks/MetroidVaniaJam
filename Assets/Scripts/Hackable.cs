using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hackable : MonoBehaviour
{
    bool hacked;

    private void Awake()
    {
        hacked = false;
    }

    private void Update()
    {
        if (PlayerInput.HackInputUp() && hacked)
        {
            CancelHack();
        }
    }

    void CancelHack()
    {
        hacked = false;
        Debug.Log("HACK CANCELED");
        Camera.main.transform.parent = Player.instance.transform;
        Camera.main.transform.localPosition = new Vector3(0f, 0f, -15f);
        Player.instance.EnableActions(false);
    }

    public void SetHacked()
    {
        hacked = true;
    }

}

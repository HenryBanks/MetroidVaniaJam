using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSettings : MonoBehaviour
{

    public enum ButtonType {None, Attack, Interact, Cancel, Hack, Jump, Dash, Attack2, Interact2, Cancel2, Hack2, Jump2, Dash2 };

    public ButtonType ButtonToSet { private get; set; }

    Button buttonClicked;

    private void Awake()
    {

    }

    public void SetButton(int buttonTypeID)
    {
        ButtonToSet = (ButtonType)buttonTypeID;
    }

    private void Update()
    {
        if (ButtonToSet != ButtonType.None)
        {
            System.Array values = System.Enum.GetValues(typeof(KeyCode));
            foreach (KeyCode code in values)
            {
                if (Input.GetKeyDown(code) && (code>KeyCode.Mouse6 || code < KeyCode.Mouse0))
                {
                    Debug.Log(System.Enum.GetName(typeof(KeyCode), code));
                    switch (ButtonToSet)
                    {
                        case ButtonType.None:
                            break;
                        case ButtonType.Attack:
                            InputManager.instance.attackButton = code;
                            Debug.Log("Attack Button: " + System.Enum.GetName(typeof(KeyCode), code));
                            break;
                        case ButtonType.Interact:
                            InputManager.instance.interactButton = code;
                            Debug.Log("Interact Button: " + System.Enum.GetName(typeof(KeyCode), code));
                            break;
                        case ButtonType.Cancel:
                            InputManager.instance.cancelButton = code;
                            Debug.Log("Cancel Button: " + System.Enum.GetName(typeof(KeyCode), code));
                            break;
                        case ButtonType.Hack:
                            InputManager.instance.hackButton = code;
                            Debug.Log("Hack Button: " + System.Enum.GetName(typeof(KeyCode), code));
                            break;
                        case ButtonType.Jump:
                            InputManager.instance.jumpButton = code;
                            Debug.Log("Jump Button: " + System.Enum.GetName(typeof(KeyCode), code));
                            break;
                        case ButtonType.Dash:
                            InputManager.instance.dashButton = code;
                            Debug.Log("Dash Button: " + System.Enum.GetName(typeof(KeyCode), code));
                            break;
                        case ButtonType.Attack2:
                            InputManager.instance.attackButton2 = code;
                            Debug.Log("Attack Button2: " + System.Enum.GetName(typeof(KeyCode), code));
                            break;
                        case ButtonType.Interact2:
                            InputManager.instance.interactButton2 = code;
                            Debug.Log("Interact Button2: " + System.Enum.GetName(typeof(KeyCode), code));
                            break;
                        case ButtonType.Cancel2:
                            InputManager.instance.cancelButton2 = code;
                            Debug.Log("Cancel Button2: " + System.Enum.GetName(typeof(KeyCode), code));
                            break;
                        case ButtonType.Hack2:
                            InputManager.instance.hackButton2 = code;
                            Debug.Log("Hack Button2: " + System.Enum.GetName(typeof(KeyCode), code));
                            break;
                        case ButtonType.Jump2:
                            InputManager.instance.jumpButton2 = code;
                            Debug.Log("Jump Button2: " + System.Enum.GetName(typeof(KeyCode), code));
                            break;
                        case ButtonType.Dash2:
                            InputManager.instance.dashButton2 = code;
                            Debug.Log("Dash Button 2: " + System.Enum.GetName(typeof(KeyCode), code));
                            break;
                    }
                    ButtonToSet = ButtonType.None;
                }
            }
        }
    }

    //void OnGUI()
    //{
    //    Event e = Event.current;
    //    if (e.isKey)
    //    {
    //        Debug.Log("Detected key code: " + e.keyCode);
    //        switch (ButtonToSet)
    //        {
    //            case ButtonType.None:
    //                break;
    //            case ButtonType.Attack:
    //                InputManager.instance.attackButton = e.keyCode;
    //                break;
    //            case ButtonType.Interact:
    //                InputManager.instance.interactButton = e.keyCode;
    //                break;
    //            case ButtonType.Cancel:
    //                InputManager.instance.cancelButton = e.keyCode;
    //                break;
    //            case ButtonType.Hack:
    //                InputManager.instance.hackButton = e.keyCode;
    //                break;
    //            case ButtonType.Jump:
    //                InputManager.instance.jumpButton = e.keyCode;
    //                break;
    //            case ButtonType.Dash:
    //                InputManager.instance.dashButton = e.keyCode;
    //                break;
    //            case ButtonType.Attack2:
    //                InputManager.instance.attackButton2 = e.keyCode;
    //                break;
    //            case ButtonType.Interact2:
    //                InputManager.instance.interactButton2 = e.keyCode;
    //                break;
    //            case ButtonType.Cancel2:
    //                InputManager.instance.cancelButton2 = e.keyCode;
    //                break;
    //            case ButtonType.Hack2:
    //                InputManager.instance.hackButton2 = e.keyCode;
    //                break;
    //            case ButtonType.Jump2:
    //                InputManager.instance.jumpButton2 = e.keyCode;
    //                break;
    //            case ButtonType.Dash2:
    //                InputManager.instance.dashButton2 = e.keyCode;
    //                break;
    //        }
    //        ButtonToSet = ButtonType.None;
    //    }
    //}

    private bool isControllerInput()
    {
        // joystick buttons
        if (Input.GetKey(KeyCode.Joystick1Button0) ||
           Input.GetKey(KeyCode.Joystick1Button1) ||
           Input.GetKey(KeyCode.Joystick1Button2) ||
           Input.GetKey(KeyCode.Joystick1Button3) ||
           Input.GetKey(KeyCode.Joystick1Button4) ||
           Input.GetKey(KeyCode.Joystick1Button5) ||
           Input.GetKey(KeyCode.Joystick1Button6) ||
           Input.GetKey(KeyCode.Joystick1Button7) ||
           Input.GetKey(KeyCode.Joystick1Button8) ||
           Input.GetKey(KeyCode.Joystick1Button9) ||
           Input.GetKey(KeyCode.Joystick1Button10) ||
           Input.GetKey(KeyCode.Joystick1Button11) ||
           Input.GetKey(KeyCode.Joystick1Button12) ||
           Input.GetKey(KeyCode.Joystick1Button13) ||
           Input.GetKey(KeyCode.Joystick1Button14) ||
           Input.GetKey(KeyCode.Joystick1Button15) ||
           Input.GetKey(KeyCode.Joystick1Button16) ||
           Input.GetKey(KeyCode.Joystick1Button17) ||
           Input.GetKey(KeyCode.Joystick1Button18) ||
           Input.GetKey(KeyCode.Joystick1Button19))
        {
            return true;
        }

        // joystick axis
        if (Mathf.Abs(Input.GetAxis("XC Left Stick X")) > Mathf.Epsilon ||
           Mathf.Abs(Input.GetAxis("XC Left Stick Y")) > Mathf.Epsilon ||
           Mathf.Abs(Input.GetAxis("XC Triggers")) > Mathf.Epsilon ||
           Mathf.Abs(Input.GetAxis("XC Right Stick X")) > Mathf.Epsilon ||
           Mathf.Abs(Input.GetAxis("XC Right Stick Y")) > Mathf.Epsilon)
        {
            return true;
        }

        return false;
    }

}

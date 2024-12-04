using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string HorizontalAxisValue = "Horizontal";

    private KeyCode _jumpKeyCode = KeyCode.Space;
    public float GetMoveInput()
    {
        return Input.GetAxis(HorizontalAxisValue);
    }

    public bool GetIsJump()
    {
        return Input.GetKeyDown(_jumpKeyCode);
    }
}
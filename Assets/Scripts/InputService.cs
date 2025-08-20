using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string HorizontalAxisValue = "Horizontal";

    private KeyCode _jumpKeyCode = KeyCode.Space;
    private KeyCode _attackKeyCode = KeyCode.LeftAlt;

    public float GetMoveInput()
    {
        return Input.GetAxis(HorizontalAxisValue);
    }

    public bool GetIsJump()
    {
        return Input.GetKeyDown(_jumpKeyCode);
    }

    public bool GetIsAttack()
    {
        return Input.GetKeyDown(_attackKeyCode);
    }
}
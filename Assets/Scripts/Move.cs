using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer), typeof(AnimatorService), typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private InputService _inputService;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private AnimatorService _animatorService;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animatorService = GetComponent<AnimatorService>();
    }

    void Update()
    {
        HandleMove();
    }

    private void HandleMove()
    {
        float moveInput = _inputService.GetMoveInput();
        var moveDirection = GetMoveDirection(moveInput);
        _rigidbody.velocity = new Vector2(moveInput * _speed, _rigidbody.velocity.y);

        switch (moveDirection)
        {
            case MovingDirection.Left:
                _spriteRenderer.flipX = true;
                _animatorService.SetMovingAnimation(true);
                break;

            case MovingDirection.Right:
                _spriteRenderer.flipX = false;
                _animatorService.SetMovingAnimation(true);
                break;

            case MovingDirection.Stand:
                _animatorService.SetMovingAnimation(false);
                break;

            default:
                break;
        }
    }

    private MovingDirection GetMoveDirection(float moveInput)
    {
        if(moveInput > 0)
        {
            return MovingDirection.Right;
        }

        if(moveInput < 0)
        {
            return MovingDirection.Left;
        }

        return MovingDirection.Stand;

    }
    private enum MovingDirection
    {
        Left,
        Right,
        Stand
    }
}

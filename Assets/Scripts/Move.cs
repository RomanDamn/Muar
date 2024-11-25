using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMove();
    }

    private void HandleMove()
    {
        float moveInput = Input.GetAxis("Horizontal");
        var moveDirection = GetMoveDirection(moveInput);
        _rigidbody.velocity = new Vector2(moveInput * _speed, _rigidbody.velocity.y);

        switch (moveDirection)
        {
            case MovingDirection.Left:
                _spriteRenderer.flipX = true;
                _animator.SetBool("IsMoving", true);
                break;

            case MovingDirection.Right:
                _spriteRenderer.flipX = false;
                GetComponent<Animator>().SetBool("IsMoving", true);
                break;

            case MovingDirection.Stand:
                GetComponent<Animator>().SetBool("IsMoving", false);
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

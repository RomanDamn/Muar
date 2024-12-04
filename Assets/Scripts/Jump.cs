using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private LayerMask _platformMask;
    [SerializeField] private InputService _inputService;
    [SerializeField] private float _velocityByY = 4.2f;

    private BoxCollider2D _collider;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        if (_inputService.GetIsJump() && GetIsGrounded() == true)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _velocityByY);
        }
    }

    private bool GetIsGrounded()
    {
        var angle = 0f;
        var distance = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, angle, Vector2.down, distance, _platformMask);
        return raycastHit.collider != null;
    }
}

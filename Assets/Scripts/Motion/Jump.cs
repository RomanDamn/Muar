using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private float _velocityByY = 4.2f;
    [SerializeField] private GroundDetector _groundDetector;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        if (_inputService.GetIsJump() && _groundDetector.GetIsGrounded(_collider))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _velocityByY);
        }
    }
}

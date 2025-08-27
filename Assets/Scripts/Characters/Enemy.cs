using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Vector2 _targetPosition;

    private float _movingAccuracy = 0.1f;
    private bool _isFlipped = false;
    private Vector2 _basePosition;
    private Vector2? _heroPosition;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _basePosition = transform.position;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health heroHealth = collision.gameObject.GetComponent<Health>();

        if (heroHealth != null)
        {
            heroHealth.TakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hero hero = collision.GetComponent<Hero>();

        if(hero != null && collision.isTrigger == false)
        {
            _heroPosition = collision.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Hero hero = collision.GetComponent<Hero>();

        if (hero != null && collision.isTrigger == false)
        {
            _heroPosition = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Hero hero = collision.GetComponent<Hero>();

        if (hero != null)
        {
            if (GetIsLookToHero() == true)
            {
                ToggleFlipX();
            }

            _heroPosition = null;
        }
    }

    private void Move()
    {
        var isPointReached = Vector3Extensions.GetIsEnoughClose(transform.position, _targetPosition, _movingAccuracy);
        var step = _speed * Time.deltaTime;
        var isLookToHero = GetIsLookToHero() == true;

        if (_heroPosition != null && isLookToHero)
        {
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)_heroPosition, step);
            return;
        }

        if (isPointReached)
        {
            var tempTargetPosition = _targetPosition;
            _targetPosition = _basePosition;
            _basePosition = tempTargetPosition;

            if(GetIsTargetInOposite())
            {
                ToggleFlipX();
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, step);
    }

    private void ToggleFlipX()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        _isFlipped = !_isFlipped;
    }

    public bool GetIsLookToHero()
    {
        if(_heroPosition == null)
        {
            return false;
        }
        bool isFacingRight = IsFacingRight();
        bool playerIsOnRight = _heroPosition.Value.x > transform.position.x;
        return isFacingRight == playerIsOnRight;
    }

    public bool GetIsTargetInOposite()
    {
        bool isFacingRight = IsFacingRight();
        bool targetIsOnRight = _targetPosition.x > _basePosition.x;
        return isFacingRight != targetIsOnRight;
    }

    private bool IsFacingRight()
    {
        return !_isFlipped;
    }
}


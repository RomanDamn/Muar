using System;
using UnityEngine;

[RequireComponent(typeof(AnimatorService), typeof(InputService))]
public class Attack : MonoBehaviour
{
    private InputService _inputService;
    private AnimatorService _animatorService;

    private Health _enemyHealthInTrigger;

    private void Awake()
    {
        _inputService = GetComponent<InputService>();
        _animatorService = GetComponent<AnimatorService>();
    }

    private void Update()
    {
        HandleAttack();
    }

    private void HandleAttack()
    {
        if (_inputService.GetIsAttack())
        {
            _animatorService.StartAttackAnimation();


            if (_enemyHealthInTrigger != null)
            {
                _enemyHealthInTrigger.TakeDamage();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health enemyHealth = collision.GetComponent<Health>();
        bool isCollisionTrigger = collision.isTrigger;

        if (enemyHealth != null && isCollisionTrigger == false)
        {
            _enemyHealthInTrigger = enemyHealth;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            _enemyHealthInTrigger = null;
        }
    }
}
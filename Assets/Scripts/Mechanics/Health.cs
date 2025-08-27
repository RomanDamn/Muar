using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimatorService))]
public class Health : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damageStep;

    private AnimatorService _animatorService;

    private void Awake()
    {
        _animatorService = GetComponent<AnimatorService>();
    }

    public void OnDeathAnimationComplete()
    {
        gameObject.SetActive(false);
    }

    public void TakeDamage()
    {
        _health -= _damageStep;
        bool isDead = CheckIsDied();

        if (isDead)
        {
            Die();
            return;
        }

        _animatorService.StartDamageAnimation();
    }

    public void IncreaseHealth(int health)
    {
        _health += health;
    }

    private void Die()
    {
        _animatorService.StartDeathAnimation();
    }

    private bool CheckIsDied()
    {
        return _health <= 0;
    }

}

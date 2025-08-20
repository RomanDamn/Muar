using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorService : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMovingAnimation(bool isMoving)
    {
        _animator.SetBool("IsMoving", isMoving);
    }

    public void StartAttackAnimation()
    {
        _animator.SetBool("IsAttack", true);
    }

    public void StopAttackAnimation()
    {
        _animator.SetBool("IsAttack", false);
    }

    public void StartDeathAnimation()
    {
        _animator.SetBool("IsDeath", true);
    }

    public void StopDeathAnimation()
    {
        _animator.SetBool("IsDeath", false);
    }

    public void StartDamageAnimation()
    {
        _animator.SetBool("IsDamage", true);
    }

    public void StopDamageAnimation()
    {
        _animator.SetBool("IsDamage", false);
    }
}
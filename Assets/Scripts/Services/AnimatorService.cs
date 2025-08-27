using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorService : MonoBehaviour
{
    public static class Params
    {
        public static readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
        public static readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
        public static readonly int IsDeath = Animator.StringToHash(nameof(IsDeath));
        public static readonly int IsDamage = Animator.StringToHash(nameof(IsDamage));
    }

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMovingAnimation(bool isMoving)
    {
        _animator.SetBool(Params.IsMoving, isMoving);
    }

    public void StartAttackAnimation()
    {
        _animator.SetBool(Params.IsAttack, true);
    }

    public void StopAttackAnimation()
    {
        _animator.SetBool(Params.IsAttack, false);
    }

    public void StartDeathAnimation()
    {
        _animator.SetBool(Params.IsDeath, true);
    }

    public void StopDeathAnimation()
    {
        _animator.SetBool(Params.IsDeath, false);
    }

    public void StartDamageAnimation()
    {
        _animator.SetBool(Params.IsDamage, true);
    }

    public void StopDamageAnimation()
    {
        _animator.SetBool(Params.IsDamage, false);
    }
}
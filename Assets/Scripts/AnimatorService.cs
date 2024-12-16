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
}
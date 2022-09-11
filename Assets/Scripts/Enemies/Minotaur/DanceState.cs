using UnityEngine;

[RequireComponent(typeof(Animator))]

public class DanceState : State
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(AnimatorMinotaurController.States.Dance);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}

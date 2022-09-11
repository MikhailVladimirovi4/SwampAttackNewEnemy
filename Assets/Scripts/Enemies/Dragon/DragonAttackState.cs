using UnityEngine;

[RequireComponent(typeof(Animator))]

public class DragonAttackState : State
{
    [SerializeField] private float _delay;
    [SerializeField] private FireBall FireBall;

    private float _lastAttackTime;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack();
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack()
    {
        _animator.Play(AnimatorDragonController.States.Attack);
        FireBall fireball = Instantiate(FireBall, transform.position, Quaternion.identity);
        fireball.Init(Target);
    }
}

using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    public event UnityAction<Enemy> Dying;
    private Hero _target;

    public Hero Target => _target;
    public int Reward => _reward;

    public void Init(Hero target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }
}

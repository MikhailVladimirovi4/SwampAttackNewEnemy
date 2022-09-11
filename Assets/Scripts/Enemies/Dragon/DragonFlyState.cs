using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Dragon))]

public class DragonFlyState : State
{
    [SerializeField] private float _speed;

    private Transform _flyTarget;

    private void OnEnable()
    {
        _flyTarget = GetComponent<Dragon>().FlyTarget;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _flyTarget.position, _speed * Time.deltaTime);
    }
}

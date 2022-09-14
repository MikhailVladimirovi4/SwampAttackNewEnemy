using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Blast))]


public class Rocket : StrikingElement
{
    private Vector3 _targetPosition;
    private bool _isBlast = false;
    private Blast _blast;

    public override void Init()
    {
        _targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        _blast = GetComponent<Blast>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, Speed * Time.deltaTime);

        if (transform.position.x == _targetPosition.x && transform.position.y == _targetPosition.y)
        {
            MakeBlast();
        }
    }

    private void MakeBlast()
    {
        _isBlast = true;
        StartCoroutine(_blast.GetBlast());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isBlast == false)
            return;

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
        }
    }
}

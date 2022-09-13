using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Cartrige
{
    private Vector3 _targetPosition;

    public override void Init()
    {
        _targetPosition = Input.mousePosition;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, Speed * Time.deltaTime);

        if (transform.position == _targetPosition)
        {
            // Blast blast = Instantiate(Blast)
            Destroy(this);
        }
    }
}

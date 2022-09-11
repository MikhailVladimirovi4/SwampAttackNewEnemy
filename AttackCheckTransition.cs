using UnityEngine;

public class AttackCheckTransition : Transition
{
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _mask;

    
    private void Update()
    {
        if (Physics2D.Raycast(Vector2.right, transform.position, _distance, _mask))
            NeedTransit = true;
    }
}

using UnityEngine;

public class ThreatCheckTransition : Transition
{
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _layerMask;

    private void Update()
    {
        NeedTransit = Physics2D.Raycast(Vector2.right, transform.position, _distance, _layerMask);
    }
}

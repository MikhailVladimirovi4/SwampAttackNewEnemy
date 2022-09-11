using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionDistance;
    [SerializeField] private float _distanceSpread;

    private void Start()
    {
        _transitionDistance += Random.Range(-_transitionDistance, _distanceSpread);
    }

    private void Update()
    {
        NeedTransit = Vector2.Distance(transform.position, MoveTarget.position) < _transitionDistance;
    }
}

using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Hero Target { get; private set; }
    protected Transform MoveTarget { get; private set; }

    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    public void Init(Hero target)
    {
        Target = target;

        if (this.TryGetComponent(out Dragon dragon))
            MoveTarget = dragon.FlyTarget;
        else
            MoveTarget = Target.transform;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}

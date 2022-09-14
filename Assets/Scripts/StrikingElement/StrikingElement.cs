using UnityEngine;

public abstract class StrikingElement : MonoBehaviour
{
    [SerializeField] protected int Damage;
    [SerializeField] protected float Speed;

    abstract public void Init();
}

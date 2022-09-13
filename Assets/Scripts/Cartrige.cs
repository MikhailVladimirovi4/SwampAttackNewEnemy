using UnityEngine;

public abstract class Cartrige : MonoBehaviour
{
    [SerializeField] protected int Damage;
    [SerializeField] protected float Speed;

    abstract public void Init();
}

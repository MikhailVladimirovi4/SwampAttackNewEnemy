using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string Label;
    [SerializeField] private int Price;
    [SerializeField] private Sprite Icon;
    [SerializeField] private bool IsBuyed = false;
    [SerializeField] protected Bullet Bullet;

    public abstract void Shoot(Transform shootPoint);
}

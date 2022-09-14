using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBlaster : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        StrikingElement rocket = Instantiate(StrikingElement, shootPoint.position, Quaternion.identity);
        rocket.Init();
    }
}

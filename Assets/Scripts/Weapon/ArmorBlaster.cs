using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBlaster : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Cartrige rocket = Instantiate(Cartrige, shootPoint.position, Quaternion.identity);
        rocket.Init();
    }
}

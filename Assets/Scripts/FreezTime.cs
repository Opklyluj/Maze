using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezTime : Pickup
{
    public int freezeTime = 10;

    public override void Picked()
    {
        GameManager.instance.FreezTime(freezeTime);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Pickup
{
    public bool addTime;
    public uint time = 5;

    public override void Picked()
    {
        int sign;
        if (addTime)
            sign = 1;
        else
            sign = -1;

        GameManager.instance.AddTime((int)time * sign);
        Destroy(gameObject);
    }
}

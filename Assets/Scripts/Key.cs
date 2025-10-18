using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    public KeyColor color;

    public override void Picked()
    {
        GameManager.instance.AddKey(color);
        Destroy(gameObject);
    }
}

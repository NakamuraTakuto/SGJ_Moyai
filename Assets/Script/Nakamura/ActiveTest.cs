
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ActiveTest : ActiveBase
{
    public override void Active()
    {
        Debug.Log("HIT");
    }
}

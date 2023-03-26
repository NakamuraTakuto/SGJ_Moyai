using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMoyai : ActiveBase
{
    public override void Active()
    {
        GameManager.Instance.MoyaiChange();
        gameObject.SetActive(false);
    }
}

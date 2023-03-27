using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveMoyai : ActiveBase
{
    private GameObject _audioObj;

    private void Start()
    {
        _audioObj = GameObject.Find("Correct");
    }

    public override void Active()
    {
        _audioObj.SetActive(true);
        GameManager.Instance.MoyaiChange();
        gameObject.SetActive(false);
    }
}

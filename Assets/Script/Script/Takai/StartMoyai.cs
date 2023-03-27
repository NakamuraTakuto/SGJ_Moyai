using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoyai : ActiveBase
{
    [SerializeField] private GameObject _startText;

    [SerializeField] private GameObject _moyaiGenarator;

    [SerializeField] private GameObject _audioObj;
    public override void Active()
    {
        GameManager.Instance.IsGame = true;
        _moyaiGenarator.SetActive(true);
        _audioObj.SetActive(true);
        _startText.SetActive(false);
        gameObject.SetActive(false);
    }
}

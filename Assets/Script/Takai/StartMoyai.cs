using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoyai : ActiveBase
{
    [SerializeField] private GameObject _startText;
    
    public override void Active()
    {
        GameManager.Instance.IsGame = true;
        _startText.SetActive(false);
        gameObject.SetActive(false);
    }
}

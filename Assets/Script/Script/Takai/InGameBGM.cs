using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameBGM : MonoBehaviour
{
    [SerializeField] private GameObject _bgm;

    private void Update()
    {
        if (GameManager.Instance.IsGame && !_bgm.activeSelf)
        {
            _bgm.SetActive(true);
            Debug.Log("再生");
        }
        else if(!GameManager.Instance.IsGame && _bgm.activeSelf)
        {
            _bgm.SetActive(false);
            Debug.Log("停止");
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGM : MonoBehaviour
{
    [SerializeField] private int _time;
    private void OnEnable()
    {
        StartCoroutine(ActiveTime());
    }

    IEnumerator ActiveTime()
    {
        yield return new WaitForSeconds(_time);
        gameObject.SetActive(false);
    }
}

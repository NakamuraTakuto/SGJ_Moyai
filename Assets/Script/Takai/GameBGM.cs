using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGM : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}

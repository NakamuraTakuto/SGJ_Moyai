using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultySelection : MonoBehaviour
{
    [SerializeField]
    GameObject _difficultySelection;
    Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Selected);
    }

    private void Selected()
    {
        _difficultySelection.SetActive(true);
    }
}

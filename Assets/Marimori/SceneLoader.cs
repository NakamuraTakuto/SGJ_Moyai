using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    /// <summary>変えたいシーンの名前</summary>
    [SerializeField] string _changeScene;
    Button _button;
    private void Start()
    {
        _button.onClick.AddListener(LoadScenes);
    }
    public void LoadScenes()
    {
        SceneManager.LoadScene(_changeScene);
    }
}

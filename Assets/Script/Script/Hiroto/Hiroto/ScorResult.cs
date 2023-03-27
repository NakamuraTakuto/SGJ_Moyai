using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScorResult : MonoBehaviour
{
    [SerializeField] GameObject _moyai;
    [SerializeField] GameObject _genelater;

    [SerializeField] private TextMeshProUGUI _scoreText;
    // Start is called before the first frame update
    void Start()
    {
      for (int i = 0; i < GameManager.Instance.Score; i++)
        {
            Instantiate(_moyai, _genelater.transform.position, Quaternion.identity);
        }

      if (GameManager.Instance)
      {
          _scoreText.text = GameManager.Instance.Score.ToString();    
      }
      
    }
}

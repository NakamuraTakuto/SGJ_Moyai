using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField][Header("ゲームプレイ中")]
    bool _isGame = true;

    [SerializeField][Header("プレイ時間の初期値")]
    public float _gameOverTime = 60f;

    [SerializeField][Header("経過時間")]
    public float _timeCount;
    public float _time;

    [SerializeField]
    [Header("モヤイカウント")]
    GameObject[] _moyaiObject;
    public float _moyaiNorma = 0f;
    public float _moyaiCount;

    [Header("UI-Play")]
    [SerializeField] TextMeshProUGUI _timetext;
    [SerializeField] GameObject _gage0;
    [SerializeField] GameObject[] _moyaimage;

    [Header("UI-end")]
    [SerializeField] GameObject _gameover;
    [SerializeField] GameObject _gameclear;
    [SerializeField] GameObject _retry;
    [SerializeField] GameObject _title;
    [SerializeField] GameObject _next;
    //public float _norma = _moyaiObject.Length;
    void Start()
    {        

    }

    // Update is called once per frame
    void Update()
    {
        if (_isGame)
        {
            _time += Time.deltaTime;
            _timeCount = _gameOverTime - _time;
            _timetext.text = $"{_timeCount.ToString("F0")}";

            if(_moyaiNorma <= 0)
            {
                _isGame = false;
                _gameclear.gameObject.SetActive(true);
                _next.gameObject.SetActive(true);
                _retry.gameObject.SetActive(true);
                _next.gameObject.SetActive(true);
            }
            else if(_timeCount <= 0)
            {
                _isGame = false;
                _gameover.gameObject.SetActive(true);
                _retry.gameObject.SetActive(true);
                _next.gameObject.SetActive(true);
            }
        }
    }
}

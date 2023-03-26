using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Header("ゲームプレイ中")]
    public bool IsGame = true;
    [SerializeField] AttachmentObj _attach;
    [SerializeField] SetValues _value;

    float _timeCount;
    float _time;

    Text _timetext;
    GameObject _gage0;
    GameObject[] _moyaimage;

    GameObject _gameover;
    GameObject _gameclear;
    GameObject _retry;
    GameObject _next;
    GameObject _title;

    float _gameOverTime;
    float _moyaiNorma;
    int _moyaiCount = 0;

    //public float _norma = _moyaiObject.Length;
    void Start()
    {
        _timetext = _attach.GetTimeText;
        _gage0 = _attach.GetGage0;
        _moyaimage = _attach.GetMoyaiImage;
        _gameover = _attach.GetGameOver;
        _gameclear = _attach.GetGameClear;
        _retry = _attach.GetRetry;
        _next = _attach.GetNext;
        _title = _attach.GetTitle;
        _gameOverTime = _value.GetOverTime;
        _moyaiNorma = _value.GetMoyaiNorma;
    }
    // Update is called once per frame
    void Update()
    {
        if (IsGame)
        {
            _time += Time.deltaTime;
            _timeCount = _gameOverTime - _time;
            _timetext.text = $"{_timeCount.ToString("F0")}";

            if (_timeCount <= 0)
            {
                GameOver();
            }
        }
    }

    public void MoyaiChange()
    {
        _moyaimage[_moyaiCount].GetComponent<Renderer>()
            .material.color = Color.white;
        _moyaiCount++;

        if (_moyaiCount >= _moyaimage.Length)
        {
            GameClear();
        }
    }

    void GameClear()
    {
        _gameclear.gameObject.SetActive(true);
        _next.gameObject.SetActive(true);
        _retry.gameObject.SetActive(true);
        _title.gameObject.SetActive(true);
        IsGame = false;
    }

    void GameOver()
    {
        _gameover.gameObject.SetActive(true);
        _retry.gameObject.SetActive(true);
        _title.gameObject.SetActive(true);
        IsGame = false;
    }

    [System.Serializable]
    class AttachmentObj
    {
        [SerializeField] GameObject _gameover;
        public GameObject GetGameOver => _gameover;
        [SerializeField] GameObject _gameclear;
        public GameObject GetGameClear => _gameclear;
        [SerializeField] GameObject _retry;
        public GameObject GetRetry => _retry;
        [SerializeField] GameObject _title;
        public GameObject GetTitle => _title;
        [SerializeField] GameObject _next;
        public GameObject GetNext => _next;[Header("UI-Play")]
        [SerializeField] Text _timetext;
        public Text GetTimeText => _timetext;
        [SerializeField] GameObject _gage0;
        public GameObject GetGage0 => _gage0;
        [SerializeField] GameObject[] _moyaimage;
        public GameObject[] GetMoyaiImage => _moyaimage;
        [SerializeField] GameObject[] _moyaiObject;
        public GameObject[] GetMoyaiObject => _moyaiObject;

    }
    [System.Serializable]
    class SetValues
    {
        [Header("プレイ時間の初期値")]
        [SerializeField] float _gameOverTime = 60f;
        public float GetOverTime => _gameOverTime;

        [Header("モヤイカウント")]
        [SerializeField] float _moyaiNorma = 0f;
        public float GetMoyaiNorma => _moyaiNorma;
    }
}
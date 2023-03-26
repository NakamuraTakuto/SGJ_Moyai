using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Start is called before the first frame update
    [SerializeField]
    [Header("ゲームプレイ中")]
    public bool IsGame = true;
    [SerializeField] AttachmentObj _attach;
    [SerializeField] SetValues _value;

    float _timeCount;
    float _time;

    TextMeshPro _timetext;
    GameObject[] _moyaimage;

    GameObject _gameover;
    GameObject _gameclear;
    GameObject _retry;
    GameObject _next;
    GameObject _title;

    float _gameOverTime;
    int _moyaiCount = 0;

    //public float _norma = _moyaiObject.Length;
    private void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        _timetext = _attach.GetTimeText;
        _moyaimage = _attach.GetMoyaiImage;
        _gameover = _attach.GetGameOver;
        _gameclear = _attach.GetGameClear;
        _retry = _attach.GetRetry;
        _next = _attach.GetNext;
        _title = _attach.GetTitle;
        _gameOverTime = _value.GetOverTime;
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
        public GameObject GetGameOver
        {
            set { _gameover = value; }
            get { return _gameover; }
        }

        [SerializeField] GameObject _gameclear;
        public GameObject GetGameClear
        {
            set { _gameclear = value; }
            get { return _gameclear; }
        }

        [SerializeField] GameObject _retry;
        public GameObject GetRetry
        {
            set { _retry = value; }
            get { return _retry; }
        }

        [SerializeField] GameObject _title;
        public GameObject GetTitle
        {
            set { _title = value; }
            get { return _title; }
        }

        [SerializeField] GameObject _next;
        public GameObject GetNext
        {
            set { _next = value; }
            get { return _next; }
        }

        [SerializeField] TextMeshPro _timetext;
        public TextMeshPro GetTimeText
        {
            set { _timetext = value; }
            get { return _timetext; }
        }

        [SerializeField] GameObject[] _moyaimage;
        public GameObject[] GetMoyaiImage
        {
            set { _moyaimage = value; }
            get { return _moyaimage; }
        }
    }
    [System.Serializable]
    class SetValues
    {
        [Header("プレイ時間の初期値")]
        [SerializeField] float _gameOverTime = 60f;
        public float GetOverTime => _gameOverTime;
    }
}
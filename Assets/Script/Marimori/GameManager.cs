using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("現在使用しているカメラ")]
    [SerializeField] int _nowCamera = 0;
    public int GetNowCamera
    {
        set { _nowCamera = value; }
        get { return _nowCamera; }
    }

    public static GameManager Instance;
    [SerializeField] public bool IsGame = true;
    [SerializeField] AttachmentObj _attach;
    [SerializeField] SetValues _value;
    [SerializeField] int _score = 0;
    GameSceneManager _gameSceneManager;
    float _timeCount;
    TextMeshProUGUI _timetext;
    TextMeshProUGUI _scoreText;
    GameObject[] _moyaimage;
    GameObject _playerobj;
    float _gameOverTime;
    int _moyaiCount = 0;
    List<int> _searchMoyai;

    private void Awake()
    {
        if (Instance)
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
        _playerobj = _attach.GetPlayerObj;
        _scoreText = _attach.GetScoreText;
        _gameOverTime = _value.GetOverTime;
        _searchMoyai = _value.GetSearchMoyai;

        _scoreText.text = _score.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGame)
        {
            _timeCount = _gameOverTime;
            _timeCount -= Time.deltaTime;
            _timetext.text = _timeCount.ToString("F0");

            if (_timeCount <= 0)
            {
                GameResult();
            }
        }
    }

    public void MoyaiChange()
    {
        _moyaimage[_moyaiCount].GetComponent<Image>().color = Color.white;
        _moyaiCount++;
        _score++;
        _scoreText.text = _score.ToString("00");

        if (_moyaiCount >= _searchMoyai[GetNowCamera])
        {
            GetNowCamera++;
            _playerobj.GetComponent<PlayerContoller>().CamereChange();

            for (int i = 0; i < _moyaiCount + 1; i++)
            {
                _moyaimage[i].GetComponent<Image>().color = Color.black;
            }
            
        }
    }

    public void GameResult()
    {
        _gameSceneManager.SceneChange("Result");
        IsGame = false;
    }

    [System.Serializable]
    class AttachmentObj
    {
        [Header("PlayerObjを設定")]
        [SerializeField] GameObject _playerObj;
        public GameObject GetPlayerObj => _playerObj;

        [SerializeField] GameSceneManager _gameSceneManager;
        public GameSceneManager GetGameSceneManager => _gameSceneManager;

        [Header("score用のテキストを設定")]
        [SerializeField] TextMeshProUGUI _scoreText;
        public TextMeshProUGUI GetScoreText => _scoreText;

        [SerializeField] TextMeshProUGUI _timetext;
        public TextMeshProUGUI GetTimeText
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
        [SerializeField]float _gameOverTime = 10f;
        public float GetOverTime => _gameOverTime;

        [Header("モヤイの発見する数")]
        [SerializeField] List<int> _searchMoyai;
        public List<int> GetSearchMoyai => _searchMoyai;
    }
}
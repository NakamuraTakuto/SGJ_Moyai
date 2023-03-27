using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("現在使用しているカメラ")]
    [SerializeField] int _nowCamera = 0;
    public int GetNowCamera
    {
        set { _nowCamera = value; }
        get { return _nowCamera; }
    }
    [Header("モヤイの発見する数")]
    [SerializeField] List<int> _searchMoyai;
    public List<int> GetSearchMoyai => _searchMoyai;

    public static GameManager Instance;
    [SerializeField] public bool IsGame = false;
    [SerializeField] AttachmentObj _attach;
    [SerializeField] SetValues _value;
    [FormerlySerializedAs("_score")] [SerializeField] public int Score = 0;
    GameSceneManager _gameSceneManager;
    float _timeCount;
    TextMeshProUGUI _timetext;
    TextMeshProUGUI _scoreText;
    List<GameObject> _moyaimage;
    GameObject _playerobj;
    GameObject _iconParent;
    GameObject _iconPrefab;
    private GameObject _canvas;
    float _gameOverTime;
    int _moyaiCount = 0;

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
        _iconParent = _attach.GetIconParent;
        _iconPrefab = _attach.GetIconPrefab;
        _canvas = _attach.GetCanvas;
        _gameOverTime = _value.GetOverTime;

        if (_scoreText)
        {
            _scoreText = _attach.GetScoreText;
            _scoreText.text = Score.ToString("00");
        }
        IsGame = false; 
        
        for (int i = 0; i < _searchMoyai[GetNowCamera]; i++)
        {
            GameObject icon = Instantiate(_iconPrefab);
            icon.transform.parent = _iconParent.transform;
            icon.GetComponent<Image>().color = Color.black;
            _moyaimage.Add(icon);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGame)
        {
            _timeCount -= Time.deltaTime;
            _timetext.text = _timeCount.ToString("F0");

            if (_timeCount <= 0)
            {
                GameResult();
            }
        }
        else
        {
            _timeCount = _gameOverTime;
        }
    }

    public void MoyaiChange()
    {
        _moyaimage[_moyaiCount].GetComponent<Image>().color = Color.white;
        _moyaiCount++;
        Score++;
        //_scoreText.text = Score.ToString("00");

        if (_moyaiCount >= _searchMoyai[GetNowCamera])
        {
            GetNowCamera++;
            IsGame = false;
           _canvas.gameObject.SetActive(true);
           StartCoroutine(GameCount());
            _playerobj.GetComponent<PlayerContoller>().CamereChange();

            foreach(var i in _moyaimage)
            {
                Destroy(i);
                //_moyaimage.RemoveAt(0);
            }

            for (int i = 0; i < _moyaimage.Count; i++)
            {
                //Destroy(_moyaimage[0]);
                
            }

            _moyaimage.Clear();

            for (int i = 0; i < _searchMoyai[GetNowCamera]; i++)
            {
                GameObject icon = Instantiate(_iconPrefab);
                icon.transform.parent = _iconParent.transform;
                icon.GetComponent<Image>().color = Color.black;
                _moyaimage.Add(icon);
            }
            _moyaiCount = 0;
        }
    }

    IEnumerator GameCount()
    {
        yield return new WaitForSeconds(3f);
        _canvas.gameObject.SetActive(false);
        IsGame = true;
    }
    
    public void GameResult()
    {
        //_gameSceneManager.SceneChange("GameClear");
        SceneManager.LoadScene("GameClear");
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

        [Header("アイコンを表示するための親Objを設定")]
        [SerializeField] GameObject _iconParent;
        public GameObject GetIconParent => _iconParent;

        [Header("アイコンのprefab")]
        [SerializeField] GameObject _iconPrefab;
        public GameObject GetIconPrefab => _iconPrefab;

        [SerializeField] List<GameObject> _moyaimage;
        public List<GameObject> GetMoyaiImage
        {
            set { _moyaimage = value; }
            get { return _moyaimage; }
        }

        [Header("CountCanvas")] [SerializeField]
        private GameObject _canvas;

        public GameObject GetCanvas => _canvas;
    }

    [System.Serializable]
    class SetValues
    {
        [SerializeField]float _gameOverTime = 10f;
        public float GetOverTime => _gameOverTime;
    }
}
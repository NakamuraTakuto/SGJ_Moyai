using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] AttachmentObj _attachClass;
    List<GameObject> _cameraPointList;
    Image _crossHier;
    float _mouseWheel;
    bool _shotOK = true;
    int _listNumber = 0;
    GameObject _hold;


    private void Start()
    {
        _cameraPointList = _attachClass.GetCameraPoint;
        _crossHier = _attachClass.GetCrossHire;
        _cameraPointList[0].SetActive(true);
        _hold = _cameraPointList[0];
    }

    private void Update()
    {
        //inGameがfalseの時にcrosshairを消す
        if(!GameManager.Instance.IsGame)
        {
            _crossHier.gameObject.SetActive(false);
        }

        //Rayを飛ばす
        Ray _ray = Camera.main.ScreenPointToRay(_crossHier.rectTransform.position);

        //Rayが当たったときに対象のObjを取得してifの中に入る
        if (Physics.Raycast(_ray, out RaycastHit _hit))
        {
            //対象がActiveBaseを所持し、ゲームPlay中に左クリックをされている
            if (_hit.collider.gameObject.TryGetComponent<ActiveBase>(out var _active)
                && Input.GetButton("Fire1") && _shotOK)
            {
                //Active処理を呼び出す
                _active.Active();
            }

        }

        //マウスホイールが動いたときに実行
        _mouseWheel = Input.GetAxis("Mouse ScrollWheel");

        //マウスホイールを動かした方向による分岐
        if (_mouseWheel > 0)
        {
            _listNumber++;
            //隣接しているカメラに切り替える
            if (_listNumber >= _cameraPointList.Count)
            {
                _listNumber = 0;
                _hold.SetActive(false);
                _cameraPointList[_listNumber].SetActive(true);
                _hold = _cameraPointList[_listNumber];
            }
            else if (_listNumber < _cameraPointList.Count)
            {
                _hold.SetActive(false);
                _cameraPointList[_listNumber].SetActive(true);
                _hold = _cameraPointList[_listNumber];
            }

        }
        else if (_mouseWheel < 0)
        {
            _listNumber--;

            //隣接しているカメラに切り替える
            if (_listNumber < 0)
            {
                _listNumber = _cameraPointList.Count - 1;
                _hold.SetActive(false);
                _cameraPointList[_listNumber].SetActive(true);
                _hold = _cameraPointList[_listNumber];
            }
            else if (_listNumber >= 0)
            {
                _hold.SetActive(false);
                _cameraPointList[_listNumber].SetActive(true);
                _hold = _cameraPointList[_listNumber];
            }
        }
    }

    [System.Serializable]
    class AttachmentObj
    {
        [Header("CameraPoint")]
        [SerializeField] List<GameObject> _cameraPoint = new();
        public List<GameObject> GetCameraPoint => _cameraPoint;

        [Header("CrossHire")]
        [SerializeField] Image _crossHire;
        public Image GetCrossHire
        {
            set { _crossHire = value; }
            get { return _crossHire; }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] AttatimetObj _attatiClass;
    List<GameObject> _cameraPointList;
    Image _crossHier;
    float _mouseWheel;
    bool _shotOK = true;
    int _listNumber = 0;
    GameObject _hold;


    private void Start()
    {
        _cameraPointList = _attatiClass.GetCameraPoint;
        _crossHier = _attatiClass.GetCrossHire;
        _cameraPointList[0].SetActive(true);
        _hold = _cameraPointList[0];
    }

    private void Update()
    {
        //Ray‚ð”ò‚Î‚·
        Ray _ray = Camera.main.ScreenPointToRay(_crossHier.rectTransform.position);

        if (Physics.Raycast(_ray, out RaycastHit _hit))
        {
            if (_hit.collider.gameObject.TryGetComponent<ActiveBase>(out var _active)
                && Input.GetButton("Fire1") && _shotOK)
            {
                _active.Active();
            }

        }

        _mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if (_mouseWheel > 0)
        {
            _listNumber++;

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
}
[System.Serializable]
class AttatimetObj
{
    [Header("CameraPoint")]
    [SerializeField]List<GameObject> _cameraPoint = new();
    public List<GameObject> GetCameraPoint => _cameraPoint;
    
    [Header("CrossHire")]
    [SerializeField] Image _crossHire;
    public Image GetCrossHire => _crossHire;
}

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
        Cursor.visible = false;
        //inGame��false�̎���crosshair������
        if (!GameManager.Instance.IsGame)
        {
            _crossHier.gameObject.SetActive(false);
        }

        //Ray���΂�
        Ray _ray = Camera.main.ScreenPointToRay(_crossHier.rectTransform.position);

        //Ray�����������Ƃ��ɑΏۂ�Obj���擾����if�̒��ɓ���
        if (Physics.Raycast(_ray, out RaycastHit _hit))
        {
            //�Ώۂ�ActiveBase���������A�Q�[��Play���ɍ��N���b�N������Ă���
            if (_hit.collider.gameObject.TryGetComponent<ActiveBase>(out var _active)
                && Input.GetButton("Fire1"))
            {
                if (GameManager.Instance.IsGame || _hit.collider.gameObject.tag == ("StartMoyai"))
                    //Active�������Ăяo��
                    _active.Active();
            }
        }
    }

    public void CamereChange()
    {
        if (GameManager.Instance.GetNowCamera >= _cameraPointList.Count)
        {
            GameManager.Instance.GameResult();
        }

        _hold.SetActive(false);
        _cameraPointList[GameManager.Instance.GetNowCamera].SetActive(true);
        _hold = _cameraPointList[GameManager.Instance.GetNowCamera];
    }

    [System.Serializable]
    class AttachmentObj
    {
        [Header("CameraPoint")] [SerializeField]
        List<GameObject> _cameraPoint = new();

        public List<GameObject> GetCameraPoint => _cameraPoint;

        [Header("CrossHire")] [SerializeField] Image _crossHire;

        public Image GetCrossHire
        {
            set { _crossHire = value; }
            get { return _crossHire; }
        }
    }
}
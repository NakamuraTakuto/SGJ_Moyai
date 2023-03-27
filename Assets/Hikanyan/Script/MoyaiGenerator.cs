using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoyaiGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject _MoyaiPrefab;
    [SerializeField]
    List<GameObject> _checkList = new();
    List<GameObject> _useList = new();
    GameObject _moyaiGenerator;
    GameObject _randomObj;
    GameObject _obj;
    int _choiceIndex;
    private void Start()
    {
        _moyaiGenerator = GameObject.Find("MoyaiGenerator");

        //_checkListの中からランダムでGameManager.Instance.MoyaiNum個選ぶ
        for (int i = 0; i < GameManager.Instance.GetSearchMoyai.Count; i++)
        {
            _randomObj = _checkList[UnityEngine.Random.Range(0, _checkList.Count)];
            _useList.Add(_randomObj);
            _choiceIndex = _checkList.IndexOf(_randomObj);
            _checkList.RemoveAt(_choiceIndex);
        }

        //重複しない_checkListを全部インスタンス化
        foreach (var list in _checkList)
        {

            _obj = Instantiate(_MoyaiPrefab, list.transform.position, Quaternion.identity);
            _obj.transform.parent = _moyaiGenerator.transform;
        }
    }
}

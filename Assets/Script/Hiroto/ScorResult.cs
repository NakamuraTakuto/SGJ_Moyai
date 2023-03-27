using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScorResult : MonoBehaviour
{
    [SerializeField] GameObject _moyai;
    [SerializeField] GameObject _genelater;
    // Start is called before the first frame update
    void Start()
    {
      for (int i = 0; i < GameManager.Instance.Score; i++)
        {
            Instantiate(_moyai, _genelater.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

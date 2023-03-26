using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PointMove : MonoBehaviour
{
    [SerializeField] float time;
    private int vecX;
    private int vecZ;
    public float height = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveCount());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    IEnumerator MoveCount()
    {

        while(true)
        {
            yield return new WaitForSeconds(time);

            float t = Random.Range(3,5);
            
            vecX = Random.Range(-5, 5);
            vecZ = Random.Range(-5, 5);
            //transform.position = new Vector3(vecX, height, vecZ);

            float vecY = transform.position.y;

            this.transform.DOMove(new Vector3(vecX, vecY, vecZ), t).SetEase(Ease.Linear);
        }
        
    }
}

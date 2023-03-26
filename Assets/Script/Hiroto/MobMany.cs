using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMany : MonoBehaviour
{
    public GameObject MobPrefb;


    public float height = 1;
    public int numPrefb = 10;
    private int x;
    private int z;
    [SerializeField] float xRange = 4.5f;
    [SerializeField] float zRange = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numPrefb; i++)
        {
            float x = Random.Range(-xRange, xRange);
            float z = Random.Range(-zRange, zRange);
            Vector3 pos = new Vector3(x, height, z);

            // Mob‚ð¶¬
            GameObject bos = Instantiate(MobPrefb, pos, Quaternion.identity);
            bos.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

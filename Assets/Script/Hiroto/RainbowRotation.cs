using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowRotation : MonoBehaviour
{
    public float x = 1;
    public float y = 0;
    public float z = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x, y, z);
    }
}

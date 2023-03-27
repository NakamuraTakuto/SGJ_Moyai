using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic : MonoBehaviour
{
    private float chargeTime = 5.0f;
    private float timeCount;
    private void Update()
    {
        timeCount += Time.deltaTime;

        // �����O�i
        transform.position += transform.right * Time.deltaTime;

        // �w�莞�Ԃ̌o�߁i�����j
        if (timeCount > chargeTime)
        {
            // �i�H�������_���ɕύX����
            Vector3 course = new Vector3(0, Random.Range(0, 180), 0);
            transform.localRotation = Quaternion.Euler(course);

            // �^�C���J�E���g���O�ɖ߂�
            timeCount = 0;
        }
    }
}

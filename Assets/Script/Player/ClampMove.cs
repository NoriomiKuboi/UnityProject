using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampMove : MonoBehaviour
{
    private float minX = -99; // x�̈ړ��͈͂̍ŏ��l
    private float maxX = 99; // x�̈ړ��͈͂̍ő�l
    private float minY = -99; // y�̈ړ��͈͂̍ŏ��l
    private float maxY = 99; // y�̈ړ��͈͂̍ő�l
    private float minZ = -99; // z�̈ړ��͈͂̍ŏ��l
    private float maxZ = 99; // z�̈ړ��͈͂̍ő�l

    void Start()
    {

    }

    void Update()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }
}

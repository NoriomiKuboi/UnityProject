using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampMove : MonoBehaviour
{
    private float minX = -99; // xの移動範囲の最小値
    private float maxX = 99; // xの移動範囲の最大値
    private float minY = -99; // yの移動範囲の最小値
    private float maxY = 99; // yの移動範囲の最大値
    private float minZ = -99; // zの移動範囲の最小値
    private float maxZ = 99; // zの移動範囲の最大値

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

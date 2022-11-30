using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int count = 0;
    public float move;
    public int countNum;

    void Update()
    {
        Vector3 p = new Vector3(0, 0, move);
        transform.Translate(p);
        count++;

        //countが100になれば-1を掛けて逆方向に動かす
        if (count == countNum)
        {
            count = 0;
            move *= -1;
        }
    }
}

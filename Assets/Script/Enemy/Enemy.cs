using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHp;

    void Start()
    {
    }

    void Update()
    {
        // HP��0�ɂȂ��������
        if (enemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // �_���[�W��HP��1���炷
    public void Damage()
    {
        enemyHp -= 1;
    }
}
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
        // HPが0になったら消滅
        if (enemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // ダメージ時HPを1減らす
    public void Damage()
    {
        enemyHp -= 1;
    }
}

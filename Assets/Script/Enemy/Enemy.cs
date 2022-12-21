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
        // HPÇ™0Ç…Ç»Ç¡ÇΩÇÁè¡ñ≈
        if (enemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // É_ÉÅÅ[ÉWéûHPÇ1å∏ÇÁÇ∑
    public void Damage()
    {
        enemyHp -= 1;
    }
}

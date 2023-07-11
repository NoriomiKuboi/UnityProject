using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockOnSystem : MonoBehaviour
{
    public GameObject enemy;
    public List<Transform> enemyList = new List<Transform>();
    public GameObject player;
    private GameObject target;

    private int maxCount = 150; // ロックオンまで時間
    private int elapsedTime = 0; // 円の中にいた時間
    private bool isLockOn = false; // ロックオンしているか
    private float dist = 0; // 敵と自機の距離
    public float lockOnCircle = 150; // ロックオンの範囲

    void Start()
    {

    }

    void Update()
    {
        LockOn();

        if (elapsedTime > maxCount)
        {
            isLockOn = true;
            if (enemy.CompareTag("Enemy")) { enemyList.Add(gameObject.transform); }
        }
        else
        {
            isLockOn = false;
            for(int i = 0;i < enemyList.Count; i++)
            {
                enemyList.RemoveAt(i);
            }
        }

        for (int j = 0; j < enemyList.Count; j++)
        {
            for (int k = j + 1; k < enemyList.Count; k++)
            {
                if (enemyList[k] == enemyList[j])
                {
                    enemyList.RemoveAt(k);
                }
            }

            if (!enemyList[j])
            {
                enemyList.RemoveAt(j);
            }
        }
    }

    // ロックオンシステム
    void LockOn()
    {
        // 敵がいるとき
        if(enemy != null)
        {
            dist = Vector3.Distance(player.transform.position, enemy.transform.position);

            // ロックオンした敵との間にオブジェクトがないとき
            if (Physics.Linecast(this.transform.position, enemy.transform.position, LayerMask.GetMask("Obj")) == false/* && dist <= 45.0f*/)
            {
                Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, enemy.transform.position);
                screenPoint.x = screenPoint.x - (Screen.width / 2);
                screenPoint.y = screenPoint.y - (Screen.height / 2);

                //lockOnCircle内の場合
                if (screenPoint.magnitude <= lockOnCircle)
                {
                    if (elapsedTime <= maxCount)
                    {
                        elapsedTime++;
                    }

                    target = enemy;
                    return;
                }
            }
        }

        // ロックオンではない
        elapsedTime = 0;
        return;
    }

    public int getElapsedTime()
    {
        return elapsedTime;
    }

    public GameObject getTarget()
    {
        return target;
    }

    public bool getIsLockOn()
    {
        return isLockOn;
    }
}
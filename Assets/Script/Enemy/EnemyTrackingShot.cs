using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrackingShot : MonoBehaviour
{
    private GameObject player;
    public GameObject bullet;
    public float time = 1; // 打ち出す間隔
    public float delayTime = 1; // 最初に打ち出す時間
    float nowTime = 0;

    private float countDown = 5.0f; // 操作できるようになるまでの時間
    private int count; // カウントダウンカウント

    void Start()
    {
        nowTime = delayTime;
    }
    
    void Update()
    {
        if (countDown >= 0)
        {
            countDown -= Time.deltaTime;
            count = (int)countDown;
        }

        if(countDown <= 0)
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }

            nowTime -= Time.deltaTime;

            if (nowTime <= 0)
            {
                CreateShotObj(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
                nowTime = time;
            }
        }
    }  
    
    private void CreateShotObj(float axisX, float axisY, float axisZ)
    {
        var direction = player.transform.position - transform.position;
    
        //direction.x = 0;
        //direction.y = 0;
        //direction.z = 0;

        var lookRotation = Quaternion.LookRotation(-direction, Vector3.up);
    
        GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
    
        var bulletObj = bulletClone.GetComponent<EnemyBullet>();
    
        bulletObj.SetCharacterObj(gameObject);
    
        bulletObj.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axisX, Vector3.up));
        bulletObj.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axisY, Vector3.up));
        bulletObj.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axisZ, Vector3.up));
    }
}

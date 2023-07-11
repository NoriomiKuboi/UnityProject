using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float interval = 0.2f; // 何秒間隔で撃つか
    private float timer = 0.0f; // 時間カウント用のタイマー
    private float countDown = 5.0f; // 操作できるようになるまでの時間
    private int count; // カウントダウンカウント

    private void Start()
    {

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
            if (Input.GetKey("space") && timer <= 0.0f)
            {
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Rigidbody ballRigidbody = bullet.GetComponent<Rigidbody>();
                ballRigidbody.AddForce(transform.forward * bulletSpeed);
                timer = interval;
            }

            //GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //Rigidbody ballRigidbody = bullet.GetComponent<Rigidbody>();
            //ballRigidbody.AddForce(transform.forward * bulletSpeed);
            //timer = interval;

            if (timer > 0.0f)
            {
                timer -= Time.deltaTime;
            }
        }
    }
}
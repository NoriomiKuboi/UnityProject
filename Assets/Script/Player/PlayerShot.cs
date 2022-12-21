using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float countDown = 3.0f; // ����ł���悤�ɂȂ�܂ł̎���
    private int count;

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
            if (Input.GetKeyDown("space"))
            {
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Rigidbody ballRigidbody = bullet.GetComponent<Rigidbody>();
                ballRigidbody.AddForce(transform.forward * bulletSpeed);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float interval = 0.2f; // ���b�Ԋu�Ō���
    private float timer = 0.0f; // ���ԃJ�E���g�p�̃^�C�}�[
    private float countDown = 5.0f; // ����ł���悤�ɂȂ�܂ł̎���
    private int count; // �J�E���g�_�E���J�E���g

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
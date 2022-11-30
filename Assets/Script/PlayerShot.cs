using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody ballRigidbody = bullet.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(transform.forward * bulletSpeed);
        }
    }
}

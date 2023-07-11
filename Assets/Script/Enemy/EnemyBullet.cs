using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 1.0f; // 弾のスピード
    public float deleteTime = 1.0f; // 消滅までの時間
    private Vector3 forward = new Vector3(1, 1, 1);
    private Quaternion forwardAxis = Quaternion.identity;
    private Rigidbody rb;
    private GameObject enemy;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        if(enemy != null)
        {
            forward = enemy.transform.forward;
        }
    }

    void Update()
    {
        rb.velocity = forwardAxis * forward * speed;
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        deleteTime -= Time.deltaTime;

        if(deleteTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Player>().Damage();
        }
    }

    public void SetCharacterObj(GameObject character)
    {
        this.enemy = character;
    }

    public void SetForwardAxis(Quaternion axis)
    {
        this.forwardAxis = axis;
    }
}

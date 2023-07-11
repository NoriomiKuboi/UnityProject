using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float deleteTime = 3.0f;

    void Start()
    {
        Destroy(gameObject, deleteTime);
    }

    void Update()
    {

    }

    // “G‚Æ‚Ì“–‚½‚è”»’è
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().Damage();
        }

        if (other.gameObject.tag == "Boss")
        {
            other.GetComponent<Boss>().Damage();
        }
    }
}

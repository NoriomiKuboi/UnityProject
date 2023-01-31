using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedShot : MonoBehaviour
{
    private GameObject player;
    public GameObject bullet;
    public int bulletWayNum = 3; // �ł��o���e�̐�
    public float bulletWaySpace = 30; // �ł��o���e�̊Ԋu
    private float bulletWayAxis = 0; // �ł��o���e�̊p�x
    public float time = 1; // �ł��o���Ԋu
    public float delayTime = 1; // �ŏ��ɑł��o������
    float nowTime = 0;

    private float countDown = 3.0f; // ����ł���悤�ɂȂ�܂ł̎���
    private int count; // �J�E���g�_�E���J�E���g

    void Start()
    {
        nowTime = delayTime;
        bulletWayAxis = Random.Range(0, 360);
    }

    void Update()
    {
        if (countDown >= 0)
        {
            countDown -= Time.deltaTime;
            count = (int)countDown;
        }

        if (countDown <= 0)
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }

            nowTime -= Time.deltaTime;

            if (nowTime <= 0)
            {
                float bulletWaySpaceSplit = 0;

                for (int i = 0; i < bulletWayNum; i++)
                {
                    CreateShotObj(bulletWaySpace - bulletWaySpaceSplit + bulletWayAxis - transform.localEulerAngles.y);

                    bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1)) * 2;
                }

                nowTime = time;
            }
        }
    }

    private void CreateShotObj(float axis)
    {
        GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);

        var bulletObj = bulletClone.GetComponent<EnemyBullet>();

        bulletObj.SetCharacterObj(gameObject);

        bulletObj.SetForwardAxis(Quaternion.AngleAxis(axis, Vector3.up));
    }
}

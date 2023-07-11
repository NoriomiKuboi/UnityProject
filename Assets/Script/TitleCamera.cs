using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCamera : MonoBehaviour
{
    //�v���C���[��ϐ��Ɋi�[
    public GameObject Player;

    //��]������X�s�[�h
    public float rotateSpeed = 3.0f;

    void Start()
    {

    }

    void Update()
    {

        //��]������p�x
        float angle = Time.deltaTime * rotateSpeed;

        //�v���C���[�ʒu���
        Vector3 playerPos = Player.transform.position;

        //�J��������]������
        transform.RotateAround(playerPos, Vector3.up, angle);
    }
}

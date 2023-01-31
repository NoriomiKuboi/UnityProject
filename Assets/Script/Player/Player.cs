using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text gameOver;
    public GameObject retryButton;
    public GameObject endButton;
    public Slider hp;
    public int playerHp = 5;
    public float speed = 1.0f; // �O�i�X�s�[�h
    public float rot = 1.0f; // ��]�X�s�[�h
    public float acc = 2.0f; // ����
    private float keepSpeed; // �����p�̑O�i�X�s�[�h�ۑ�
    private float keepRotSpeed; // �����p�̉�]�X�s�[�h�ۑ�
    private float countDown = 3.0f; // ����ł���悤�ɂȂ�܂ł̎���
    private int count; // �J�E���g�_�E���J�E���g

    void Start()
    {
        keepSpeed = speed;
        keepRotSpeed = rot;
        hp.value = 5;
        retryButton.SetActive(false);
        endButton.SetActive(false);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        Debug.Log(transform.position);

        if (countDown >= 0)
        {   
            countDown -= Time.deltaTime;
            count = (int)countDown;
        }

        if(countDown <= 0 && playerHp > 0)
        {
            // �㏸
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(-rot * Time.deltaTime, 0, 0);
            }

            // ���~
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(rot * Time.deltaTime, 0, 0);
            }

            // �E����
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, rot * Time.deltaTime, 0);
            }

            // ������
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -rot * Time.deltaTime, 0);
            }

            // LShift�ŉ���
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = keepSpeed * acc;
                rot = keepRotSpeed * acc;
            }

            else
            {
                speed = keepSpeed;
                rot = keepRotSpeed;
            }
        }

        // HP��0�ɂȂ��������
        if (playerHp <= 0)
        {
            gameOver.text = "Game Over";
            retryButton.SetActive(true);
            endButton.SetActive(true);
        }
    }

    // �_���[�W��HP��1���炷
    public void Damage()
    {
        playerHp -= 1;
        hp.value -= 1;
    }
}

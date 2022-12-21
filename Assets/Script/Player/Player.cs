using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text gameOver;
    public GameObject retryButton;
    public GameObject endButton;
    public int playerHp = 1;
    public float speed = 1.0f; // �O�i�X�s�[�h
    public float rot = 1.0f; // ��]����X�s�[�h
    private float countDown = 3.0f; // ����ł���悤�ɂȂ�܂ł̎���
    private int count;

    void Start()
    {
        retryButton.SetActive(false);
        endButton.SetActive(false);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

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
    }
}

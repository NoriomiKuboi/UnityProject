using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject retryButton;
    public GameObject endButton;
    public Slider hp;
    public ParticleSystem particle;
    public CameraShake cameraShake;
    public Image img;
    public int playerHp = 5;
    public float speed = 1.0f; // �O�i�X�s�[�h
    public float rot = 1.0f; // ��]�X�s�[�h
    public float acc = 2.0f; // ����
    private float keepSpeed; // �����p�̑O�i�X�s�[�h�ۑ�
    private float keepRotSpeed; // �����p�̉�]�X�s�[�h�ۑ�
    private float countDown = 5.0f; // ����ł���悤�ɂȂ�܂ł̎���
    private int count; // �J�E���g�_�E���J�E���g

    void Start()
    {
        keepSpeed = speed;
        keepRotSpeed = rot;
        hp.value = 5;
        gameOver.SetActive(false);
        retryButton.SetActive(false);
        endButton.SetActive(false);
        particle.gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);

        if (countDown >= 0)
        {   
            countDown -= Time.deltaTime;
            count = (int)countDown;
        }

        if(countDown <= 0 && playerHp > 0)
        {
            var angle = Vector3.zero;
            // �㏸
            if (Input.GetKey(KeyCode.W))
            {
                angle.x = -rot * Time.deltaTime;
            }

            // ���~
            if (Input.GetKey(KeyCode.S))
            {
                angle.x = rot * Time.deltaTime;
            }

            // �E����
            if (Input.GetKey(KeyCode.D))
            {
                angle.y = rot * Time.deltaTime;
            }

            // ������
            if (Input.GetKey(KeyCode.A))
            {
                angle.y = -rot * Time.deltaTime;
            }

            transform.Rotate(angle);

            // LShift�ŉ���
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = keepSpeed * acc;
                rot = keepRotSpeed * acc;
                particle.gameObject.SetActive(true);
            }

            else
            {
                speed = keepSpeed;
                rot = keepRotSpeed;
                particle.gameObject.SetActive(false);
            }

            img.color = Color.Lerp(img.color, Color.clear, Time.deltaTime);
        }

        // HP��0�ɂȂ�����
        if (playerHp <= 0)
        {
            gameOver.SetActive(true);
            retryButton.SetActive(true);
            endButton.SetActive(true);
            particle.gameObject.SetActive(false);
            img.color = new Color(0.5f, 0f, 0f, 0.0f);
        }
    }

    // �_���[�W���̏���
    public void Damage()
    {
        playerHp -= 1; // player��HP�����炷
        hp.value -= 1; // player��HP�o�[�����炷
        img.color = new Color(0.5f, 0f, 0f, 0.5f); // ��ʂ�Ԃ�����
        cameraShake.Shake(0.25f, 0.1f); // ��ʂ�h�炷
    }

    public void Crash()
    {
        playerHp -= 10;
        hp.value -= 10;
    }
}

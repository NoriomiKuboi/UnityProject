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
    public float speed = 1.0f; // 前進スピード
    public float rot = 1.0f; // 回転スピード
    public float acc = 2.0f; // 加速
    private float keepSpeed; // 加速用の前進スピード保存
    private float keepRotSpeed; // 加速用の回転スピード保存
    private float countDown = 5.0f; // 操作できるようになるまでの時間
    private int count; // カウントダウンカウント

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
            // 上昇
            if (Input.GetKey(KeyCode.W))
            {
                angle.x = -rot * Time.deltaTime;
            }

            // 下降
            if (Input.GetKey(KeyCode.S))
            {
                angle.x = rot * Time.deltaTime;
            }

            // 右旋回
            if (Input.GetKey(KeyCode.D))
            {
                angle.y = rot * Time.deltaTime;
            }

            // 左旋回
            if (Input.GetKey(KeyCode.A))
            {
                angle.y = -rot * Time.deltaTime;
            }

            transform.Rotate(angle);

            // LShiftで加速
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

        // HPが0になったら
        if (playerHp <= 0)
        {
            gameOver.SetActive(true);
            retryButton.SetActive(true);
            endButton.SetActive(true);
            particle.gameObject.SetActive(false);
            img.color = new Color(0.5f, 0f, 0f, 0.0f);
        }
    }

    // ダメージ時の処理
    public void Damage()
    {
        playerHp -= 1; // playerのHPを減らす
        hp.value -= 1; // playerのHPバーを減らす
        img.color = new Color(0.5f, 0f, 0f, 0.5f); // 画面を赤くする
        cameraShake.Shake(0.25f, 0.1f); // 画面を揺らす
    }

    public void Crash()
    {
        playerHp -= 10;
        hp.value -= 10;
    }
}

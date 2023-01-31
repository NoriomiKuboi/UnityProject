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
    public float speed = 1.0f; // 前進スピード
    public float rot = 1.0f; // 回転スピード
    public float acc = 2.0f; // 加速
    private float keepSpeed; // 加速用の前進スピード保存
    private float keepRotSpeed; // 加速用の回転スピード保存
    private float countDown = 3.0f; // 操作できるようになるまでの時間
    private int count; // カウントダウンカウント

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
            // 上昇
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(-rot * Time.deltaTime, 0, 0);
            }

            // 下降
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(rot * Time.deltaTime, 0, 0);
            }

            // 右旋回
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, rot * Time.deltaTime, 0);
            }

            // 左旋回
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -rot * Time.deltaTime, 0);
            }

            // LShiftで加速
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

        // HPが0になったら消滅
        if (playerHp <= 0)
        {
            gameOver.text = "Game Over";
            retryButton.SetActive(true);
            endButton.SetActive(true);
        }
    }

    // ダメージ時HPを1減らす
    public void Damage()
    {
        playerHp -= 1;
        hp.value -= 1;
    }
}

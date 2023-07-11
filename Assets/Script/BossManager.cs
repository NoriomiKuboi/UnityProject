using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    private GameObject[] enemys;
    public GameObject boss;
    public Image caution;
    public Image topImage;
    public Image underImage;
    private int count = 0;
    private bool trigger = false;
    float alpha;
    private float speed = 1.0f; // 点滅速度

    void Start()
    {
        boss.SetActive(false);
    }

    void Update()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if(boss != null)
        {
            if (enemys.Length == 0)
            {
                StartEffect();
            }
        }

        if (boss == null)
        {
            count++;

            if(count > 65)
            {
                SceneManager.LoadScene("ResultScene");
            }
        }

    }

    void StartEffect()
    {
        Vector2 pos = caution.transform.position;

        if(trigger == false)
        {
            pos.x -= 8.0f;
            caution.color = ChangeAlpha(caution.color);
            topImage.color = ChangeAlpha(topImage.color);
            underImage.color = ChangeAlpha(underImage.color);
            caution.transform.position = pos;
        }

        if (pos.x < -319)
        {
            trigger = true;
            boss.SetActive(true);
            caution.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            topImage.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            underImage.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
    }

    // Image点滅用
    Color ChangeAlpha(Color color)
    {
        alpha += Time.deltaTime * 3.0f * speed;
        color.a = Mathf.Sin(alpha);
        return color;
    }
}

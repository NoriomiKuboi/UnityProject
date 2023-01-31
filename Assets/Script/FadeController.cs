using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public static bool isFadeInstance = false;

    public bool isFadeIn = false; // �t�F�[�h�C���t���O
    public bool isFadeOut = false; // �t�F�[�h�A�E�g�t���O

    public float alpha = 0.0f; // ���ߗ�
    public float fadeSpeed = 0.2f; // �t�F�[�h���鎞��

    void Start()
    {
        if (!isFadeInstance)
        {
            DontDestroyOnLoad(this);
            isFadeInstance = true;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (isFadeIn)
        {
            alpha -= Time.deltaTime / fadeSpeed;
            if (alpha <= 0.0f)
            {
                isFadeIn = false;
                alpha = 0.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
        else if (isFadeOut)
        {
            alpha += Time.deltaTime / fadeSpeed;
            if (alpha >= 1.0f)
            {
                isFadeOut = false;
                alpha = 1.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }

    public void FadeIn()
    {
        isFadeIn = true;
        isFadeOut = false;
    }

    public void FadeOut()
    {
        isFadeOut = true;
        isFadeIn = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffect : MonoBehaviour
{
    public Material motionBlur;
    private float countDown = 5.0f; // ����ł���悤�ɂȂ�܂ł̎���
    private int count; // �J�E���g�_�E���J�E���g

    private void Update()
    {
        if (countDown >= 0)
        {
            countDown -= Time.deltaTime;
            count = (int)countDown;
        }

        if (countDown <= 0 && Input.GetKey(KeyCode.LeftShift))
        {
            motionBlur.SetFloat("_BlurSize", 0.33f);
            motionBlur.SetFloat("_EdgeCoeff", 3.0f);
        }

        else
        {
            motionBlur.SetFloat("_BlurSize", 0);
            motionBlur.SetFloat("_EdgeCoeff", 0);
        }
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, motionBlur);
    }
}

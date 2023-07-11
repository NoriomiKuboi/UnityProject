using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveImage : MonoBehaviour
{
    public Image image;
    private float speed = 10.0f; // �ړ����x
    private bool trigger = false; // ��ʂ̔����ɓ��B������
    private int count = 0; // �J�E���^�[
    private const float maxCount = 100;

    void Start()
    {
    }

    void Update()
    {
        Vector2 pos = image.transform.position;

        if(trigger == false)
        {
            pos.y -= speed;
            //pos.y = Easing.CircInOut(0.1f, 60, 640, 0);
            image.transform.position = pos;
            count = 0;
        }

        if(pos.y < Screen.height / 1.3f)
        {
            trigger = true;
            count++;
        }

        if(count == maxCount)
        {
            pos.y += speed;
            image.transform.position = pos;
            //image.transform.position += new Vector3(0, speed, 0);
        }
    }
}

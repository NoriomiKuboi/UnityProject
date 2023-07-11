using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSystem : MonoBehaviour
{
    GameObject buttonText; // ButtonについてるText

    Color buttonColor; // Buttonの初期カラー
    Color textColor; // Textの初期カラー

    float alpha;
    public float speed = 5; // 点滅速度

    void Start()
    {
        buttonText = transform.GetChild(0).gameObject;
        buttonColor = GetComponent<Image>().color;
        textColor = buttonText.GetComponent<Text>().color;
    }

    void Update()
    {
        alpha += speed * Time.deltaTime;
        gameObject.GetComponent<Image>().color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, Mathf.Sin(alpha));
        buttonText.GetComponent<Text>().color = new Color(textColor.r, textColor.g, textColor.b, Mathf.Sin(alpha));
    }
}

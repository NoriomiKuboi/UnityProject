using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSystem : MonoBehaviour
{
    GameObject buttonText; // Button�ɂ��Ă�Text

    Color buttonColor; // Button�̏����J���[
    Color textColor; // Text�̏����J���[

    float alpha;
    public float speed = 5; // �_�ő��x

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

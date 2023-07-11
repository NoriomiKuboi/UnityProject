using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Image num1;
    public Image num2;
    public Image num3;
    public Image go;

    void Start()
    {
        StartCoroutine(CountdownCoroutine());
    }

    void Update()
    {

    }

    IEnumerator CountdownCoroutine()
    {
        yield return new WaitForSeconds(2.0f);

        num3.color = new Color(1.0f, 1.0f, 1.0f, 1.0f); // 3��\��
        yield return new WaitForSeconds(1.0f);

        num3.color = new Color(1.0f, 1.0f, 1.0f, 0.0f); // 3���\��
        num2.color = new Color(1.0f, 1.0f, 1.0f, 1.0f); // 2��\��
        yield return new WaitForSeconds(1.0f);

        num2.color = new Color(1.0f, 1.0f, 1.0f, 0.0f); // 2���\��
        num1.color = new Color(1.0f, 1.0f, 1.0f, 1.0f); // 1��\��
        yield return new WaitForSeconds(1.0f);

        num1.color = new Color(1.0f, 1.0f, 1.0f, 0.0f); // 1���\��
        go.color = new Color(1.0f, 1.0f, 1.0f, 1.0f); // GO!��\��
        yield return new WaitForSeconds(1.0f);

        go.color = new Color(1.0f, 1.0f, 1.0f, 0.0f); // GO!���\��
    }
}

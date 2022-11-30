using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 0.01f;

        // �㏸
        if (Input.GetKey(KeyCode.W))    
        {
            transform.Rotate(-1, 0, 0);
        }

        // ���~
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(1, 0, 0);
        }

        // �E����
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }

        // ������
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
        }
    }
}

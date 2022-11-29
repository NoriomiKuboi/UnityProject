using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] GameObject target;

    void Start()
    {
        transform.SetParent(target.gameObject.transform);
    }
}

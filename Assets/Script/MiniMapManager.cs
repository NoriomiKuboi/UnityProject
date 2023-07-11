using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapManager : MonoBehaviour
{
    public float angle;
    public Transform minimapOverlay;
    private Transform player;
    private GameObject[] enemys;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        transform.position = player.position + Vector3.up * 5f;
        //HandleEnemyVisible();
        RotateOverlay();
    }

    private void HandleEnemyVisible()
    {
        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i].SetActive(Vector3.Angle(player.forward, enemys[i].transform.position - player.position) <= angle);
        }
    }

    private void RotateOverlay()
    {
        minimapOverlay.localRotation = Quaternion.Euler(0, 0, -player.eulerAngles.y - angle);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class RadarTest : MonoBehaviour
{
    [SerializeField] Transform enemy;
    [SerializeField] Transform player;
    [SerializeField] Image center;
    [SerializeField] Image target;
    [SerializeField] float radarLength = 30f;
 
    RectTransform rt;
    Vector2 offset;
    float r = 6f;

    void Start()
    {
        rt = target.GetComponent<RectTransform>();
        offset = center.GetComponent<RectTransform>().anchoredPosition;
    }

    void Update()
    {
        Vector3 enemyDir = enemy.position;
        enemyDir.y = player.position.y; // プレイヤーと敵の高さを合わせる
        enemyDir = enemy.position - player.position;
 
        enemyDir = Quaternion.Inverse(player.rotation) * enemyDir; // ベクトルをプレイヤーに合わせて回転
        enemyDir = Vector3.ClampMagnitude(enemyDir, radarLength); // ベクトルの長さを制限
 
        rt.anchoredPosition = new Vector2(enemyDir.x * r + offset.x, enemyDir.z * r + offset.y);
    }
}

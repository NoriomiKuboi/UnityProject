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
        enemyDir.y = player.position.y; // �v���C���[�ƓG�̍��������킹��
        enemyDir = enemy.position - player.position;
 
        enemyDir = Quaternion.Inverse(player.rotation) * enemyDir; // �x�N�g�����v���C���[�ɍ��킹�ĉ�]
        enemyDir = Vector3.ClampMagnitude(enemyDir, radarLength); // �x�N�g���̒����𐧌�
 
        rt.anchoredPosition = new Vector2(enemyDir.x * r + offset.x, enemyDir.z * r + offset.y);
    }
}
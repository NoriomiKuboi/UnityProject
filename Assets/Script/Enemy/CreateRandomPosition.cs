using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject createPrefab;

    public int enemyNum;
    public float create;
    public float rangeA;
    public float rangeB;

    void Start()
    {
        StartCoroutine("CubeCount");
    }

    IEnumerator CubeCount()
    {
        for (int count = 0; count < enemyNum; count++)
        {
            yield return new WaitForSeconds(create);

            // rangeAとrangeBのx座標の範囲内でランダムな数値を取得
            float x = Random.Range(rangeA, rangeB);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を取得
            float y = Random.Range(rangeA, rangeB);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を取得
            float z = Random.Range(rangeA, rangeB);

            // GameObjectを上記で決まったランダムな場所に生成
            Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);
        }
    }
}
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

            // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���擾
            float x = Random.Range(rangeA, rangeB);
            // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���擾
            float y = Random.Range(rangeA, rangeB);
            // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���擾
            float z = Random.Range(rangeA, rangeB);

            // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
            Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);
        }
    }
}
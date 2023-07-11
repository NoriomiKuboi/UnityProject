using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHp;
    public ParticleSystem particle;
    public float speed = 0;
    private int rangeA = -90;
    private int rangeB = 90;
    private int angleX = 0;
    private int angleY = 0;
    private int angleZ = 0;

    void Start()
    {

    }

    void Update()
    {
        // HP��0�ɂȂ��������
        if (enemyHp <= 0)
        {
            transform.Translate(0, -Time.deltaTime * speed, 0);
            transform.Rotate(angleX * Time.deltaTime, angleY * Time.deltaTime, angleZ * Time.deltaTime);
            StartCoroutine("Coroutine");
        }
    }

    // �_���[�W��HP��1���炷
    public void Damage()
    {
        enemyHp -= 1;

        // angleX�͈͓̔��Ń����_���Ȑ��l���擾
        angleX = Random.Range(rangeA, rangeB);
        // angleY�͈͓̔��Ń����_���Ȑ��l���擾
        angleY = Random.Range(rangeA, rangeB);
        // angleZ�͈͓̔��Ń����_���Ȑ��l���擾
        angleZ = Random.Range(rangeA, rangeB);
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(1.0f);
        // �p�[�e�B�N���V�X�e���̃C���X�^���X�𐶐�����B
        ParticleSystem newParticle = Instantiate(particle);
        // �p�[�e�B�N���̔����ꏊ�����̃X�N���v�g���A�^�b�`���Ă���GameObject�̏ꏊ�ɂ���B
        newParticle.transform.position = this.transform.position;
        // �p�[�e�B�N���𔭐�������B
        newParticle.Play();
        Destroy(this.gameObject);
    }
}

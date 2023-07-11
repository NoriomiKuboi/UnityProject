using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int bossHp;
    public float speed = 0;
    public ParticleSystem particle;

    void Start()
    {
        
    }

    void Update()
    {
        if (bossHp < 0)
        {
            transform.Translate(0, Time.deltaTime * speed, 0);
            StartCoroutine("Coroutine");
        }
    }

    // �_���[�W��HP��1���炷
    public void Damage()
    {
        bossHp--;
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

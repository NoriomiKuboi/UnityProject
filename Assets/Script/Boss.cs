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

    // ダメージ時HPを1減らす
    public void Damage()
    {
        bossHp--;
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(1.0f);
        // パーティクルシステムのインスタンスを生成する。
        ParticleSystem newParticle = Instantiate(particle);
        // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
        newParticle.transform.position = this.transform.position;
        // パーティクルを発生させる。
        newParticle.Play();
        Destroy(this.gameObject);
    }
}

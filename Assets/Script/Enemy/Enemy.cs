using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHp;
    public ParticleSystem particle;

    void Start()
    {
    }

    void Update()
    {
        // HPが0になったら消滅
        if (enemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // ダメージ時HPを1減らす
    public void Damage()
    {
        enemyHp -= 1;
        // パーティクルシステムのインスタンスを生成する。
        ParticleSystem newParticle = Instantiate(particle);
        // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
        newParticle.transform.position = this.transform.position;
        // パーティクルを発生させる。
        newParticle.Play();
        // インスタンス化したパーティクルシステムのGameObjectを削除する。(任意)
        // ※第一引数をnewParticleだけにするとコンポーネントしか削除されない。
        Destroy(newParticle.gameObject, 5.0f);
    }
}

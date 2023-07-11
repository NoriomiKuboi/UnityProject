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
        // HPが0になったら消滅
        if (enemyHp <= 0)
        {
            transform.Translate(0, -Time.deltaTime * speed, 0);
            transform.Rotate(angleX * Time.deltaTime, angleY * Time.deltaTime, angleZ * Time.deltaTime);
            StartCoroutine("Coroutine");
        }
    }

    // ダメージ時HPを1減らす
    public void Damage()
    {
        enemyHp -= 1;

        // angleXの範囲内でランダムな数値を取得
        angleX = Random.Range(rangeA, rangeB);
        // angleYの範囲内でランダムな数値を取得
        angleY = Random.Range(rangeA, rangeB);
        // angleZの範囲内でランダムな数値を取得
        angleZ = Random.Range(rangeA, rangeB);
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

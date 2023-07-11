using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 60fps固定
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    // escで終了
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // シーンリセット
    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }

    // シーン遷移(次のシーンへ)
    public void NextScene(string nextSceneName)
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // ゲーム終了
    public void ButtonExit()
    {
        Application.Quit();
    }
}

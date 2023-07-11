using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 60fps�Œ�
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    // esc�ŏI��
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // �V�[�����Z�b�g
    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }

    // �V�[���J��(���̃V�[����)
    public void NextScene(string nextSceneName)
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // �Q�[���I��
    public void ButtonExit()
    {
        Application.Quit();
    }
}

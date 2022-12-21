using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // �V�[�����Z�b�g
    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }

    // �V�[���J��
    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    // �Q�[���I��
    public void ButtonExit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject fadeCanvas;

    void Start()
    {
        if (!FadeController.isFadeInstance)
        {
            Instantiate(fadeCanvas);
        }

        Invoke("FindFadeObject", 0.02f);
    }

    void FindFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");
        fadeCanvas.GetComponent<FadeController>().FadeIn();
    }

    public async void SceneChange(string sceneName)
    {
        fadeCanvas.GetComponent<FadeController>().FadeOut();
        await Task.Delay(200);
        SceneManager.LoadScene(sceneName);
    }
}

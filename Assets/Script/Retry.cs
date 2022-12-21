using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RetryManager()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

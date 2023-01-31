using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text _textCountdown;
    
    void Start()
    {
        StartCoroutine(CountdownCoroutine());
    }
    
    void Update()
    {
        
    }
    
    IEnumerator CountdownCoroutine()
    {
        _textCountdown.gameObject.SetActive(true);
    
        _textCountdown.text = "3";
        yield return new WaitForSeconds(1.0f);
    
        _textCountdown.text = "2";
        yield return new WaitForSeconds(1.0f);
    
        _textCountdown.text = "1";
        yield return new WaitForSeconds(1.0f);
    
        _textCountdown.text = "GO!";
        yield return new WaitForSeconds(1.0f);
    
        _textCountdown.text = "";
        _textCountdown.gameObject.SetActive(false);
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SwitchAfterDelay(6.0f));
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SwitchAfterDelay(3.0f));
    }
    IEnumerator<WaitForSeconds> SwitchAfterDelay(float time)
    {
        Debug.Log(time);
        yield return new WaitForSeconds(6.0f);
        if(Input.anyKeyDown)
        SceneManager.LoadScene("Start");
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splashscreen : MonoBehaviour
{
  

    private void Start()
    {
        StartCoroutine(StartSplash());

    }

    private IEnumerator StartSplash()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main Menu");
    }
}

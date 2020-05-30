using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    public float timeToLoad;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoBackToMainMenu());
    }

    void Update()
    {
        GoToMenu();
    }

    private void GoToMenu()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("Start Screen");
        }
    }

    IEnumerator GoBackToMainMenu()
    {
        yield return new WaitForSeconds(timeToLoad);
        SceneManager.LoadScene("Start Screen");
    }

}

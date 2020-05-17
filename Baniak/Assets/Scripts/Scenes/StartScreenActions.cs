using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenActions : MonoBehaviour
{
 public void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }
    public void CloseApplication()
    {
        Application.Quit();
    }

}

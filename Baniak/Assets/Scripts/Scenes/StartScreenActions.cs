using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenActions : MonoBehaviour
{
    private void Start()
    {
        AudioSource audiosource = FindObjectOfType<AudioSource>();
        if(audiosource!=null) Destroy(audiosource);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }
    public void CloseApplication()
    {
        Application.Quit();
    }

    
}

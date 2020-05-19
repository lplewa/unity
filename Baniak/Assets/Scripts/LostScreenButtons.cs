using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostScreenButtons : MonoBehaviour
{
   public void  GoToFightScreen()
    {
        SceneManager.LoadScene("Games Room Fight");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }
}

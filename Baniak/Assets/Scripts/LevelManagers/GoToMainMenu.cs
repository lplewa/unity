using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoBackToMainMenu());
    }

    IEnumerator GoBackToMainMenu()
    {
        yield return new WaitForSeconds(90f);
        SceneManager.LoadScene("Start Screen");
    }
}

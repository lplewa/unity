using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScreen : MonoBehaviour
{
    public float timeToLoad;
    public string sceneName;

    void Start()
    {
        StartCoroutine(GoToNextScene());
    }

    IEnumerator GoToNextScene()
    {
        yield return new WaitForSeconds(timeToLoad);
        SceneManager.LoadScene(sceneName);
    }
}

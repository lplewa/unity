using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelButton : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void ChangeScene(string sceneName)
    {
        Debug.Log("Button Click "+sceneName);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPortal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Portal collision!");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Empty Tavern");
    }
}

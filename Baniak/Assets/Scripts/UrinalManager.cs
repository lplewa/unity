using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrinalManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Activate();
    }

    private void Activate()
    {
        if (dialogueManager.missionStarted)
        {
            var inactiveUrinals = Resources.FindObjectsOfTypeAll<Urinal>();
            if (inactiveUrinals.Length > 0)
            {
                inactiveUrinals[0].transform.gameObject.SetActive(true);
            }
        }
    }
}

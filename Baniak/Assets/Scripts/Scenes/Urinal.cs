using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urinal : MonoBehaviour
{
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.gameObject.SetActive(false);    
    }

}

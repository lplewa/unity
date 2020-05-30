using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButtons : MonoBehaviour
{
    public bool startButton;
    public string hint;

    // Start is called before the first frame update
    void Start()
    {
        if (!startButton)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}

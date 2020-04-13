using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaytonsAuntManager : MonoBehaviour
{


    private CoinCollector coinCollector;
    public DialogueManager auntDialogueManager;
    
        // Start is called before the first frame update
    void Start()
    {
        coinCollector = FindObjectOfType<CoinCollector>();
        MissionAccopmlished();
    }

    // Update is called once per frame
    void Update()
    {
        coinCollector = FindObjectOfType<CoinCollector>();
        MissionAccopmlished();
    }

    void MissionAccopmlished()
    {
        Debug.Log("coins Count: " + coinCollector.coins.Count);
        Debug.Log("coins size: " + coinCollector.space);

        if (coinCollector.coins.Count == coinCollector.space)
        {
            auntDialogueManager.missionAccomplished = true;
        }
    }


}
